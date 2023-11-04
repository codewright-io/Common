using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Repository to save and retrieve domain objects
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDomainRepository<T>
    where T : IDomainObject
{
    /// <summary>
    /// Get the domain entity
    /// </summary>
    Task<T?> GetByIdAsync(string id, TenantId tenantId, string typeId);

    /// <summary>
    /// Save the domain entity
    /// </summary>
    /// <param name="item">The domain object to save</param>
    Task SaveAsync(T item);
}
