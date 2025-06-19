using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Filtros;
using MinimalAPIpeliculas.Repositorio;

namespace MinimalAPIpeliculas.Endpoints
{
    public static class ComentariosEndPoints
    {
        public static RouteGroupBuilder MapComentarios(this RouteGroupBuilder group)
        {
            group.MapGet("/", ListaComentarios)
                .CacheOutput(c => c.Expire(TimeSpan.FromSeconds(120))
                .Tag("get-comentarios")
                .SetVaryByRouteValue(new string[] {"peliculaId"}));
            group.MapPost("/", CrearComentarios).AddEndpointFilter<FiltroValidaciones<CrearComentarioDTO>>().RequireAuthorization();
            group.MapPut("/{id:int}", ActualizarComentario).RequireAuthorization();
            group.MapDelete("/{id:int}", BorrarComentario);
            return group;
        }

        static async Task<Results<Created<LecturaComentarioDTO>, NotFound>> CrearComentarios
            ([AsParameters] CrearComentariosEndPointDTO parameters)
        {
            if (!await parameters.peliculasService.Existe(parameters.peliculaId)) return TypedResults.NotFound();

            var comentario = parameters.mapper.Map<Comentario>(parameters.crearComentarioDTO);
            comentario.PeliculaId = parameters.peliculaId;

            var usuario = await parameters.usuarioService.ObtenerUsuario();
            if(usuario == null) return TypedResults.NotFound();

            comentario.UsuarioId = usuario.Id;

            var id = await parameters.comentarioService.AgregarComentario(comentario);
            await parameters.cache.EvictByTagAsync("get-comentarios", default);
            var lectura = parameters.mapper.Map<LecturaComentarioDTO>(comentario);
            return TypedResults.Created($"/comentario/{id}", lectura);
        }

        static async Task<Results<Ok<List<LecturaComentarioDTO>>, NotFound>> ListaComentarios
            (int peliculaId, IMapper mapper, IComentarioService comentarioService, int pagina = 1, int records = 10)
        {
            if (!await comentarioService.ExistePelicula(peliculaId)) return TypedResults.NotFound();
            PaginacionDTO paginacionDTO = new PaginacionDTO { Pagina = pagina, RecordsPorPagina = records };

            var listaComentarios = await comentarioService.ObtenerTodos(peliculaId, paginacionDTO);
            var lectura = mapper.Map<List<LecturaComentarioDTO>>(listaComentarios);
            return TypedResults.Ok(lectura);
        }

        static async Task<Results<NoContent, NotFound, ForbidHttpResult>> ActualizarComentario
            (int peliculaId, CrearComentarioDTO crearComentarioDTO,int id, 
            IComentarioService comentarioService, IOutputCacheStore cacheStore, IUsuarioService usuarioService)
        {
            if (!await comentarioService.ExistePelicula(peliculaId) || !await comentarioService.Existe(id)) 
                return TypedResults.NotFound();


            var comentarioBD = await comentarioService.ObtenerPorId(id);
            if(comentarioBD == null) return TypedResults.NotFound();

            var usuario = await usuarioService.ObtenerUsuario();
            if(usuario == null) return TypedResults.NotFound();

            if(comentarioBD.UsuarioId != usuario.Id) return TypedResults.Forbid();

            comentarioBD.Cuerpo = crearComentarioDTO.Cuerpo;
            await comentarioService.Actualizar(comentarioBD);
            await cacheStore.EvictByTagAsync("get-comentarios", default);
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound, ForbidHttpResult>> BorrarComentario
            (int peliculaId, int id, IComentarioService comentarioService, IOutputCacheStore cacheStore, IUsuarioService usuarioService)
        {
            if (!await comentarioService.ExistePelicula(peliculaId) || !await comentarioService.Existe(id))
                return TypedResults.NotFound();

            var comentarioBD = await comentarioService.ObtenerPorId(id);
            if (comentarioBD == null) return TypedResults.NotFound();

            var usuario = await usuarioService.ObtenerUsuario();
            if (usuario == null) return TypedResults.NotFound();
            if (comentarioBD.UsuarioId != usuario.Id) return TypedResults.Forbid();

            await comentarioService.Borrar(id);
            await cacheStore.EvictByTagAsync("get-comentarios", default);
            return TypedResults.NoContent();
        }
    }
}
