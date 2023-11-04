using CodeWright.Common.Ids;

namespace CodeWright.Common.EventSourcing.Models;

/// <summary>
/// Strongly typed ID for types
/// </summary>
public record TypeId : StronglyTypedId<string>
{
    /// <summary>
    /// Create an isntance of a TypeId
    /// </summary>
    public TypeId(string value) : base(value) { }
}
