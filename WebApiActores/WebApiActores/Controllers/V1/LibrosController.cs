using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiActores.DTOs;
using WebApiActores.Entitys;

namespace WebApiActores.Controllers.V1
{
    [ApiController]
    [Route("api/v1/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly Negocio negocio;
        private readonly IMapper mapper;

        public LibrosController(Negocio negocio, IMapper mapper)
        {
            this.negocio = negocio;
            this.mapper = mapper;
        }

        [HttpGet(Name = "ObtenerLibros")]
        public async Task<ActionResult<List<LecturaLibroDTO>>> GetLibros()
        {
            var list = await negocio.Libros.Include(x => x.ListaComentarios).Include(x => x.ListaAutoresLibros)
                .AsNoTracking().ToListAsync();
            return Ok(mapper.Map<List<LecturaLibroDTO>>(list));
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LecturaLibroDTO>> GetLibroPorId(int id)
        {
            var autor = await negocio.Libros.Include(x => x.ListaComentarios).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(mapper.Map<LecturaLibroDTO>(autor));
        }

        [HttpPost(Name = "CrearLibro")]
        public async Task<IActionResult> PostLibro(CrearLibroDTO libroDTO)
        {
            if (libroDTO.AutoresId == null) return BadRequest("");

            var autoresId = await negocio.Autores.Where(x => libroDTO.AutoresId.Contains(x.Id))
                            .Select(x => x.Id).ToListAsync();
            var libro = mapper.Map<Libro>(libroDTO);
            negocio.Add(libro);
            await negocio.SaveChangesAsync();
            return Created($"api/libros/{libro.Id}", libro);
        }

        [HttpPatch("id:int")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<LibroPatchDTO> patchDocument)
        {
            if (patchDocument is null) return BadRequest("");

            var libroBD = await negocio.Libros.FirstOrDefaultAsync(x => x.Id == id);
            if (libroBD is null) return NotFound();

            var libroDTO = mapper.Map<LibroPatchDTO>(libroBD);
            patchDocument.ApplyTo(libroDTO, ModelState);

            var esValido = TryValidateModel(libroDTO);
            if (!esValido) return BadRequest(ModelState);

            mapper.Map(libroDTO, libroBD);
            await negocio.SaveChangesAsync();
            return NoContent();
        }
    }
}
