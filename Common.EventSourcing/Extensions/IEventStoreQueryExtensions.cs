using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Extension methods for <see cref="IEventStoreQuery"/>.
/// </summary>
public static class IEventStoreQueryExtensions
{
    /// <summary>
    /// Fetch the last event of a specific type.
    /// </summary>
    /// <param name="query">The event store query</param>
    /// <param name="typeId">The type of the object.</param>
    /// <param name="tenantId">The ID of the tenant.</param>
    /// <returns>The matching events</returns>
    public static async Task<IDomainEvent?> GetLastEventOfType(this IEventStoreQuery query, TenantId tenantId, TypeId typeId)
    {
        var results = await query.GetLastEventsOfType(tenantId, typeId, 1);
        return results.FirstOrDefault();
    }

    /// <summary>
    /// Fetch the last event of a specific type.
    /// </summary>
    /// <param name="query">The event store query</param>
    /// <param name="typeId">The type of the object.</param>
    /// <param name="id">The ID of the object.</param>
    /// <param name="tenantId">The ID of the tenant.</param>
    /// <returns>The matching events</returns>
    public static async Task<IDomainEvent?> GetLastEventOfType(this IEventStoreQuery query, ObjectId id, TenantId tenantId, TypeId typeId)
    {
        var results = await query.GetLastEventsOfType(id, tenantId, typeId, 1);
        return results.FirstOrDefault();
    }
}
