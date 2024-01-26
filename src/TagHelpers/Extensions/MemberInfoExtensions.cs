using System.Reflection;
using System.Text.RegularExpressions;

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class MemberInfoExtensions
{
    public static bool HasCustomAttribute<T>(this MemberInfo memberInfo)
    {
        return memberInfo.GetCustomAttributes(typeof(T), inherit: true).Any();
    }

    public static bool HasCustomAttribute(this MemberInfo memberInfo, Type attributeType)
    {
        return memberInfo.GetCustomAttributes(attributeType, inherit: true).Any();
    }

    public static string GetHtmlAttributeName(this MemberInfo property)
    {
        var customAttribute = property.GetCustomAttribute<HtmlAttributeNameAttribute>();
        if (customAttribute != null)
        {
            return customAttribute.Name;
        }
        return Regex.Replace(property.Name, "([A-Z])", "-$1").ToLower().Trim('-');
    }
}
