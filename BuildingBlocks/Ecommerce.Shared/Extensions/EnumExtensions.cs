using System.ComponentModel;
using System.Reflection;

namespace Shared.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }

    public static T ToEnum<T>(this string value, bool ignoreCase = true) where T : struct =>
        Enum.TryParse<T>(value, ignoreCase, out var result) ? result : default;
}
