using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Services;
using PeliculasAPI.Utilidades;
using System.Linq.Dynamic.Core;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : CustomBaseController
    {
        private readonly Negocio negocio;
        private readonly IMapper mapper;
        private readonly IFilesService filesService;
        private readonly ILogger logger;
        private static readonly string carpeta = "pelicula";

        public PeliculasController(Negocio negocio, IMapper mapper, IFilesService filesService, ILogger logger) :base(negocio , mapper) 
        {
            this.negocio = negocio;
            this.mapper = mapper;
            this.filesService = filesService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaPeliculaDTO>>> Get()
        {
           return await GetBase<Pelicula,  LecturaPeliculaDTO>();
        }

        [HttpGet("{id:int}", Name = "PeliculaPorId")]
        public async Task<ActionResult<LecturaPeliculaDTO>> GetById(int id)
        {
           return await GetIdBase<Pelicula, LecturaPeliculaDTO>(id);
        }

        [HttpGet("filtro")]
        public async Task<List<LecturaPeliculaDTO>> GetFiltrado([FromQuery] FiltroPeliculasDTO filtroPeliculasDTO)
        {
            var query = negocio.Peliculas.AsQueryable();

            if(!string.IsNullOrEmpty(filtroPeliculasDTO.Titulo)) 
                query = query.Where(x => x.Titulo.Contains(filtroPeliculasDTO.Titulo));
            if(filtroPeliculasDTO.EnCines)
                query = query.Where(x => x.EnCines == true);
            if (filtroPeliculasDTO.Estrenos)
                query = query.Where(x => x.Estreno > DateTime.Today);
            if (filtroPeliculasDTO.GeneroId != 0) 
                query = query.Where(x => x.ListGeneros!.Select(y => y.GeneroId).Contains(filtroPeliculasDTO.GeneroId));

            if(!string.IsNullOrEmpty(filtroPeliculasDTO.CampoOrdenar))
            {
                try
                {
                    if (filtroPeliculasDTO.Ascendente) query = query.OrderBy($"{filtroPeliculasDTO.CampoOrdenar} ascending");
                    else query = query.OrderBy($"{filtroPeliculasDTO.CampoOrdenar} descending");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message, ex);
                }
            }

            await HttpContext.InsertarRegistrosTotalesBDCabecera(query);
            var list = await query.Paginar(filtroPeliculasDTO.PaginacionDTO).ToListAsync();
            return mapper.Map<List<LecturaPeliculaDTO>>(list);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CrearPeliculaDTO crearPeliculaDTO)
        {
            if (crearPeliculaDTO.Poster == null) return BadRequest();
            var pelicula = mapper.Map<Pelicula>(crearPeliculaDTO);

            pelicula.Poster = await filesService.GuardarImagen(carpeta, crearPeliculaDTO.Poster!);
            negocio.Add(pelicula);
            await negocio.SaveChangesAsync();
            var lectura = mapper.Map<LecturaPeliculaDTO>(pelicula);
            return CreatedAtRoute("PeliculaPorId", new { id = pelicula.Id }, lectura);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearPeliculaDTO crearPeliculaDTO, int id)
        {
            var peliculaBD = await negocio.Peliculas.FirstOrDefaultAsync(x => x.Id == id);
            if (peliculaBD == null) return NotFound();
            peliculaBD = mapper.Map(crearPeliculaDTO, peliculaBD);
            if (crearPeliculaDTO.Poster is not null) 
                peliculaBD!.Poster = await filesService.Editar(peliculaBD.Poster, carpeta, crearPeliculaDTO.Poster);

            negocio.Update(peliculaBD!);
            await negocio.SaveChangesAsync();
            return NoContent();
        }
    }
}
