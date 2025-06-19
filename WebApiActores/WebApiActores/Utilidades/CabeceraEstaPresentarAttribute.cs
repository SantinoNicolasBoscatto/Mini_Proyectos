using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace WebApiActores.Utilidades
{
    public class CabeceraEstaPresentarAttribute : Attribute, IActionConstraint
    {
        private readonly string cabecera;
        private readonly string valor;

        public CabeceraEstaPresentarAttribute(string cabecera, string valor)
        {
            this.cabecera = cabecera;
            this.valor = valor;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var cabeceras = context.RouteContext.HttpContext.Request.Headers;
            if(!cabeceras.ContainsKey(cabecera)) return false;
            
            return string.Equals(cabeceras[cabecera], valor, StringComparison.OrdinalIgnoreCase);
        }
    }
}
