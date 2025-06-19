using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiActores.DTOs;

namespace WebApiActores.Controllers.V2
{
    [ApiController]
    [Route("api/v2")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RootController : ControllerBase
    {
        private readonly IAuthorizationService authorizationService;

        public RootController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        [HttpGet(Name = "ObtenerRootv2")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DatoHATEOAS>>> Get()
        {
            var datosHateoas = new List<DatoHATEOAS>();

            // Evalua si el Usuario que le paso cuenta con la politica es admin
            var esAdmin = await authorizationService.AuthorizeAsync(User, "EsAdmin");

            datosHateoas.Add(new DatoHATEOAS(enpoint: Url.Link("ObtenerRoot", new { }), desc: "self", metodo: "GET"));
            datosHateoas.Add(new DatoHATEOAS(enpoint: Url.Link("ObtenerAutores", new { }), desc: "autores", metodo: "GET"));
            datosHateoas.Add(new DatoHATEOAS(enpoint: Url.Link("ObtenerLibros", new { }), desc: "libros", metodo: "GET"));
            if (esAdmin.Succeeded)
            {
                datosHateoas.Add(new DatoHATEOAS(enpoint: Url.Link("CrearAutor", new { }), desc: "autores", metodo: "POST"));
                datosHateoas.Add(new DatoHATEOAS(enpoint: Url.Link("CrearLibro", new { }), desc: "libros", metodo: "POST"));
            }
            return datosHateoas;
        }
    }
}
