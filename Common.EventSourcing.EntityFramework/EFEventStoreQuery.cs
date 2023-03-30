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

    public EFEventStoreQuery(EventSourceDbContext context, JsonConverter converter)
    {
        _context = context;
        _converter = converter;
    }

    public async Task<IDomainEvent?> GetLastEventOfType(string tenantId, string typeId)
    {
        var match = await _context.Events.AsNoTracking()
           .Where(ev => ev.TypeId == typeId && ev.TenantId == tenantId)
           .OrderBy(ev => ev.Version)
           .LastOrDefaultAsync();

        return match != null ? JsonConvert.DeserializeObject<IDomainEvent>(match.Content, _converter) : null;
    }
}
