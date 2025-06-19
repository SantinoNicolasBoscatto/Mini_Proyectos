using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : CustomBaseController
    {
        public GenerosController(Negocio negocio, IMapper mapper) : base(negocio, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaGeneroDTO>>> Get()
        {
            return await GetBase<Genero, LecturaGeneroDTO>();
        }

        [HttpGet("{id:int}", Name = "GeneroPorId")]
        public async Task<ActionResult<LecturaGeneroDTO>> GetId(int id)
        {
            return await GetIdBase<Genero, LecturaGeneroDTO>(id);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CrearGeneroDTO generoDTO)
        {
            return await PostBase<Genero, CrearGeneroDTO, LecturaGeneroDTO>(generoDTO, "GeneroPorId");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearGeneroDTO generoDTO, int id)
        {
           return await PutBase<Genero, CrearGeneroDTO>(generoDTO, id);
        }
    }

    
}
