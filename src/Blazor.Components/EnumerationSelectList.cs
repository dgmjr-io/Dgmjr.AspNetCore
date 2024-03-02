namespace Dgmjr.Blazor.Components;
using System.Linq;
using System.Collections;

public class EnumerationSelectList<TEnumeration, TIEnumeration> : Blazorise.Components.DropdownList<TIEnumeration, string>
    where TIEnumeration : IHaveAShortName, IHaveADisplayName
{
    public EnumerationSelectList()
    {
        this.Data = (typeof(TEnumeration).GetMethod("GetAll").Invoke(null, null) as IEnumerable).OfType<TIEnumeration>().ToList();
        this.TextField = item => item.DisplayName;
        this.ValueField = item => item.ShortName;
    }
}
