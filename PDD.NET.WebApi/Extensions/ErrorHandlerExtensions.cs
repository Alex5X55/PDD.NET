using Microsoft.AspNetCore.Diagnostics;
using PDD.NET.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace PDD.NET.WebApi.Extensions;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature == null) return;

                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = contextFeature.Error switch
                {
                    BadRequestException badRequest when badRequest.Errors != null && badRequest.Errors.Any() =>
                        (int) HttpStatusCode.BadRequest,
                    BadRequestException badRequest => (int)HttpStatusCode.BadRequest,
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var errorResponse = new
                {
                    statusCode = context.Response.StatusCode,
                    message = contextFeature.Error.Message,
                    details = (contextFeature.Error as BadRequestException)?.Errors
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
    }
}