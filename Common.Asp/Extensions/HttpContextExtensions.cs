using System.Globalization;
using CodeWright.Common;
using Microsoft.Net.Http.Headers;

namespace Microsoft.AspNetCore.Http;

/// <summary>
/// HttpContext extensions
/// </summary>
public static class HttpContextExtensions
{
    /// <summary>
    /// Return the User ID from the HTTP header
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static string? GetUserId(this HttpContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        // TODO: Consider other methods to provide the userid
        string? userId = null;
        if (context.Request.Headers.TryGetValue("userid", out var value))
        {
            userId = value.FirstOrDefault();
        }
        return userId;
    }

    /// <summary>
    /// Return the Tenant ID from the HTTP header
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static string GetTenantId(this HttpContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        // TODO: Consider other methods to provide the tenantid
        string? tenantId = null;
        if (context.Request.Headers.TryGetValue("tenantid", out var value))
        {
            tenantId = value.FirstOrDefault();
        }
        return tenantId ?? ReservedTenants.Default;
    }

    /// <summary>
    /// Return the culture from the HTTP header or the null if not present
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static CultureInfo? GetCulture(this HttpContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (!context.Request.Headers.TryGetValue(HeaderNames.AcceptLanguage, out var value))
        {
            return null;
        }

        var stringValue = value.ToString();
        return !string.IsNullOrWhiteSpace(stringValue) ? new CultureInfo(stringValue) : null;
    }
}
