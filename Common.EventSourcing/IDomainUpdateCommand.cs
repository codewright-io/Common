using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// Interface for domain commands
/// </summary>
public interface IDomainUpdateCommand : IDomainCommand
{
    /// <summary>
    /// Unique identifier for the object (unique within the tenancy)
    /// </summary>
    /// <example>A_Midsummer_Nights_Dream</example>
    string Id { get; init; }
}
