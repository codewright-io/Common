namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Queries to fetch specific events from the event store
/// </summary>
public interface IEventStoreQuery
{
    /// <summary>
    /// Fetch the last event of type.
    /// </summary>
    /// <param name="typeId">The type of the object.</param>
    /// <param name="tenantId">The ID of the tenant.</param>am>
    /// <returns>The matching event</returns>
    Task<IDomainEvent?> GetLastEventOfType(string tenantId, string typeId);
}
