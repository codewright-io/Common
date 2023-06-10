using System.Net;
using System.Text.Json;
using CodeWright.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CodeWright.Common.Asp.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
#pragma warning disable CA1031 // Do not catch general exception types
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
#pragma warning restore CA1031 // Do not catch general exception types
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        switch (exception)
        {
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;
            case BadRequestException:
                statusCode = HttpStatusCode.BadRequest;
                break;
            case InvalidInternalStateException:
                statusCode = HttpStatusCode.Conflict;
                break;
        }
        context.Response.StatusCode = (int)statusCode;

        var response = new ErrorResponse
        {
            Type = exception.GetType().Name,
            Message = exception.Message,
            StackTrace = exception.StackTrace ?? "", // TODO: Developer flag
        };

        var responseString = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(responseString);
    }
}
