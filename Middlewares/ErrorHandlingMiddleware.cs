namespace ASPNetExapp.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // ���������� ����� � ��������� middleware
            }
            catch (Exception ex)
            {
                // ��������� �������
                Console.WriteLine($"�������: {ex.Message}");

                // ������������ ������ ������ �� 500
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("������� �������.");
            }
        }
    }
}
