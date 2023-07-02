using System.Web;

namespace CodeWright.Common.Asp.Routes;

/// <summary>
/// HTTP GET routes for clients and testing
/// </summary>
public static class HttpGet
{
    #region Blob
    /// <summary>
    /// Fetch a JSON blob
    /// </summary>
    public static string JsonBlobById(string typeId, string id) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}/{HttpUtility.UrlEncode(id)}";

    /// <summary>
    /// Fetch all JSON blobs of a type
    /// </summary>
    public static string JsonBlobAll(string typeId) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}";
    #endregion Blob

    #region Policy

    /// <summary>
    /// Fetch a Policy
    /// </summary>
    public static string PolicyById(string id) => $"api/policy/v1/{HttpUtility.UrlEncode(id)}";

    /// <summary>
    /// Fetch all Policies
    /// </summary>
    public static string PolicyAll() => $"api/policy/v1/";

    /// <summary>
    /// Fetch a policy target
    /// </summary>
    public static string PolicyTargetById(string id) => $"api/policy-target/v1/{HttpUtility.UrlEncode(id)}";


    /// <summary>
    /// Fetch policy targets by type
    /// </summary>
    public static string PolicyTargetsByType(string typeId) => $"api/policy-target/v1/bytype/{HttpUtility.UrlEncode(typeId)}";

    /// <summary>
    /// Evaluate a policy
    /// </summary>
    /// <returns></returns>
    public static string PolicyTargetEvaluate(string targetId, string targetAction)
        => $"api/policy-target/v1/evaluate?targetId={targetId}&targetAction={targetAction}";
    #endregion Policy

    #region Tags

    public static string ItemMetadata(string tenantId, string id) => $"api/items/metadata/v1/{tenantId}/{id}";

    public static string ItemRelationships(string tenantId, string id) => $"api/items/relationships/v1/{tenantId}/{id}";

    public static string Referencing(string tenantId, string targetId)
        => $"api/items/relationships/v1/referencing/{tenantId}/{targetId}";

    public static string ItemTags(string tenantId, string id) => $"api/items/tags/v1/{tenantId}/{id}";

    public static string ItemsByTag(string tenantId, string tag) => $"api/items/tags/v1/search/{tenantId}?tag={tag}";

    public static string ItemEvents(string tenantId, string id, int limit) => $"api/items/v1/events/{tenantId}/{id}?limit={limit}";

    public static string SearchMetadata(string tenantId, string name, string value, string secondaryName, string secondaryValue, int limit, int offset)
        => $"api/items/metadata/v1/search/{tenantId}?name={name}&value={value}&secondaryName={secondaryName}&secondaryValue={secondaryValue}&limit={limit}&offset={offset}";

    public static string SearchMetadata(string tenantId, string name, string value, int limit, int offset)
        => $"api/items/metadata/v1/search/{tenantId}?name={name}&value={value}&limit={limit}&offset={offset}";

    #endregion Tags

    /// <summary>
    /// Fetch the swagger index.html
    /// </summary>
    public static string SwaggerIndex() => "/swagger/index.html";
}
