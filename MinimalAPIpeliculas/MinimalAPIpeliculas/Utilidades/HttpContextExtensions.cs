using Microsoft.EntityFrameworkCore;

namespace MinimalAPIpeliculas.Utilidades
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacionEnCabecera<T>(this HttpContext httpContext, IQueryable<T> query)
        {
            if(httpContext is null) throw new ArgumentNullException(nameof(httpContext));

            double cantidad = await query.CountAsync();
            httpContext.Response.Headers.Append("cantidadTotalDeRegistros", cantidad.ToString());
        }
    }
}
