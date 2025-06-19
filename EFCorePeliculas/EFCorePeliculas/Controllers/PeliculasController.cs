using AutoMapper;
using EFCorePeliculas.DTO;
using EFCorePeliculas.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/Peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly Negocio negocio;
        private readonly IMapper mapper;

        public PeliculasController(Negocio negocio, IMapper mapper)
        {
            this.negocio = negocio;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetPelicula(int id) 
        { 
            var pelicula = await negocio.Peliculas
                .Include(x => x.GenerosHash.OrderByDescending(x=> x.Name))
                .Include(x => x.SalaDeCineHash.OrderByDescending(x => x.Cine.NombreCine))
                    .ThenInclude(x=>x.Cine)
                .Include(x=> x.PeliculaActorHash.OrderByDescending(x=>x.Actor.Name))
                    .ThenInclude(x=>x.Actor)
                .FirstOrDefaultAsync(x=> x.PeliculaId == id);
            if(pelicula == null) return NotFound();
            var peliDTO =  mapper.Map<PeliculaDTO>(pelicula);
            peliDTO.CineCollection = peliDTO.CineCollection.DistinctBy(x => x.CineId).OrderBy(x=> x.NombreCine).ToList();
            return peliDTO;
        }

        [HttpGet("CargadoSelectivo/{id:int}")]
        public async Task<ActionResult> GetSelectivo(int id)
        {
            var peli = await negocio.Peliculas.Select(p =>
            new {
                id = p.PeliculaId,
                Title = p.Titulo,
                Generos = p.GenerosHash.Select(x=> new { Nombre = x.Name, Id = x.Identificador }).ToList(),
                NumeroDeActores = p.PeliculaActorHash.Count
            }).FirstOrDefaultAsync(p=> p.id == id);
            if(peli == null) return NotFound(); 
            return Ok(peli);
        }

        [HttpGet("Agrupado")]
        public async Task<ActionResult> GetAgrupado()
        {
            var peliculasAgrupadas = await negocio.Peliculas.GroupBy(x=>x.EnCartelera)
                .Select(x => new
                {
                    EnCartelera = x.Key,
                    Conteo = x.Count(),
                    Peliculas = x.ToList()
                }).ToListAsync();
            return Ok(peliculasAgrupadas);
        }

        [HttpGet("AgrupadasPorGeneros")]
        public async Task<ActionResult> GetAgrupadoPor()
        {
            var pelis = await negocio.Peliculas.GroupBy(x => x.GenerosHash.Count())
                .Select(x=> new
                {
                    Conteo = x.Key,
                    Titulos = x.Select(x=>x.Titulo),
                    Generos = x.Select(x=>x.GenerosHash).SelectMany(gen => gen).Select(x=>x.Name)
                })
                .ToListAsync();

            return Ok(pelis);
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult> Filtrado([FromQuery] PeliculaFiltroDTO filtroDTO)
        {
            var peliculasQuery = negocio.Peliculas.AsQueryable();
            if (!string.IsNullOrEmpty(filtroDTO.Titulo))
            {
                peliculasQuery = peliculasQuery.Where(x=>x.Titulo.Contains(filtroDTO.Titulo));
            }
            if (filtroDTO.EnCartelera)
            {
                peliculasQuery = peliculasQuery.Where(x => x.EnCartelera == true);
            }

            if(filtroDTO.GeneroId != 0)
            {
                peliculasQuery = peliculasQuery.Where(x => x.GenerosHash.Select(y => y.Identificador).Contains(filtroDTO.GeneroId));
            }

            var peliculas = await peliculasQuery.Include(x=> x.GenerosHash).ToListAsync();
            return Ok(peliculas);
        }
    }
}
