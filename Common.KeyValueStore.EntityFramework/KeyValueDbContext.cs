using CodeWright.Common.KeyValueStore.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeWright.Common.KeyValueStore.EntityFramework;

/// <summary>
/// EF View Database context
/// </summary>
public class KeyValueDbContext : DbContext
{
    /// <summary>
    /// Create an instance of a DiceDbContext.
    /// </summary>
    public KeyValueDbContext(DbContextOptions<KeyValueDbContext> options)
        : base(options) { }

    /// <summary>
    /// KeyValue entites
    /// </summary>
    public DbSet<KeyValueEntity> KeyValues { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<KeyValueEntity>().HasKey(p => new { p.Id });
    }
}
