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

    /// <summary>
    /// Fetch the swagger index.html
    /// </summary>
    public static string SwaggerIndex() => "/swagger/index.html";
}
