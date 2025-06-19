using Microsoft.EntityFrameworkCore;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Servicios;
using MinimalAPIpeliculas.Utilidades;

namespace MinimalAPIpeliculas.Repositorio
{
    public interface IActoresService
    {
        Task<Actor?> ActorPorId(int id);
        Task<int> AgregarActor(Actor actor);
        Task BorrarActor(int id);
        Task<bool> Existe(int id);
        Task<List<Actor>> ListActores(PaginacionDTO paginacion);
        Task<List<Actor>> ListActoresFiltrados(string nombre);
        Task ModificarActor(Actor actor);
    }
    public class ActoresService : IActoresService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IFilesService filesService;
        private readonly HttpContext httpContext;

        public ActoresService
            (ApplicationDbContext applicationDbContext, IFilesService filesService, IHttpContextAccessor accessor)
        {
            this.applicationDbContext = applicationDbContext;
            this.filesService = filesService;
            httpContext = accessor.HttpContext!;
        }

        public async Task<List<Actor>> ListActores(PaginacionDTO paginacion)
        {
            var query = applicationDbContext.Actores.AsQueryable();
            await httpContext.InsertarParametrosPaginacionEnCabecera(query);       
            return await query.Paginar(paginacion).ToListAsync();
        }
        public async Task<Actor?> ActorPorId(int id)
        {
            var actor = await applicationDbContext.Actores.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return actor;
        }
        public async Task<int> AgregarActor(Actor actor)
        {
            applicationDbContext.Actores.Add(actor);
            await applicationDbContext.SaveChangesAsync();
            return actor.Id;
        }
        public async Task ModificarActor(Actor actor)
        {
            applicationDbContext.Update(actor);
            await applicationDbContext.SaveChangesAsync();
        }
        public async Task BorrarActor(int id)
        {
            await applicationDbContext.Actores.Where(x => x.Id == id).ExecuteDeleteAsync();
        }


        public async Task<List<Actor>> ListActoresFiltrados(string nombre)
        {
            return await applicationDbContext.Actores.Where(x => x.Nombre.ToUpper().Contains(nombre.ToUpper())).ToListAsync();
        }


        public async Task<bool> Existe(int id) => await applicationDbContext.Actores.AnyAsync(x => x.Id == id);

        public async Task<List<int>> ExistenActores(List<int> ids)
        {
            return await applicationDbContext.Actores.Where(x => ids.Contains(x.Id)).Select(x => x.Id).ToListAsync();
        }

        
    }
}
