namespace Shared.Extensions;

public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) =>
        source == null || !source.Any();

    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) =>
        source.GroupBy(keySelector).Select(g => g.First());

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        var rng = new Random();
        return source.OrderBy(_ => rng.Next());
    }
}