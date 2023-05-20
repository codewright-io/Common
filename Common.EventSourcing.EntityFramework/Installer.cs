using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CodeWright.Common.EventSourcing.EntityFramework;

public static class Install
{
    public static async Task MigrateAsync(IServiceProvider provider)
    {
        var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("Install");
        var eventSourceContext = provider.GetRequiredService<EventSourceDbContext>();

        logger.LogInformation("Creating Event Sourcing Tables");
        eventSourceContext.Database.SetCommandTimeout(300);
        await eventSourceContext.Database.MigrateAsync();
    }
}
