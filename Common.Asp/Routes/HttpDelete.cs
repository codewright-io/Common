using System.Web;

namespace CodeWright.Common.Asp.Routes;

/// <summary>
/// HTTP DELETE routes for clients and testing
/// </summary>
public static class HttpDelete
{
    #region Blob
    /// <summary>
    /// Delete a JSON blob
    /// </summary>
    public static string JsonBlob(string typeId, string id) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}/{HttpUtility.UrlEncode(id)}";
    #endregion Blob

    #region Policy
    /// <summary>
    /// Delete a policy
    /// </summary>
    public static string Policy(string id) => $"api/policy/v1/{HttpUtility.UrlEncode(id)}";

    /// <summary>
    /// Delete a policy target
    /// </summary>
    public static string PolicyTarget(string id) => $"api/policy-targets/v1/{HttpUtility.UrlEncode(id)}";
    #endregion Policy
}
