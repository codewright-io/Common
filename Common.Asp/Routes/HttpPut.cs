using System.Web;

namespace CodeWright.Common.Asp.Routes;

/// <summary>
/// HTTP Post routes for clients and testing
/// </summary>
public static class HttpPut
{
    /// <summary>
    /// Put or replace a JSON blob
    /// </summary>
    public static string JsonBlob(string typeId, string id) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}/{HttpUtility.UrlEncode(id)}";
}
