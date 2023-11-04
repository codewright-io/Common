using CodeWright.Common.Ids;

namespace CodeWright.Common.EventSourcing.Models;

/// <summary>
/// Strongly typed ID for tenants
/// </summary>
public record TenantId : StronglyTypedId<string>
{
    /// <summary>
    /// Create an isntance of a TenantId
    /// </summary>
    public TenantId(string value) : base(value) { }
}
