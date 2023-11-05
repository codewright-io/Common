using CodeWright.Common;
using CodeWright.Common.KeyValueStore.EntityFramework;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Register key value store
    /// </summary>
    public static IServiceCollection AddEFKeyValueStore(this IServiceCollection services, DatabaseType database, string connectionString)
    {
        services.AddDbContext<KeyValueDbContext>(options => options.UseDatabase(database, connectionString, "CodeWright.Common.KeyValueStore.EntityFramework"));

        services.AddScoped<IKeyValueStore, EFKeyValueStore>();
        return services;
    }
}
