using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiActores.DTOs;
using WebApiActores.Entitys;

namespace WebApiActores.Controllers.V1
{
    [ApiController]
    [Route("api/v1/libros/{libroId:int}/comentarios")]
    public class ComentariosController : ControllerBase
    {
        private readonly Negocio negocio;
        private readonly IMapper mapper;

        public ComentariosController(Negocio negocio, IMapper mapper)
        {
            this.negocio = negocio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaComentarioDTO>>> Get(int libroId)
        {
            var list = await negocio.Comentarios.Where(x => x.LibroId == libroId).ToListAsync();
            return Ok(mapper.Map<List<LecturaComentarioDTO>>(list));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CrearComentarioDTO comentarioDTO, int libroId)
        {
            if (!await negocio.Libros.AnyAsync(x => x.Id == libroId)) return NotFound("Libro Inexistente");

            var comentario = mapper.Map<Comentario>(comentarioDTO);
            comentario.LibroId = libroId;
            negocio.Add(comentario);
            await negocio.SaveChangesAsync();
            var lectura = mapper.Map<LecturaComentarioDTO>(comentario);
            return Created($"api/libros/{libroId}/comentarios/{lectura.Id}", lectura);
        }
    }
}
