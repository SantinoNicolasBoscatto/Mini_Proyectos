using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiActores.Utilidades
{
    public class HATEOASFiltroAttribute : ResultFilterAttribute
    {
        protected bool DebeIncluirHATEOAS(ResultExecutingContext executingContext)
        {
            var result = executingContext.Result as ObjectResult;

            if(!esExitoso(result)) return false;

            var cabecera = executingContext.HttpContext.Request.Headers["incluirHATEOAS"];
            if(cabecera.Count() == 0) return false;

            var valor = cabecera[0];
            if(!valor.Equals("Y", StringComparison.InvariantCultureIgnoreCase)) return false;

            return true;
        }

        private bool esExitoso(ObjectResult result)
        {
            if (result == null || result.Value == null) return false;
            if(result.StatusCode.HasValue && !result.StatusCode.Value.ToString().StartsWith("2")) return false;

            return true;
        }
    }
}
