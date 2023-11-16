using System.Reflection;
using CodeWright.Common;
using CodeWright.Common.Asp;
using CodeWright.Common.EventSourcing;
using CodeWright.Common.EventSourcing.EntityFramework;
using CodeWright.Common.EventSourcing.Snapshots;
using Newtonsoft.Json;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Service registration extensions
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Register command handlers and validators
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddEntityFrameworkEventSourcing(this IServiceCollection services, ServiceSettings settings)
    {
        // Add basic event sourcing classes
        var generationId = Math.Abs(string.GetHashCode(settings.ServiceId, StringComparison.InvariantCulture) % 1024);
        services.AddEventSourcing(generationId);

        // Add the event store DB context
        services.AddDbContext<EventSourceDbContext>(options => options.UseDatabase(settings.Database, settings.EventConnectionString, "CodeWright.Common.EventSourcing.EntityFramework"));

        // Add the event store
        services.AddScoped<IEventStore, EFEventStore>();

        // Add event store queries
        services.AddScoped<IEventStoreQuery, EFEventStoreQuery>();

        return services;
    }

    /// <summary>
    /// Register event creation and JSON converter
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddEvents<TModel, TFactory>(this IServiceCollection services, Assembly modelAssembly)
        where TModel : IDomainObject
        where TFactory : IDomainObjectFactory<TModel>, new()
    {
        // Register domain event assemblies to our JSON converter (It is thread-safe)
        services.AddSingleton<JsonConverter>(p => new DomainEventJsonConverter(modelAssembly));

        services.AddEventRepositories<TModel, TFactory>();

        return services;
    }

    /// <summary>
    /// Register event creation
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddEventRepositories<TModel, TFactory>(this IServiceCollection services)
        where TModel : IDomainObject
        where TFactory : IDomainObjectFactory<TModel>, new()
    {
        services.AddScoped<ISnapshotRepository<TModel>, EFSnapshotRepository<TModel>>();
        services.AddScoped<IDomainRepository<TModel>, SnapshotDomainObjectRepository<TModel, TFactory>>();

        return services;
    }
}
