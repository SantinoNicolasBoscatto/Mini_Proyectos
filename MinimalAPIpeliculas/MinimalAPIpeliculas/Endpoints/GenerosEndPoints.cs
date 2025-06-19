using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Filtros;
using MinimalAPIpeliculas.Repositorio;

namespace MinimalAPIpeliculas.Endpoints
{
    public static class GenerosEndPoints
    {
        public static RouteGroupBuilder MapGeneros(this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerGeneros).CacheOutput(c => c.Expire(TimeSpan.FromSeconds(100)).Tag("GenerosCache"));

            group.MapGet("/{id:int}", ObtenerPorId);
            group.MapPost("/", async (CrearGeneroDTO crearGeneroDTO, IGeneroService generoService, IOutputCacheStore cache, 
                IMapper mapper) =>
            {

                var genero = mapper.Map<Genero>(crearGeneroDTO);
                var id = await generoService.InsertarGeneros(genero);
                await cache.EvictByTagAsync("GenerosCache", default);
                var lecturaGenero = mapper.Map<LecturaGeneroDTO>(genero);
                return Results.Created($"/generos/{id}", lecturaGenero);
            }).AddEndpointFilter<FiltroValidaciones<CrearGeneroDTO>>();
            group.MapPut
                ("/{id:int}", async (int id, Genero genero, IGeneroService generoService, IOutputCacheStore cache) =>
                {
                    if (!await generoService.Existe(id)) return Results.NotFound();
                    var r = await generoService.Modificar(genero);
                    await cache.EvictByTagAsync("GenerosCache", default);
                    return Results.NoContent();
                });
            group.MapDelete("/{id:int}", async (int id, IGeneroService generoService, IOutputCacheStore cache) =>
            {
                if (!await generoService.Existe(id)) return Results.NotFound();
                await generoService.BorrarGenero(id);
                await cache.EvictByTagAsync("GenerosCache", default);
                return Results.NoContent();
            }).RequireAuthorization("esadmin");
            return group;
        }

        static async Task<Ok<List<Genero>>> ObtenerGeneros(IGeneroService generoService)
        {
            var generos = await generoService.ListGeneros();
            return TypedResults.Ok(generos);
        }

        static async Task<Results<Ok<Genero>, NotFound>> ObtenerPorId(IGeneroService generoService, int id)
        {
            var genero = await generoService.GeneroPorId(id);

            if (genero is null) return TypedResults.NotFound();

            return TypedResults.Ok(genero);
        }
    }
}
