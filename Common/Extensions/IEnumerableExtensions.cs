namespace System.Linq;

/// <summary>
/// Extensions for IEnumerable
/// </summary>
public static class IEnumerableExtensions
{
    /// <summary>
    /// Return true if the enumerable is not null and contains one or more items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static bool AnyAndNotNull<T>(this IEnumerable<T> items) => items != null && items.Any();
}
