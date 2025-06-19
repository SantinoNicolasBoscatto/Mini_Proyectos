using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using WebApiActores.DTOs;

namespace WebApiActores.Servicios
{
    public class GenerarEnlacesService
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IHttpContextAccessor httpContext;
        private readonly IActionContextAccessor actionContextAccessor;

        public GenerarEnlacesService(IAuthorizationService authorizationService, IHttpContextAccessor httpContext,
            IActionContextAccessor actionContextAccessor) 
        {
            this.authorizationService = authorizationService;
            this.httpContext = httpContext;
            this.actionContextAccessor = actionContextAccessor;
        }

        public async void GenerarEnlaces(LecturaAutorDTO autorDTO)
        {
            var esAdmin = await EsAdmin();
            var Url = ConstruirURLHelper();
            autorDTO.Endpoints = new List<DatoHATEOAS>();
            autorDTO.Endpoints.Add(new DatoHATEOAS(Url.Link("ObtenerAutor", new { id = autorDTO.Id }),
                desc: "self", metodo: "GET"));
            if(esAdmin)
            {
                autorDTO.Endpoints.Add(new DatoHATEOAS(Url.Link("ActualizarAutor", new { id = autorDTO.Id }),
                desc: "autor-actualizar", metodo: "PUT"));
                autorDTO.Endpoints.Add(new DatoHATEOAS(Url.Link("BorrarAutor", new { id = autorDTO.Id }),
                    desc: "autor-delete", metodo: "DELETE"));
            }
        }


        private async Task<bool> EsAdmin()
        {
            var resultado = await authorizationService.AuthorizeAsync(httpContext.HttpContext.User, "EsAdmin");
            return resultado.Succeeded;
        }

        private IUrlHelper ConstruirURLHelper()
        {
            var factoria = httpContext.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            return factoria.GetUrlHelper(actionContextAccessor.ActionContext);
        }
    }
}
