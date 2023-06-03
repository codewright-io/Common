using CodeWright.Common.Asp.Middleware;
//using CodeWright.Common.Exceptions;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.DependencyInjection;
//using static System.Net.Mime.MediaTypeNames;

namespace Microsoft.AspNetCore.Builder;

public static class IApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCodeWrightExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        //app.UseExceptionHandler(exceptionHandlerApp =>
        //{
        //    exceptionHandlerApp.Run(async context =>
        //    {
        //        if (context.RequestServices.GetService<IProblemDetailsService>() is { } problemDetailsService)
        //        {
        //            string title;
        //            string detail;
        //            string type;

        //            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

        //            var exceptionType = exceptionHandlerFeature?.Error;
        //            if (exceptionType != null && exceptionType is NotFoundException)
        //            {
        //                title = "Not Found";
        //                detail = "Item not found";
        //                type = "https://errors.example.com/notFound";
        //                context.Response.StatusCode = StatusCodes.Status404NotFound;
        //                context.Response.ContentType = Text.Plain;
        //            }
        //            else
        //            {
        //                title = "Internal Error";
        //                detail = "Please Report";
        //                type = "https://errors.example.com/internalError";
        //                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        //                context.Response.ContentType = Text.Plain;
        //            }

        //            await problemDetailsService.WriteAsync(new ProblemDetailsContext
        //            {
        //                HttpContext = context,
        //                ProblemDetails =
        //        {
        //            Title = title,
        //            Detail = detail,
        //            Type = type
        //        }
        //            });
        //        }
        //    });
        //});

        return app;
    }
}
