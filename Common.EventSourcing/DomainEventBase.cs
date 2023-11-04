using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Optional base class for domain events
/// </summary>
public abstract class DomainEventBase : IDomainEvent
{
    /// <inheritdoc />
    public required string Id { get; init; }

    /// <inheritdoc />
    public required TenantId TenantId { get; init; }

    /// <inheritdoc />
    public required DateTime Time { get; init; }

    /// <inheritdoc />
    public required string SourceId { get; init; }

    /// <inheritdoc />
    public required long Version { get; init; }

    /// <summary>The ID of the user that generated the event</summary>
    public required UserId UserId { get; init; }

    /// <summary>The ID of the type of object that the domain event pertains to</summary>
    public abstract string TypeId { get; }

    /// <summary>The event class name, used to assist in deserializing</summary>
    public string EventClass => GetType().Name;
}
