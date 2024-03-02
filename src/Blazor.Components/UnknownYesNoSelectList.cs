namespace Dgmjr.Blazor.Components;
using Microsoft.AspNetCore.Components;

public class UnknownYesNoSelectList : Blazorise.Components.DropdownList<bool?, bool?>
{
    [Parameter]
    public string UnknownText { get; set; } = "Unknown";
    [Parameter]
    public string YesText { get; set; } = "Yes";
    [Parameter]
    public string NoText { get; set; } = "No";

    public UnknownYesNoSelectList()
    {
        Data = new[] { (bool?)null, true, false };
        TextField = item =>
            item switch
            {
                null => UnknownText,
                true => YesText,
                false => NoText
            };
        ValueField = item => item;
    }

    public virtual string SelectedValueString
    {
        get => SelectedValue switch
        {
            null => UnknownText,
            true => YesText,
            false => NoText
        };
        set
        {
            SelectedValue = value switch
            {
                string s when s == UnknownText => null,
                string s when s == YesText => true,
                string s when s == NoText => false,
                _ => SelectedValue
            };
        }
    }
}
