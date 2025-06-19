using Clean_Architecture.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace Clean_Architecture.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private static async Task HandleExceptionAsync(HttpContext context, ValidationException validationException)
        {
            // Capturo la Respuesta del HttpContext, y la formateo a JSON
            var response = context.Response;
            response.ContentType = "application/json";

            // Genero el StatusCode y se lo coloco a la respuesta
            var statusCode = HttpStatusCode.InternalServerError;
            response.StatusCode = (int)statusCode;

            // Creo un objeto anonimo de error y lo formateo a JSON
            var result = JsonSerializer.Serialize(new
            {
                error = validationException.Message,
                detail = validationException.InnerException?.Message,
            });
            await response.WriteAsync(result);
        }
    }
}
