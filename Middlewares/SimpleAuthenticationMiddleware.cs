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
            // «читуЇмо значенн€ заголовка x-auth
            var authHeader = context.Request.Headers["x-auth"].ToString();

            // ѕерев≥р€Їмо чи значенн€ в заголовку x-auth дор≥внюЇ 12345
            if (authHeader != "12345")
            {
                // якщо токен не сп≥впадаЇ, встановлюЇмо статус 401 (Unauthorized)
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            // якщо автентиф≥кац≥€ пройшла усп≥шно, передаЇмо запит дал≥
            await _next(context);
        }
    }
}
