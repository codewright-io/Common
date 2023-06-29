using System.ComponentModel.DataAnnotations;

namespace CodeWright.Common.EventSourcing;

/// <summary>
/// The result of a successful command applied to an object
/// </summary>
public class CommandResult
{
    /// <summary>
    /// Version of the object after the command was applied
    /// </summary>
    /// <example>123456</example>
    [Required]
    public required long Version { get; init; }

    /// <summary>
    /// Unique identifier for the object (unique within the tenancy)
    /// </summary>
    /// <example>A_Midsummer_Nights_Dream</example>
    [Required]
    public required string Id { get; init; }
}
