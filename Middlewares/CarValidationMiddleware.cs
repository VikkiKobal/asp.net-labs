using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CarModels; 

namespace ASPNetExapp.Middlewares
{
    public class CarValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public CarValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/cars", StringComparison.OrdinalIgnoreCase) &&
                context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                context.Request.EnableBuffering();
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    var body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    Car car;
                    try
                    {
                        car = JsonSerializer.Deserialize<Car>(body, options);
                    }
                    catch (JsonException)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("Invalid JSON format.");
                        return;
                    }

                    if (car == null || string.IsNullOrWhiteSpace(car.Number) || car.Year < 1900 || car.Year > DateTime.Now.Year)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("Invalid car details. Ensure car number is not empty and year is between 1900 and current year.");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
 }
