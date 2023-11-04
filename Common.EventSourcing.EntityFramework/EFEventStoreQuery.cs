using CodeWright.Common.EventSourcing.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CodeWright.Common.EventSourcing.EntityFramework;

/// <summary>
/// An entity framework based event store.
/// </summary>
public class EFEventStoreQuery : IEventStoreQuery
{
    private readonly EventSourceDbContext _context;
    private readonly JsonConverter _converter;

    /// <summary>
    /// Create an instance of a EFEventStoreQuery
    /// </summary>
    public EFEventStoreQuery(EventSourceDbContext context, JsonConverter converter)
    {
        _context = context;
        _converter = converter;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<IDomainEvent>> GetAsync(long fromVersion, int limit)
    {
        var matches = await _context.Events.AsNoTracking()
           .Where(ev => ev.Version > fromVersion)
           .OrderBy(ev => ev.Version)
           .Take(limit)
           .ToListAsync();

        var results = matches
            .Select(m => JsonConvert.DeserializeObject<IDomainEvent>(m.Content, _converter))
            .Where(m => m != null)
            .ToList();

        return results!;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<IDomainEvent>> GetLastEventsOfType(TenantId tenantId, TypeId typeId, int count)
    {
        var matches = await _context.Events.AsNoTracking()
           .Where(ev => ev.TypeId == typeId.ToString() && ev.TenantId == tenantId.ToString())
           .OrderByDescending(ev => ev.Version)
           .Take(count)
           .ToListAsync();

        var results = matches
            .Select(m => JsonConvert.DeserializeObject<IDomainEvent>(m.Content, _converter))
            .Where(m => m != null)
            .ToList();

        return results!;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<IDomainEvent>> GetLastEventsOfType(ObjectId id, TenantId tenantId, TypeId typeId, int count)
    {
        var matches = await _context.Events.AsNoTracking()
           .Where(ev => ev.TypeId == typeId.ToString() && ev.Id == id.ToString() && ev.TenantId == tenantId.ToString())
           .OrderByDescending(ev => ev.Version)
           .Take(count)
           .ToListAsync();

        var results = matches
            .Select(m => JsonConvert.DeserializeObject<IDomainEvent>(m.Content, _converter))
            .Where(m => m != null)
            .ToList();

        return results!;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<IDomainEvent>> GetOfTypeAsync(TenantId tenantId, TypeId typeId, long fromVersion, int limit)
    {
        var matches = await _context.Events.AsNoTracking()
           .Where(ev => ev.TypeId == typeId.ToString() && ev.TenantId == tenantId.ToString())
           .Where(ev => ev.Version > fromVersion)
           .OrderBy(ev => ev.Version)
           .Take(limit)
           .ToListAsync();

        var results = matches
            .Select(m => JsonConvert.DeserializeObject<IDomainEvent>(m.Content, _converter))
            .Where(m => m != null)
            .ToList();

        return results!;
    }
}
