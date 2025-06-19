using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.OpenApi.Models;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Filtros;
using MinimalAPIpeliculas.Repositorio;
using MinimalAPIpeliculas.Servicios;
using MinimalAPIpeliculas.Utilidades;

namespace MinimalAPIpeliculas.Endpoints
{
    public static class ActoresEndPoints
    {

        private static readonly string contenedor = "actores";

        public static RouteGroupBuilder MapActores(this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerActores).AgregarParametrosPaginacionOpenAPI();
            group.MapGet("/{id:int}", ObtenerActorPorId);
            group.MapGet("obtenerPorNombre/{nombre}", ActorFiltrado);

            group.MapPost("/", AgregarActor).DisableAntiforgery()
                .AddEndpointFilter<FiltroValidaciones<CrearActorDTO>>().WithOpenApi();



            group.MapPut("/{id:int}", ModificarActor).DisableAntiforgery().WithOpenApi(opt =>
            {
                opt.Summary = "Actualizar un actor";
                opt.Description = "";
                opt.Parameters[0].Description = "El Id del actor";
                opt.RequestBody.Description = "El Actor a Actualizar";
                return opt;
            });



            group.MapDelete("/{id:int}", EliminarActor);
            return group;
        }

        private static async Task<Ok<List<LecturaActoresDTO>>> ObtenerActores
            (IActoresService actoresService, IMapper mapper, ILoggerFactory loggerFactory, PaginacionDTO paginacionDTO)
        {
            var tipo = typeof(ActoresEndPoints);
            var logger = loggerFactory.CreateLogger(tipo.FullName!);
            logger.LogInformation("Obtengo Generos");

            var actores = await actoresService.ListActores(paginacionDTO);
            var actoresDTO = mapper.Map<List<LecturaActoresDTO>>(actores);
            return TypedResults.Ok(actoresDTO);
        }
        private static async Task<Results<Ok<LecturaActoresDTO>, NotFound>> ObtenerActorPorId(IActoresService actoresService, int id, IMapper mapper)
        {
            var actor = await actoresService.ActorPorId(id);
            if (actor == null) return TypedResults.NotFound();
            var actorDTO = mapper.Map<LecturaActoresDTO>(actor);
            return TypedResults.Ok(actorDTO);
        }
        private static async Task<Results<Created<LecturaActoresDTO>, ValidationProblem>> AgregarActor
            (IActoresService actoresService, [FromForm] CrearActorDTO actorDTO, IMapper mapper, IFilesService filesService)
        {
            var actor = mapper.Map<Actor>(actorDTO);

            if(actorDTO.Foto is not null)
            {
                var URL = await filesService.GuardarImagen(contenedor, actorDTO.Foto);
                actor.Foto = URL;
            }

            var id = await actoresService.AgregarActor(actor);
            var lecturaActor = mapper.Map<LecturaActoresDTO>(actor);
            return TypedResults.Created($"/actores/{id}", lecturaActor);
        }






        private static async Task<Results<NoContent, NotFound>> ModificarActor
            (int id, [FromForm] CrearActorDTO modificarActorDTO, IActoresService actoresService, IMapper mapper, 
            IOutputCacheStore cache, IFilesService filesService)
        {
            var actorDB = await actoresService.ActorPorId(id);
            if (actorDB is null) return TypedResults.NotFound();
            var actorActualizar = mapper.Map<Actor>(modificarActorDTO);
            actorActualizar.Id = id;
            actorActualizar.Foto = actorDB.Foto;

            if(modificarActorDTO.Foto is not null)
            {
                var url = await filesService.Editar(actorActualizar.Foto, contenedor, modificarActorDTO.Foto);
                actorActualizar.Foto = url;
            }
            await actoresService.ModificarActor(actorActualizar);
            await cache.EvictByTagAsync("",default);
            return TypedResults.NoContent();
        }







        private static async Task<Results<NoContent, NotFound>> EliminarActor
            (int id, IActoresService actoresService, IFilesService filesService)
        {
            var actor = await actoresService.ActorPorId(id);
            if (actor is null) return TypedResults.NotFound();
            await filesService.Borrar(actor.Foto, contenedor);
            await actoresService.BorrarActor(id);
            return TypedResults.NoContent();
        }










        private static async Task<Results<Ok<List<LecturaActoresDTO>>, NotFound>> ActorFiltrado
            (IActoresService actoresService, IMapper mapper, string name)
        {
            var list = await actoresService.ListActoresFiltrados(name);
            if(list.Count == 0) return TypedResults.NotFound();
            var listDTO = mapper.Map<List<LecturaActoresDTO>>(list);
            return TypedResults.Ok(listDTO);
        }
    }
}
