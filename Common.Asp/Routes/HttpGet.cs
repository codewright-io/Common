using System.Web;

namespace CodeWright.Common.Asp.Routes;

/// <summary>
/// HTTP GET routes for clients and testing
/// </summary>
public static class HttpGet
{
    /// <summary>
    /// Fetch a JSON blob
    /// </summary>
    public static string JsonBlobById(string typeId, string id) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}/{HttpUtility.UrlEncode(id)}";

    /// <summary>
    /// Fetch all JSON blobs of a type
    /// </summary>
    public static string JsonBlobAll(string typeId) => $"api/blob/v1/{HttpUtility.UrlEncode(typeId)}";


    /// <summary>
    /// Fetch the swagger index.html
    /// </summary>
    public static string SwaggerIndex() => "/swagger/index.html";
}
