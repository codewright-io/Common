using System.Web;

namespace CodeWright.Common.Asp.Routes;

/// <summary>
/// HTTP Post routes for clients and testing
/// </summary>
public static class HttpPut
{
    #region Blob
    /// <summary>
    /// Put or replace a JSON blob
    /// </summary>
    public static string JsonBlob(string typeId, string id) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}/{HttpUtility.UrlEncode(id)}";

    #endregion Blob

    #region Policy
    /// <summary>
    /// Update a policy
    /// </summary>
    public static string Policy => $"api/policy/v1/";
    #endregion Policy
}
