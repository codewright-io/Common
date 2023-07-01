using System.Web;

namespace CodeWright.Common.Asp.Routes;

/// <summary>
/// HTTP Post routes for clients and testing
/// </summary>
public static class HttpPost
{
    /// <summary>
    /// Create a JSON blob, or replace if it exists
    /// </summary>
    public static string JsonBlob(string typeId, string id) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}/{HttpUtility.UrlEncode(id)}";
}
