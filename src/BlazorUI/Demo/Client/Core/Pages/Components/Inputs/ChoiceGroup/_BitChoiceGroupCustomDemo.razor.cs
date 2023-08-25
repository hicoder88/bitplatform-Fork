﻿namespace Bit.BlazorUI.Demo.Client.Core.Pages.Components.Inputs.ChoiceGroup;

public partial class _BitChoiceGroupCustomDemo
{
    private string oneWayValue = "A";
    private string twoWayValue = "A";
    private string itemTemplateValue = "Day";
    private string itemLabelTemplateValue = "Day";
    public ChoiceGroupValidationModel validationModel = new();
    public string? successMessage;


    private readonly List<ChoiceModel> basicCustoms = new()
    {
        new() { Name = "Custom A", ItemValue = "A" },
        new() { Name = "Custom B", ItemValue = "B" },
        new() { Name = "Custom C", ItemValue = "C" },
        new() { Name = "Custom D", ItemValue = "D" }
    };
    private readonly List<ChoiceModel> disabledCustoms = new()
    {
        new() { Name = "Custom A", ItemValue = "A" },
        new() { Name = "Custom B", ItemValue = "B" },
        new() { Name = "Custom C", ItemValue = "C", IsDisabled = true },
        new() { Name = "Custom D", ItemValue = "D" }
    };
    private readonly List<ChoiceModel> imageCustoms = new()
    {
        new()
        {
            Name = "Bar",
            ItemValue = "Bar",
            ImageSize = new BitSize(32, 32),
            ImageDescription = "alt for Bar image",
            ImageAddress = "https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-bar-unselected.png",
            SelectedImageAddress = "https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-bar-selected.png",
        },
        new()
        {
            Name = "Pie",
            ItemValue = "Pie",
            ImageSize = new BitSize(32, 32),
            ImageDescription = "alt for Pie image",
            ImageAddress= "https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-pie-unselected.png",
            SelectedImageAddress = "https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-pie-selected.png",
        }
    };
    private readonly List<ChoiceModel> iconCustoms = new()
    {
        new() { Name = "Day", ItemValue = "Day", IconName = BitIconName.CalendarDay },
        new() { Name = "Week", ItemValue = "Week", IconName = BitIconName.CalendarWeek },
        new() { Name = "Month", ItemValue = "Month", IconName = BitIconName.Calendar, IsDisabled = true }
    };
    private readonly List<ChoiceModel> itemTemplateCustoms = new()
    {
        new() { Name = "Day", ItemValue = "Day", IconName = BitIconName.CalendarDay },
        new() { Name = "Week", ItemValue = "Week", IconName = BitIconName.CalendarWeek },
        new() { Name = "Month", ItemValue = "Month", IconName = BitIconName.Calendar }
    };
    private readonly List<ChoiceModel> rtlCustoms = new()
    {
        new() { Name = "ویژه آ", ItemValue = "A" },
        new() { Name = "ویژه ب", ItemValue = "B" },
        new() { Name = "ویژه پ", ItemValue = "C" },
        new() { Name = "ویژه ت", ItemValue = "D" }
    };


    private void HandleValidSubmit()
    {
        successMessage = "Form Submitted Successfully!";
    }

    private void HandleInvalidSubmit()
    {
        successMessage = string.Empty;
    }


    private readonly string example1HtmlCode = @"
<BitChoiceGroup Label=""Basic Customs""
                Items=""basicCustoms""
                DefaultValue=""basicCustoms[1].ItemValue""
                NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) }, Value = { Name = nameof(ChoiceModel.ItemValue) } })"" />";
    private readonly string example1CsharpCode = @"
public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
}

private readonly List<ChoiceModel> basicCustoms = new()
{
    new() { Name = ""Custom A"", ItemValue = ""A"" },
    new() { Name = ""Custom B"", ItemValue = ""B"" },
    new() { Name = ""Custom C"", ItemValue = ""C"" },
    new() { Name = ""Custom D"", ItemValue = ""D"" }
};";

    private readonly string example2HtmlCode = @"
<BitChoiceGroup Label=""Disabled ChoiceGroup""
                IsEnabled=""false""
                Items=""basicCustoms""
                DefaultValue=""@(""A"")""
                NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) }, Value = { Name = nameof(ChoiceModel.ItemValue) } })"" />

<BitChoiceGroup Label=""ChoiceGroup with Disabled Custom""
                Items=""disabledCustoms""
                DefaultValue=""@(""A"")""
                NameSelectors=""@(new() { Text = { Selector = i => i.Name }, 
                                         Value = { Selector = i => i.ItemValue },
                                         IsEnabled = { Selector = i => i.IsDisabled is false } })"" />";
    private readonly string example2CsharpCode = @"
public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
    public bool IsDisabled { get; set; }
}

private readonly List<ChoiceModel> basicCustoms = new()
{
    new() { Name = ""Custom A"", ItemValue = ""A"" },
    new() { Name = ""Custom B"", ItemValue = ""B"" },
    new() { Name = ""Custom C"", ItemValue = ""C"" },
    new() { Name = ""Custom D"", ItemValue = ""D"" }
};

private readonly List<ChoiceModel> disabledCustoms = new()
{
    new() { Name = ""Custom A"", ItemValue = ""A"" },
    new() { Name = ""Custom B"", ItemValue = ""B"" },
    new() { Name = ""Custom C"", ItemValue = ""C"", IsDisabled = true },
    new() { Name = ""Custom D"", ItemValue = ""D"" }
};";

    private readonly string example3HtmlCode = @"
<BitChoiceGroup Label=""Image Customs""
                DefaultValue=""@(""Bar"")""
                Items=""imageCustoms""
                NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) },
                                         Value = { Name = nameof(ChoiceModel.ItemValue) },
                                         ImageSrc = { Name = nameof(ChoiceModel.ImageAddress) },
                                         ImageAlt = { Name = nameof(ChoiceModel.ImageDescription) },
                                         ImageSize = { Name = nameof(ChoiceModel.ImageSize) },
                                         SelectedImageSrc = { Name = nameof(ChoiceModel.SelectedImageAddress) }})"" />

<BitChoiceGroup Label=""Icon Customs""
                DefaultValue=""@(""Day"")""
                Items=""iconCustoms""
                NameSelectors=""@(new() { Text = { Selector = i => i.Name },
                                         Value = { Selector = i => i.ItemValue },
                                         IconName = { Selector = i => i.IconName },
                                         IsEnabled = { Selector = i => i.IsDisabled is false } })"" />";
    private readonly string example3CsharpCode = @"
public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
    public string ImageAddress { get; set; }
    public string ImageDescription { get; set; }
    public Size? ImageSize { get; set; }
    public string SelectedImageAddress { get; set; }
    public string? IconName { get; set; }
    public bool IsDisabled { get; set; }
}

private readonly List<ChoiceModel> imageCustoms = new()
{
    new()
    {
        Name = ""Bar"",
        ItemValue = ""Bar"",
        ImageSize = new BitSize(32, 32),
        ImageDescription = ""alt for Bar image"",
        ImageAddress = ""https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-bar-unselected.png"",
        SelectedImageAddress = ""https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-bar-selected.png"",
    },
    new()
    {
        Name = ""Pie"",
        ItemValue = ""Pie"",
        ImageSize = new BitSize(32, 32),
        ImageDescription = ""alt for Pie image"",
        ImageAddress= ""https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-pie-unselected.png"",
        SelectedImageAddress = ""https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-pie-selected.png"",
    }
};

private readonly List<ChoiceModel> iconCustoms = new()
{
    new() { Name = ""Day"", ItemValue = ""Day"", IconName = BitIconName.CalendarDay },
    new() { Name = ""Week"", ItemValue = ""Week"", IconName = BitIconName.CalendarWeek },
    new() { Name = ""Month"", ItemValue = ""Month"", IconName = BitIconName.Calendar, IsDisabled = true }
};";

    private readonly string example4HtmlCode = @"
<style>
    .custom-label {
        color: #A4262C;
        font-weight: bold;
    }
</style>

<BitChoiceGroup Items=""basicCustoms""
                DefaultValue=""@(""A"")""
                NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) }, Value = { Name = nameof(ChoiceModel.ItemValue) } })"">
    <LabelTemplate>
        <div class=""custom-label"">
            Custom label <BitIcon IconName=""@BitIconName.Filter"" />
        </div>
    </LabelTemplate>
</BitChoiceGroup>";
    private readonly string example4CsharpCode = @"
public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
}

private readonly List<ChoiceModel> basicCustoms = new()
{
    new() { Name = ""Custom A"", ItemValue = ""A"" },
    new() { Name = ""Custom B"", ItemValue = ""B"" },
    new() { Name = ""Custom C"", ItemValue = ""C"" },
    new() { Name = ""Custom D"", ItemValue = ""D"" }
};";

    private readonly string example5HtmlCode = @"
<style>
    .custom-container {
        display: flex;
        align-items: center;
        gap: 10px;
        cursor: pointer;
    }

    .custom-circle {
        width: 20px;
        height: 20px;
        border: 1px solid;
        border-radius: 10px;
    }

    .custom-container:hover .custom-circle {
        border-top: 5px solid #C66;
        border-bottom: 5px solid #6C6;
        border-left: 5px solid #66C;
        border-right: 5px solid #CC6;
    }

    .custom-container.selected {
        color: #C66;
    }

    .custom-container.selected .custom-circle {
        border-top: 10px solid #C66;
        border-bottom: 10px solid #6C6;
        border-left: 10px solid #66C;
        border-right: 10px solid #CC6;
    }
</style>

<BitChoiceGroup Label=""ItemLabelTemplate"" @bind-Value=""itemLabelTemplateValue""
                Items=""itemTemplateCustoms""
                NameSelectors=""@(new() { Value = { Selector = i => i.ItemValue } })"">
    <ItemLabelTemplate Context=""custom"">
        <div style=""margin-left:30px;height:20px"" class=""custom-container @(itemLabelTemplateValue == custom.ItemValue ? ""selected"" : string.Empty)"">
            <BitIcon IconName=""@custom.IconName"" />
            <span>@custom.Name</span>
        </div>
    </ItemLabelTemplate>
</BitChoiceGroup>

<BitChoiceGroup Label=""ItemTemplate"" @bind-Value=""itemTemplateValue""
                Items=""itemTemplateCustoms""
                NameSelectors=""@(new() { Value = { Name = nameof(ChoiceModel.ItemValue) } })"">
    <ItemTemplate Context=""custom"">
        <div class=""custom-container @(itemTemplateValue == custom.ItemValue ? ""selected"" : string.Empty)"">
            <div class=""custom-circle""></div>
            <span>@custom.Name</span>
        </div>
    </ItemTemplate>
</BitChoiceGroup>";
    private readonly string example5CsharpCode = @"
private string itemLabelTemplateValue = ""Day"";
private string itemTemplateValue = ""Day"";

public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
    public string? IconName { get; set; }
}

private readonly List<ChoiceModel> itemTemplateCustoms = new()
{
    new() { Name = ""Day"", ItemValue = ""Day"", IconName = BitIconName.CalendarDay },
    new() { Name = ""Week"", ItemValue = ""Week"", IconName = BitIconName.CalendarWeek },
    new() { Name = ""Month"", ItemValue = ""Month"", IconName = BitIconName.Calendar }
};";

    private readonly string example6HtmlCode = @"
<BitChoiceGroup Label=""One-way"" Value=""@oneWayValue""
                Items=""basicCustoms""
                NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) }, Value = { Name = nameof(ChoiceModel.ItemValue) } })"" />
<BitTextField @bind-Value=""oneWayValue"" />

<BitChoiceGroup Label=""Two-way"" @bind-Value=""twoWayValue""
                Items=""basicCustoms""
                NameSelectors=""@(new() { Text = { Selector = i => i.Name }, Value = { Selector = i => i.ItemValue } })"" />
<BitTextField @bind-Value=""twoWayValue"" />";
    private readonly string example6CsharpCode = @"
private string oneWayValue = ""A"";
private string twoWayValue = ""A"";

public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
}

private readonly List<ChoiceModel> basicCustoms = new()
{
    new() { Name = ""Custom A"", ItemValue = ""A"" },
    new() { Name = ""Custom B"", ItemValue = ""B"" },
    new() { Name = ""Custom C"", ItemValue = ""C"" },
    new() { Name = ""Custom D"", ItemValue = ""D"" }
};";

    private readonly string example7HtmlCode = @"
<BitChoiceGroup Label=""Basic""
                DefaultValue=""@(""A"")""
                Items=""basicCustoms""
                LayoutFlow=""BitLayoutFlow.Horizontal""
                NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) }, Value = { Name = nameof(ChoiceModel.ItemValue) } })"" />

<BitChoiceGroup Label=""Disabled""
                IsEnabled=""false""
                DefaultValue=""@(""A"")""
                Items=""basicCustoms""
                LayoutFlow=""BitLayoutFlow.Horizontal""
                NameSelectors=""@(new() { Text = { Selector = i => i.Name }, Value = { Selector = i => i.ItemValue } })"" />

<BitChoiceGroup Label=""Image""
                DefaultValue=""@(""Bar"")""
                Items=""imageCustoms""
                LayoutFlow=""BitLayoutFlow.Horizontal""
                NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) },
                                         Value = { Name = nameof(ChoiceModel.ItemValue) },
                                         ImageSrc = { Name = nameof(ChoiceModel.ImageAddress) },
                                         ImageAlt = { Name = nameof(ChoiceModel.ImageDescription) },
                                         ImageSize = { Name = nameof(ChoiceModel.ImageSize) },
                                         SelectedImageSrc = { Name = nameof(ChoiceModel.SelectedImageAddress) }})"" />

<BitChoiceGroup Label=""Icon""
                DefaultValue=""@(""Day"")""
                Items=""iconCustoms""
                LayoutFlow=""BitLayoutFlow.Horizontal""
                NameSelectors=""@(new() { Text = { Selector = i => i.Name },
                                         Value = { Selector = i => i.ItemValue },
                                         IconName = { Selector = i => i.IconName },
                                         IsEnabled = { Selector = i => i.IsDisabled is false } })"" />";
    private readonly string example7CsharpCode = @"
public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
    public string ImageAddress { get; set; }
    public string ImageDescription { get; set; }
    public Size? ImageSize { get; set; }
    public string SelectedImageAddress { get; set; }
    public string? IconName { get; set; }
    public bool IsDisabled { get; set; }
}

private readonly List<ChoiceModel> basicCustoms = new()
{
    new() { Name = ""Custom A"", ItemValue = ""A"" },
    new() { Name = ""Custom B"", ItemValue = ""B"" },
    new() { Name = ""Custom C"", ItemValue = ""C"" },
    new() { Name = ""Custom D"", ItemValue = ""D"" }
};

private readonly List<ChoiceModel> imageCustoms = new()
{
    new()
    {
        Name = ""Bar"",
        ItemValue = ""Bar"",
        ImageSize = new BitSize(32, 32),
        ImageDescription = ""alt for Bar image"",
        ImageAddress = ""https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-bar-unselected.png"",
        SelectedImageAddress = ""https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-bar-selected.png"",
    },
    new()
    {
        Name = ""Pie"",
        ItemValue = ""Pie"",
        ImageSize = new BitSize(32, 32),
        ImageDescription = ""alt for Pie image"",
        ImageAddress= ""https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-pie-unselected.png"",
        SelectedImageAddress = ""https://static2.sharepointonline.com/files/fabric/office-ui-fabric-react-assets/choicegroup-pie-selected.png"",
    }
};

private readonly List<ChoiceModel> iconCustoms = new()
{
    new() { Name = ""Day"", ItemValue = ""Day"", IconName = BitIconName.CalendarDay },
    new() { Name = ""Week"", ItemValue = ""Week"", IconName = BitIconName.CalendarWeek },
    new() { Name = ""Month"", ItemValue = ""Month"", IconName = BitIconName.Calendar, IsDisabled = true }
};";

    private readonly string example8HtmlCode = @"
<BitChoiceGroup Label=""Basic""
                IsRtl=""true""
                DefaultValue=""@(""A"")""
                Items=""rtlCustoms""
                NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) }, Value = { Name = nameof(ChoiceModel.ItemValue) } })"" />

<BitChoiceGroup Label=""Disabled""
                IsRtl=""true""
                IsEnabled=""false""
                DefaultValue=""@(""A"")""
                Items=""rtlCustoms""
                NameSelectors=""@(new() { Text = { Selector = i => i.Name }, Value = { Selector = i => i.ItemValue } })"" />";
    private readonly string example8CsharpCode = @"
public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
}

private readonly List<ChoiceModel> rtlCustoms = new()
{
    new() { Name = ""ویژه آ"", ItemValue = ""A"" },
    new() { Name = ""ویژه ب"", ItemValue = ""B"" },
    new() { Name = ""ویژه پ"", ItemValue = ""C"" },
    new() { Name = ""ویژه ت"", ItemValue = ""D"" }
};";

    private readonly string example9HtmlCode = @"
<EditForm Model=""@validationModel"" OnValidSubmit=""@HandleValidSubmit"" OnInvalidSubmit=""@HandleInvalidSubmit"">
    <DataAnnotationsValidator />
    <div>
        <BitChoiceGroup @bind-Value=""validationModel.Value""
                        Items=""basicCustoms""
                        NameSelectors=""@(new() { Text = { Name = nameof(ChoiceModel.Name) }, Value = { Name = nameof(ChoiceModel.ItemValue) } })"" />
        <ValidationMessage For=""@(() => validationModel.Value)"" />
    </div>
    <BitButton Style=""margin-top: 10px;"" ButtonType=""BitButtonType.Submit"">Submit</BitButton>
</EditForm>";
    private readonly string example9CsharpCode = @"
public class ChoiceModel
{
    public string Name { get; set; }
    public string ItemValue { get; set; }
}

private readonly List<ChoiceModel> basicCustoms = new()
{
    new() { Name = ""Custom A"", ItemValue = ""A"" },
    new() { Name = ""Custom B"", ItemValue = ""B"" },
    new() { Name = ""Custom C"", ItemValue = ""C"" },
    new() { Name = ""Custom D"", ItemValue = ""D"" }
};

public class ChoiceGroupValidationModel
{
    [Required(ErrorMessage = ""Pick one"")]
    public string Value { get; set; }
}

public ChoiceGroupValidationModel validationModel = new();

private void HandleValidSubmit() { }

private void HandleInvalidSubmit() { }";
}