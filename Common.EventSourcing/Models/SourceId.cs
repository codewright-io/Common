using CodeWright.Common.Ids;

namespace CodeWright.Common.EventSourcing.Models;

/// <summary>
/// Strongly typed ID for event sources
/// </summary>
public record SourceId : StronglyTypedId<string>
{
    /// <summary>
    /// Create an isntance of a SourceId
    /// </summary>
    public SourceId(string value) : base(value) { }
}
