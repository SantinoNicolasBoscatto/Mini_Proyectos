using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebApiActores.DTOs;
using WebApiActores.Servicios;

namespace WebApiActores.Utilidades
{
    public class HATEOASAutorFilterAttribute : HATEOASFiltroAttribute
    {
        private readonly GenerarEnlacesService enlacesService;

        public HATEOASAutorFilterAttribute(GenerarEnlacesService enlacesService)
        {
            this.enlacesService = enlacesService;
        }

        public async override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var debeIncluir = DebeIncluirHATEOAS(context);
            if(!debeIncluir)
            {
                await next();
                return;
            }
            var resultado = context.Result as ObjectResult;
            var modelo = resultado.Value as LecturaAutorDTO ?? throw new ArgumentNullException("Se esperaba autorDTO");
            enlacesService.GenerarEnlaces(modelo);
            await next();
        }

        
    }
}
