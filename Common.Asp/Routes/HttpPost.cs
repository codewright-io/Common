using System.Web;

namespace CodeWright.Common.Asp.Routes;

/// <summary>
/// HTTP Post routes for clients and testing
/// </summary>
public static class HttpPost
{
    #region Blob
    /// <summary>
    /// Create a JSON blob, or replace if it exists
    /// </summary>
    public static string JsonBlob(string typeId, string id) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}/{HttpUtility.UrlEncode(id)}";

    /// <summary>
    /// Post a bulk set of JSON Blobs
    /// </summary>
    public static string JsonBlobBulkImport() => $"api/blob-bulk/v1/import";
    #endregion Blob

    #region Policy
    /// <summary>
    /// Create a policy
    /// </summary>
    public static string Policy => $"api/policy/v1/";

    /// <summary>
    /// Create a policy
    /// </summary>
    public static string PolicyBulk => $"api/policy/v1/bulk";

    /// <summary>
    /// Add a policy target
    /// </summary>
    public static string PolicyTargetAdd => $"api/policy-target/v1/add";

    /// <summary>
    /// Remove a policy target
    /// </summary>
    public static string PolicyTargetRemove => $"api/policy-target/v1/remove";
    #endregion Policy

    #region Tags
    public static string AddMetadata() => "api/items/metadata/v1/add";

    public static string RemoveMetadata() => "api/items/metadata/v1/remove";

    public static string SetMetadata() => "api/items/metadata/v1";

    public static string AddRelationships() => "api/items/relationships/v1/add";

    public static string RemoveRelationships() => "api/items/relationships/v1/remove";

    public static string SetReflationships() => "api/items/relationships/v1";

    public static string AddTags() => "api/items/tags/v1/add";

    public static string RemoveTags() => "api/items/tags/v1/remove";

    public static string SetTags() => "api/items/tags/v1";

    #endregion Tags
}
