using Microsoft.Extensions.Hosting;

namespace CodeWright.Common.Asp.HostedServices;

/// <summary>
/// Details here : https://www.stevejgordon.co.uk/asp-net-core-2-ihostedservice
/// 
/// This code provided by David Fowler: https://gist.github.com/davidfowl/a7dd5064d9dcf35b6eae1a7953d615e3
/// </summary>
public abstract class HostedService : IHostedService
{
    private Task? _executingTask = null;
    private CancellationTokenSource? _cts = null;

    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Create a linked token so we can trigger cancellation outside of this token's cancellation
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        // Store the task we're executing
        _executingTask = ExecuteAsync(_cts.Token);

        // If the task is completed then return it, otherwise it's running
        return _executingTask.IsCompleted ? _executingTask : Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        // Stop called without start
        if (_executingTask == null)
        {
            return;
        }

        // Signal cancellation to the executing method
        if (_cts is not null)
            _cts.Cancel();

        // Wait until the task completes or the stop token triggers
        await Task.WhenAny(_executingTask, Task.Delay(-1, cancellationToken));

        // Run tear-down
        await TeardownAsync();

        // Throw if cancellation triggered
        cancellationToken.ThrowIfCancellationRequested();
    }

    /// <summary>
    /// Derived classes should override this and execute a long running method until 
    /// cancellation is requested    
    /// </summary>
    protected abstract Task ExecuteAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Derived classes should optionally override this and execute any key tear down
    /// logic which may be required for clean termination.
    /// </summary>
    protected virtual Task TeardownAsync()
    {
        return Task.CompletedTask;
    }
}
