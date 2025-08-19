using System.Diagnostics;
namespace Day26Assignment1.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log request
            Debug.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            // Log response
            Debug.WriteLine($"Response Status: {context.Response.StatusCode}");
        }
    }

    // Extension method
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
