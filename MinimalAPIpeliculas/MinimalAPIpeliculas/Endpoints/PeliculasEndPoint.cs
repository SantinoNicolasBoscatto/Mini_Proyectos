using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Repositorio;
using MinimalAPIpeliculas.Servicios;
using MinimalAPIpeliculas.Utilidades;

namespace MinimalAPIpeliculas.Endpoints
{
    public static class PeliculasEndPoint
    {
        private static readonly string contenedor = "Peliculas";
        public static RouteGroupBuilder MapPeliculas(this RouteGroupBuilder builder)
        {
            builder.MapPost("/", AgregarPelicula).DisableAntiforgery();
            builder.MapPut("/{id:int}", ActualizarPelicula).DisableAntiforgery();
            builder.MapGet("/", ListaPeliculas);
            builder.MapGet("/{id:int}", PeliculaPorId);
            builder.MapPost("/{id:int}/asignargeneros", AsignarGeneros);
            builder.MapPost("/{id:int}/asignaractores", AsignarActores);

            builder.MapGet("/filtrado", Filtrar).AgregarParametrosFiltradoPeliculasOpenAPI();

            return builder;
        }

        static async Task<Ok<List<LecturaPeliculaDTO>>> ListaPeliculas
            (IPeliculasService peliculasService, IMapper mapper, int pagina = 1, int records = 10)
        {
            var paginacionDTO = new PaginacionDTO { Pagina = pagina, RecordsPorPagina = records };
            var listaPeliculas = await peliculasService.ListPeliculas(paginacionDTO);
            var lecturaList = mapper.Map<List<LecturaPeliculaDTO>>(listaPeliculas);
            return TypedResults.Ok(lecturaList);
        }

        static async Task<Results<Ok<LecturaPeliculaDTO>, NotFound>> PeliculaPorId
            (IPeliculasService peliculasService, IMapper mapper, int id)
        {
            var pelicula = await peliculasService.ObtenerPeliculaPorId(id);
            if (pelicula == null) return TypedResults.NotFound();
            var lecturapelicula = mapper.Map<LecturaPeliculaDTO>(pelicula);
            return TypedResults.Ok(lecturapelicula);
        }

        static async Task<Created<LecturaPeliculaDTO>> AgregarPelicula
            (IPeliculasService peliculasService, [FromForm] CrearPeliculaDTO crearPeliculaDTO,  IMapper mapper, IFilesService filesService)
        {
            var pelicula = mapper.Map<Pelicula>(crearPeliculaDTO);
            if (crearPeliculaDTO.Poster is not null)
            {
               var url = await filesService.GuardarImagen(contenedor, crearPeliculaDTO.Poster);
                pelicula.Poster = url;
            }
            var id = await peliculasService.Crear(pelicula);
            pelicula.Id = id;
            var lecturaPelicula = mapper.Map<LecturaPeliculaDTO>(pelicula);
            return TypedResults.Created($"/peliculas/{id}", lecturaPelicula);
        }

        static async Task<Results<NoContent, NotFound>> ActualizarPelicula
            (int id, [FromForm] CrearPeliculaDTO crearPeliculaDTO, IPeliculasService peliculasService, IMapper mapper, IFilesService filesService)
        {
            var peliculaBD = await peliculasService.ObtenerPeliculaPorId(id);
            if (peliculaBD is null) return TypedResults.NotFound();
            var pelicula = mapper.Map<Pelicula>(crearPeliculaDTO);
            pelicula.Id = id;
            if (crearPeliculaDTO.Poster != null)
            {
                var url = await filesService.Editar(peliculaBD.Poster , contenedor, crearPeliculaDTO.Poster);
                pelicula.Poster = url;
            }
            await peliculasService.Modificar(pelicula);
            return TypedResults.NoContent();
        }


        static async Task<Results<NoContent, NotFound>> BorrarPelicula(int id, IPeliculasService peliculasService, IFilesService filesService)
        {
            var peliBD = await peliculasService.ObtenerPeliculaPorId(id);
            if(peliBD is null) return TypedResults.NotFound();
            await peliculasService.Borrar(id);
            await filesService.Borrar(peliBD.Poster, contenedor);
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, BadRequest<string>, NotFound>> AsignarGeneros(int id, List<int> listadoGeneros, 
            IPeliculasService peliculasService, IGeneroService generoService)
        {
            if(! await peliculasService.Existe(id)) return TypedResults.NotFound();
            var generosExistentes = new List<int>();
            if (listadoGeneros.Count != 0)
            {
                generosExistentes = await generoService.ExistenListado(listadoGeneros);
            }

            if(listadoGeneros.Count != generosExistentes.Count)
            {
                var noExisten = listadoGeneros.Except(listadoGeneros);
                return TypedResults.BadRequest($"Los generos de id {string.Join(",", noExisten)} no existen");
            }

            await peliculasService.EditarGenero(id, listadoGeneros);
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, BadRequest<string>, NotFound>> AsignarActores(int id, 
            List<AsignarActorPeliculaDTO> actorDTO, IPeliculasService peliculasService, IActoresService actoresService, IMapper mapper)
        {
            if (!await peliculasService.Existe(id)) return TypedResults.NotFound();

            var listActor = mapper.Map<List<ActoresPeliculas>>(actorDTO);
            await peliculasService.EditarActor(id, listActor);
            return TypedResults.NoContent();
        }

        static async Task<Ok<List<LecturaPeliculaDTO>>> Filtrar(PeliculasFiltrarDTO peliculasFiltrarDTO, IPeliculasService peliculasService,
            IMapper mapper)
        {
            var peliculas = await peliculasService.Filtrar(peliculasFiltrarDTO);
            var listPeliculasDTO = mapper.Map<List<LecturaPeliculaDTO>>(peliculasFiltrarDTO);
            return TypedResults.Ok(listPeliculasDTO);
        }
    }
}
