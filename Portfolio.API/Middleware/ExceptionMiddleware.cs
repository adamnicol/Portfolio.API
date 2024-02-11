using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Portfolio.API.Middleware
{
    internal class ExceptionMiddleware(
        RequestDelegate next, 
        ILogger<ExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, $"Error executing {context}");

                await HandleExceptionAsync(context);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context) 
        {
            var details = new ProblemDetails()
            {
                Title = "Internal Server Error",
                Detail = "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Instance = context.Request.Path,
            };

            string result = JsonSerializer.Serialize(details);

            context.Response.StatusCode = details.Status.Value;
            context.Response.ContentType = "application/problem+json";

            return context.Response.WriteAsync(result);
        }
    }
}
