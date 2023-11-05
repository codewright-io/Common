using CodeWright.Common.EventSourcing;
using CodeWright.Common.KeyValueStore.EntityFramework.Entities;

namespace CodeWright.Common.KeyValueStore.EntityFramework;

public class EFKeyValueStore : IKeyValueStore
{
    private readonly KeyValueDbContext _context;

    /// <summary>
    /// Create an instance of a TrainingQuery
    /// </summary>
    public EFKeyValueStore(KeyValueDbContext context)
    {
        _context = context;
    }

    public async Task<string?> GetAsync(string key)
    {
        var match = await _context.FindAsync<KeyValueEntity>(key);
        return match?.Json;
    }

    public async Task SetAsync(string key, string value)
    {
        var match = await _context.FindAsync<KeyValueEntity>(key);
        if (match is null)
        {
            await _context.AddAsync(new KeyValueEntity { Id = key, Json = value });
        }
        else
        {
            match.Json = value;
            _context.Update(match);
        }
        await _context.SaveChangesAsync();
    }
}
