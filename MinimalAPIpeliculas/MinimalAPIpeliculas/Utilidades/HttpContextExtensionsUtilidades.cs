using Microsoft.IdentityModel.Tokens;

namespace MinimalAPIpeliculas.Utilidades
{
    public static class HttpContextExtensionsUtilidades
    {
        public static T ExtraerValorPorDefecto<T>(this HttpContext httpContext, string nombreDelCapo,T valorPorDefecto)
            where T : IParsable<T>
        {
            var valor = httpContext.Request.Query[nameof(nombreDelCapo)];
            if (valor.IsNullOrEmpty()) return valorPorDefecto;

            return T.Parse(valor!, null);
        }
    }
}
