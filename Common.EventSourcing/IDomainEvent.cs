﻿using System.ComponentModel.DataAnnotations;
using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Interface for domain events
/// </summary>
public interface IDomainEvent
{
    /// <summary> identifier for the object (unique within the tenancy) </summary>
    /// <example>A_Midsummer_Nights_Dream</example>
    [Required, StringLength(Identifiers.MaximumLength)]
    ObjectId Id { get; }

    /// <summary>Tenant Id for the object</summary>
    /// <example>William_Shakespeare</example>
    [Required, StringLength(Identifiers.MaximumLength)]
    TenantId TenantId { get; }

    /// <summary>Time that the event was created</summary>
    /// <example>2007-03-01T13:00:00Z</example>
    [Required]
    DateTime Time { get; }

    /// <summary>The source service that generated the event</summary>
    SourceId SourceId { get; }

    /// <summary>The ID of the user that generated the event</summary>
    UserId UserId { get; }

    /// <summary>The ID of the type of object that the domain event pertains to</summary>
    [Required]
    TypeId TypeId { get; }

    /// <summary>Version for event ordering</summary>
    /// <example>123456</example>
    [Required]
    long Version { get; }

    /// <summary>The event class name, used to assist in deserializing</summary>
    public string EventClass { get; }
}
