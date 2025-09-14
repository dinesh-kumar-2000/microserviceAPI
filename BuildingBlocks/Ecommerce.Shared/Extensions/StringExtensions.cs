namespace Shared.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string value) =>
        string.IsNullOrEmpty(value);

    public static bool IsNullOrWhiteSpace(this string value) =>
        string.IsNullOrWhiteSpace(value);

    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
    }

    public static string ToSlug(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;
        return value
            .ToLowerInvariant()
            .Replace(" ", "-")
            .Replace(".", "")
            .Replace(",", "")
            .Replace(":", "")
            .Replace(";", "")
            .Replace("/", "")
            .Replace("\\", "")
            .Replace("?", "")
            .Replace("&", "and");
    }
}
