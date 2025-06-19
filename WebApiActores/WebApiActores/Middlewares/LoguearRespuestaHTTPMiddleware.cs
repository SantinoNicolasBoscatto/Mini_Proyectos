namespace WebApiActores.Middlewares
{
    public class LoguearRespuestaHTTPMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoguearRespuestaHTTPMiddleware> logger;

        public LoguearRespuestaHTTPMiddleware(RequestDelegate next, ILogger<LoguearRespuestaHTTPMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var ms = new MemoryStream())
            {
                //Primera Ejecucion del Middleware
                var cuerpoOriginalRespuesta = context.Response.Body;
                context.Response.Body = ms;
                await next(context); // => Indico que se ejecuten los siguientes Middleware

                // Ejecucion POST respuesta del resto de Middlewares
                ms.Seek(0, SeekOrigin.Begin);
                string respuesta = new StreamReader(ms).ReadToEnd();
                ms.Seek(0, SeekOrigin.Begin);
                await ms.CopyToAsync(cuerpoOriginalRespuesta);
                context.Response.Body = cuerpoOriginalRespuesta;
                logger.LogInformation(respuesta);
            }
        }
    }

    public static class LoguearRespuestaHTTPMiddlewareExtension
    {
        public static IApplicationBuilder UseLoguearRespuesta(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoguearRespuestaHTTPMiddleware>();
        }
    }
}
