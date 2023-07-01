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
    #endregion Blob

    #region Policy
    /// <summary>
    /// Create a policy
    /// </summary>
    public static string Policy => $"api/policy/v1/";

    /// <summary>
    /// Add a policy target
    /// </summary>
    public static string PolicyTargetAdd => $"api/policy-target/v1/add";

    /// <summary>
    /// Remove a policy target
    /// </summary>
    public static string PolicyTargetRemove => $"api/policy-target/v1/remove";
    #endregion Policy
}
