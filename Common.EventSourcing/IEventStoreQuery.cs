namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Queries to fetch specific events from the event store
/// </summary>
public interface IEventStoreQuery
{
    /// <summary>
    /// Fetch the last events of a specific type.
    /// </summary>
    /// <param name="typeId">The type of the object.</param>
    /// <param name="tenantId">The ID of the tenant.</param>
    /// <param name="count">The number of events to fetch.</param>
    /// <returns>The matching events</returns>
    Task<IEnumerable<IDomainEvent>> GetLastEventsOfType(string tenantId, string typeId, int count);

    /// <summary>
    /// Fetch the last events of a specific type.
    /// </summary>
    /// <param name="typeId">The type of the object.</param>
    /// <param name="id">The ID of the object.</param>
    /// <param name="tenantId">The ID of the tenant.</param>
    /// <param name="count">The number of events to fetch.</param>
    /// <returns>The matching events</returns>
    Task<IEnumerable<IDomainEvent>> GetLastEventsOfType(string id, string tenantId, string typeId, int count);
}
