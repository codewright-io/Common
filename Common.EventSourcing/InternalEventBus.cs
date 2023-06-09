﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Reflection;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// An internal bus that can be used if there's only a single instance of this service running
/// </summary>
public class InternalEventBus : IEventBus
{
    private readonly IServiceProvider _serviceProvider;

    // Cache of reflected event handler methods.
    // Can be a null entry if no handler for that method.
    private static readonly ConcurrentDictionary<Type, MethodInfo?> _methodLookup = new();

    /// <summary>
    /// Create an instance of a InternalEventBus
    /// </summary>
    /// <param name="serviceProvider"></param>
    public InternalEventBus(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <inheritdoc/>
    public async Task SendAsync(IEnumerable<IDomainEvent> events)
    {
        foreach (var ev in events)
        {
            if (!_methodLookup.TryGetValue(ev.GetType(), out var handleEventMethod))
            {   // Cache miss, so create an add
                var eventHandlerType = typeof(IEventHandler<>).MakeGenericType(ev.GetType());
                handleEventMethod = eventHandlerType.GetMethod("HandleAsync");

                _methodLookup.TryAdd(ev.GetType(), handleEventMethod);
            }

            if (handleEventMethod != null)
            {
                if (handleEventMethod.ReflectedType == null)
                    throw new InvalidOperationException("Event handler method has no reflected type");

                var handlers = _serviceProvider.GetServices(handleEventMethod.ReflectedType);

                foreach (var handler in handlers)
                {
#pragma warning disable CA1031 // Do not catch general exception types
                    try
                    {
                        if (handleEventMethod.Invoke(handler, new[] { ev }) is Task task)
                            await task;
                    }
                    catch (Exception ex)
                    {   // Swallow exceptions in handlers and move onto the next event
                        var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
                        var logger = loggerFactory.CreateLogger(handler?.GetType() ?? GetType());
                        logger.LogError(ex, "Event hander had unhandled exception");
                        continue;
                    }
#pragma warning restore CA1031 // Do not catch general exception types
                }
            }
        }
    }
}
