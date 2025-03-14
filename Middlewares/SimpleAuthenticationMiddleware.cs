using System;
using System.Text;

namespace ASPNetExapp.Middlewares
{
    public class SimpleAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers["x-auth"].ToString();

            if (authHeader != "12345")
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await _next(context);
        }
    }
}
