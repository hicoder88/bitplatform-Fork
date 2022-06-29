﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Bit.SourceGenerators;

[Generator]
public class BlazorSetParametersSourceGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxContextReceiver is not BlazorParameterPropertySyntaxReceiver receiver)
            return;

        foreach (var group in receiver.Properties.GroupBy(symbol => symbol.ContainingType, SymbolEqualityComparer.Default))
        {
            var properties = group.Select(p => new BitProperty(p, false)).ToList();
            //CheckTwoWayBoundParameter(properties);

            if (group.Key == null) continue;

            string classSource = GeneratePartialClassToOverrideSetParameters((INamedTypeSymbol)group.Key, properties);
            context.AddSource($"{group.Key.Name}_SetParametersAsync.AutoGenerated.cs", SourceText.From(classSource, Encoding.UTF8));
        }
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new BlazorParameterPropertySyntaxReceiver());
    }

    private static string GeneratePartialClassToOverrideSetParameters(INamedTypeSymbol classSymbol, List<BitProperty> properties)
    {
        string namespaceName = classSymbol.ContainingNamespace.ToDisplayString();
        bool isBase = classSymbol.BaseType?.ToDisplayString() == "Microsoft.AspNetCore.Components.ComponentBase";

        StringBuilder source = new StringBuilder($@"using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace {namespaceName}
{{
    public partial class {GetClassName(classSymbol)}
    {{
        public override Task SetParametersAsync(ParameterView parameters)
        {{
");
        //foreach (var property in properties.Where(p => p.IsTwoWayBoundProperty))
        //{
        //    source.AppendLine($"            {property.PropertySymbol.Name}HasBeenSet = false;");
        //} 
        source.AppendLine("            var parametersDictionary = parameters.ToDictionary() as Dictionary<string, object>;");
        source.AppendLine("            foreach (var parameter in parametersDictionary!)");
        source.AppendLine("            {");
        source.AppendLine("                switch (parameter.Key)");
        source.AppendLine("                {");

        // create cases for each property
        foreach (var bitProperty in properties)
        {
            source.AppendLine($"                    case nameof({bitProperty.PropertySymbol.Name}):");
            //if (bitProperty.IsTwoWayBoundProperty)
            //{
            //    source.AppendLine($"                       {bitProperty.PropertySymbol.Name}HasBeenSet = true;");
            //}
            source.AppendLine($"                       {bitProperty.PropertySymbol.Name} = ({bitProperty.PropertySymbol.Type.ToDisplayString()})parameter.Value;");
            source.AppendLine("                       parametersDictionary.Remove(parameter.Key);");
            source.AppendLine("                       break;");
        }

        source.AppendLine("                }");
        source.AppendLine("            }");

        if (isBase)
        {
            source.AppendLine("            return base.SetParametersAsync(ParameterView.Empty);");
        }
        else
        {
            source.AppendLine("            return base.SetParametersAsync(ParameterView.FromDictionary(parametersDictionary as IDictionary<string, object?>));");
        }

        source.AppendLine("        }");
        source.AppendLine("    }");
        source.AppendLine("}");

        return source.ToString();
    }

    private static string GetClassName(INamedTypeSymbol classSymbol)
    {
        StringBuilder sbName = new StringBuilder(classSymbol.Name);

        if (classSymbol.IsGenericType)
        {
            sbName.Append('<');
            sbName.Append(string.Join(", ", classSymbol.TypeArguments.Select(s => s.Name)));
            sbName.Append('>');
        }

        return sbName.ToString();
    }

    //private static void CheckTwoWayBoundParameter(List<BitProperty> properties)
    //{
    //    foreach (var item in properties)
    //    {
    //        var propName = $"{item.PropertySymbol.Name}Changed";
    //        var propType = $"Microsoft.AspNetCore.Components.EventCallback<{item.PropertySymbol.Type.ToDisplayString()}>";
    //        item.IsTwoWayBoundProperty = properties.Any(p => p.PropertySymbol.Name == propName && p.PropertySymbol.Type.ToDisplayString() == propType);
    //    }
    //}
}
