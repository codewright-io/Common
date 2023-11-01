using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodeWright.Common.Asp.HostedServices;

/// <summary>
/// Create a service that executes a function periodically
/// </summary>
public class PeriodicHostedService : HostedService, IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly string _serviceName;
    private readonly Func<IServiceProvider, CancellationToken, Task<TimeSpan>> _periodicFunc;
    private readonly Func<IServiceProvider, CancellationToken, Task>? _startFunc;
    private readonly int _exceptionDelay;

    /// <summary>
    /// Create an instance of a PeriodicHostedService
    /// </summary>
    public PeriodicHostedService(
        IServiceScopeFactory serviceScopeFactory,
        string serviceName,
        Func<IServiceProvider, CancellationToken, Task<TimeSpan>> periodicFunc,
        Func<IServiceProvider, CancellationToken, Task>? startFunc = null,
        int exceptionDelay = 10000)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _serviceName = serviceName;
        _periodicFunc = periodicFunc;
        _startFunc = startFunc;
        _exceptionDelay = exceptionDelay;
    }

    /// <summary>
    /// Service main loop
    /// </summary>
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Hosted Service Loop")]
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        // Run the startup function
        if (_startFunc is not null && !cancellationToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<PeriodicHostedService>>();

            try
            {
                await _startFunc(scope.ServiceProvider, cancellationToken);
            }
            catch (OperationCanceledException ex)
            {
                logger.LogInformation(ex, "{ServiceName}: Canceled during start", _serviceName);
            }
            catch (Exception ex)
            {
                // Catch all, we always want to let the hosted service start
                logger.LogError(ex, "{ServiceName}: Exception during start", _serviceName);
            }
        }

        // Continually loop
        while (!cancellationToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<PeriodicHostedService>>();

            try
            {
                // Run the provided function, and wait until the next loop
                var delay = await _periodicFunc(scope.ServiceProvider, cancellationToken);
                if (!cancellationToken.IsCancellationRequested)
                    await Task.Delay(delay, cancellationToken);
            }
            catch (OperationCanceledException ex)
            {
                logger.LogInformation(ex, "{ServiceName}: Canceled during run", _serviceName);
                return;
            }
            catch (Exception ex)
            {
                // Catch all, the show must go on
                logger.LogError(ex, "{Name} - Uncaught Exception", _serviceName);
                await Task.Delay(_exceptionDelay, cancellationToken);
            }
        }
    }
}
