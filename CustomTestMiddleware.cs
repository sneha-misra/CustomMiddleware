using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CustomMiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomTestMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomTestMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("- Before Message -  \n\r");
            await _next(context);
            await context.Response.WriteAsync("\n\r - After Message - ");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class WTRCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomTestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomTestMiddleware>();
        }
    }
}
