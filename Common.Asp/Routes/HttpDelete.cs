using System.Web;

namespace CodeWright.Common.Asp.Routes;

/// <summary>
/// HTTP DELETE routes for clients and testing
/// </summary>
public static class HttpDelete
{
    /// <summary>
    /// Delete a JSON blob
    /// </summary>
    public static string JsonBlob(string typeId, string id) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}/{HttpUtility.UrlEncode(id)}";
}
