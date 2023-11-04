using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Interface for domain commands
/// </summary>
public interface IDomainCommand
{
    /// <summary>
    /// Unique identifier for the object (unique within the tenancy)
    /// </summary>
    /// <example>A_Midsummer_Nights_Dream</example>
    string Id { get; init; }

    /// <summary>
    /// Tenant Id for the object
    /// </summary>
    /// <example>William_Shakespeare</example>
    TenantId TenantId { get; init; }
}
