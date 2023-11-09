using System.Diagnostics;

namespace System.Linq;

/// <summary>
/// Enumerable extenion methods and static methods
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Generate a range of long values
    /// </summary>
    /// <param name="start">The value to start generating from</param>
    /// <param name="count">The number of values to generate</param>
    /// <returns>An enumber of long values</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static IEnumerable<long> Range(long start, int count)
    {
        long max = start + count - 1;
        if (count < 0 || max > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (count == 0)
        {
            return Enumerable.Empty<long>();
        }

        var result = new List<long>();
        for (long i = start; i <= max; i++)
        {
            result.Add(i);
        }

        return result;
    }
}
