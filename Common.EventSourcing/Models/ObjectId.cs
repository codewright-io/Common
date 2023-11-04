using CodeWright.Common.Ids;

namespace CodeWright.Common.EventSourcing.Models;

/// <summary>
/// Strongly typed ID for objects
/// </summary>
public record ObjectId : StronglyTypedId<string>
{
    /// <summary>
    /// Create an isntance of a ObjectId
    /// </summary>
    public ObjectId(string value) : base(value) { }
}
