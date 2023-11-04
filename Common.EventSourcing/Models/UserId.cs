using CodeWright.Common.Ids;

namespace CodeWright.Common.EventSourcing.Models;

/// <summary>
/// Strongly typed ID for users
/// </summary>
public record UserId : StronglyTypedId<string>
{
    /// <summary>
    /// Create an isntance of a UserId
    /// </summary>
    public UserId(string value) : base(value) { }
}
