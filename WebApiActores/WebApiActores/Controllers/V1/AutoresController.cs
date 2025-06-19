using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApiActores.DTOs;
using WebApiActores.Entitys;
using WebApiActores.Filtros;
using WebApiActores.Utilidades;

namespace WebApiActores.Controllers.V1
{
    [ApiController] // Me permite realizar validaciones automaticas sobre la data recibida de mis controladores
    [Route("api/v1/autores")] // La ruta en la cual mi controlador reaccionara, si se hace una peticion sobre esta ruta
                           // sera mi controllador el que salte
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class AutoresController : ControllerBase
    {
        private readonly Negocio negocio;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public AutoresController(Negocio negocio, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this.negocio = negocio;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet(Name = "ObtenerAutores")] // Ruta  => api/autores
        [HttpGet("listado")] // Ruta  => api/autores/listado
        [ResponseCache(Duration = 60)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAutores([FromQuery] PaginacionDTO paginacionDTO)
        {
            var autores = await negocio.Autores.Include(x => x.ListaAutoresLibros).AsNoTracking().ToListAsync();
            var dtos = mapper.Map<List<LecturaAutorDTO>>(autores);
            //if (incluirHATEOAS)
            //{

            //    //dtos.ForEach(dto => GenerarEnlaces(dto));
            //    var result = new ColeccionDeRecursos<LecturaAutorDTO> { Valores = dtos };
            //    result.Endpoints.Add(new DatoHATEOAS(enpoint: Url.Link("CrearAutor", new { }),
            //        desc: "crear-autor", metodo: "POST"));
            //    return Ok(result);
            //}
            return Ok(dtos);
        }

        [HttpGet("{id:int}", Name = "ObtenerAutor")]
        [AllowAnonymous]
        [ServiceFilter(typeof(HATEOASAutorFilterAttribute))]
        public async Task<IActionResult> GetAutorPorId(int id, [FromHeader] string incluirHATEOAS)
        {
            var autor = await negocio.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if (autor == null) return NotFound("No se encontro autor");
            var lectura = mapper.Map<LecturaAutorDTO>(autor);
            return Ok(lectura);
        }

        [HttpGet("{name}", Name = "ObtenerAutorPorNombre")]
        public async Task<ActionResult<List<LecturaAutorDTO>>> GetAutorPorNombre(string name)
        {
            var autores = await negocio.Autores.Where(x => x.Nombre.ToLower().Contains(name.ToLower())).ToListAsync();

            if (autores == null) return NotFound("No se encontro autor");
            var autorDTO = mapper.Map<List<LecturaAutorDTO>>(autores);
            return Ok(autorDTO);
        }
        [HttpPost(Name = "CrearAutor")]
        public async Task<IActionResult> PostAutores([FromBody] CrearAutorDTO autorDTO)
        {
            var existe = await negocio.Autores.AnyAsync(x => x.Nombre == autorDTO.Nombre);
            if (existe) return BadRequest("Ya existe ese autor");

            var autor = mapper.Map<Autor>(autorDTO);

            negocio.Add(autor);
            await negocio.SaveChangesAsync();
            return Created($"api/autores/{autor.Id}", autor);
        }
        [HttpPut("{id:int}", Name = "ActualizarAutor")] // Parametro de Ruta
        public async Task<IActionResult> PutAutores(Autor autor, int id)
        {
            var autorBD = await negocio.Autores.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (autorBD == null) return BadRequest("");
            autor.Id = id;
            negocio.Update(autor);
            await negocio.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "BorrarAutor")] // Parametro de Ruta
        [Authorize]
        public async Task<IActionResult> DeleteAutores(int id)
        {
            var r = await negocio.Autores.AnyAsync(x => x.Id == id);
            if (!r) return NotFound();

            negocio.Remove(new Autor { Id = id });
            await negocio.SaveChangesAsync();
            return NoContent();
        }


    }
}
