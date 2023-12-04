using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Queries to fetch specific events from the event store
/// </summary>
public interface IEventStoreAuditQuery
{
    /// <summary>
    /// Fetch the last events of a specific type.
    /// </summary>
    /// <param name="userId">The user to fetch events for.</param>
    /// <param name="typeId">The type of the object.</param>
    /// <param name="tenantId">The ID of the tenant.</param>
    /// <param name="count">The number of events to fetch.</param>
    /// <returns>The matching events</returns>
    Task<IEnumerable<IDomainEvent>> GetLastEventsOfType(UserId userId, TenantId tenantId, TypeId typeId, int count);
}
