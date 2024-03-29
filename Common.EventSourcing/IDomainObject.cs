﻿using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Interface for all domain objects
/// </summary>
public interface IDomainObject
{
    /// <summary>
    /// Unique identifier for the object (unique within the tenancy)
    /// </summary>
    ObjectId Id { get; init; }

    /// <summary>
    /// Tenant Id for the object
    /// </summary>
    TenantId TenantId { get; init; }

    /// <summary>
    /// Version for event ordering
    /// </summary>
    long Version { get; }

    /// <summary>A unique ID for the type</summary>
    TypeId TypeId { get; }

    /// <summary>
    /// Start queueing events.
    /// </summary>
    void StartQueuing();

    /// <summary>
    /// Stop queueing events and fetch the current list.
    /// </summary>
    IEnumerable<IDomainEvent> StopQueuing();
}
