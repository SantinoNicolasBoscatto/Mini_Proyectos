using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Services;
using PeliculasAPI.Utilidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/Actores")]
    public class ActoresController : CustomBaseController
    {
        private readonly Negocio negocio;
        private readonly IMapper mapper;
        private readonly IFilesService filesService;
        private static readonly string contenedor = "Actor";

        public ActoresController(Negocio negocio, IMapper mapper, IFilesService filesService) : base(negocio, mapper)
        {
            this.negocio = negocio;
            this.mapper = mapper;
            this.filesService = filesService;
        }


        [HttpGet]
        public async Task<ActionResult<List<LecturaActoresDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            return await GetPaginadoBase<Actor, LecturaActoresDTO>(paginacionDTO);
        }

        [HttpGet("{id:int}",Name = "ActorPorId")]
        public async Task<ActionResult<LecturaActoresDTO>> GetPorId(int id)
        {
            return await GetIdBase<Actor, LecturaActoresDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CrearActorDTO actorDTO)
        {
            if (actorDTO.Foto == null) return BadRequest();

            var actor = mapper.Map<Actor>(actorDTO);
            string Foto = await filesService.GuardarImagen(contenedor, actorDTO.Foto);
            actor.Foto = Foto;
            negocio.Add(actor);
            await negocio.SaveChangesAsync();
            var lectura = mapper.Map<LecturaActoresDTO>(actor);
            return CreatedAtRoute("ActorPorId", new { id = actor.Id }, lectura);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] CrearActorDTO actorDTO, int id)
        {
            var actorBD = await negocio.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if(actorBD == null) return NotFound();
            actorBD = mapper.Map(actorDTO, actorBD);
            if (actorDTO.Foto is not null) actorBD!.Foto = await filesService.Editar(actorBD.Foto, contenedor, actorDTO.Foto);

            negocio.Update(actorBD!);
            await negocio.SaveChangesAsync();
            return NoContent();
        }
    }
}
