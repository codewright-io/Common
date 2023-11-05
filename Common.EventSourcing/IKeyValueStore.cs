namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Interface for a generic key/value lookup
/// </summary>
public interface IKeyValueStore
{
    /// <summary>
    /// Get an item by its key
    /// </summary>
    Task<string?> GetAsync(string key);

    /// <summary>
    /// Save an item
    /// </summary>
    Task SetAsync(string key, string value);
}
