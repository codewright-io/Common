using System;
using IdGen;
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
    public async Task<IEnumerable<IDomainEvent>> GetLastEventsOfType(string tenantId, string typeId, int count)
    {
        var matches = await _context.Events.AsNoTracking()
           .Where(ev => ev.TypeId == typeId && ev.TenantId == tenantId)
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
    public async Task<IEnumerable<IDomainEvent>> GetLastEventsOfType(string id, string tenantId, string typeId, int count)
    {
        var matches = await _context.Events.AsNoTracking()
           .Where(ev => ev.TypeId == typeId && ev.Id == id && ev.TenantId == tenantId)
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
    public async Task<IEnumerable<IDomainEvent>> GetOfTypeAsync(string tenantId, string typeId, long fromVersion, int limit)
    {
        var matches = await _context.Events.AsNoTracking()
           .Where(ev => ev.TypeId == typeId && ev.TenantId == tenantId)
           .Where(ev => ev.Version > fromVersion)
           .OrderByDescending(ev => ev.Version)
           .Take(limit)
           .ToListAsync();

        var results = matches
            .Select(m => JsonConvert.DeserializeObject<IDomainEvent>(m.Content, _converter))
            .Where(m => m != null)
            .ToList();

        return results!;
    }
}
