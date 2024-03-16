using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ToDoList.Util;

public static class DisplayEnumsName
{
    public static string? GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetName();
    }
}