using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Utilidades
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarRegistrosTotalesBDCabecera<T>(this HttpContext httpContext, IQueryable<T> query)
        {
            if (httpContext is null) throw new ArgumentNullException(nameof(httpContext));
            double cantidad = await query.CountAsync();
            // En la respuesta HTTP coloca un header con el numero de registros totales
            httpContext.Response.Headers.Append("cantidadTotalDeRegistros", cantidad.ToString());
        }
    }
}
