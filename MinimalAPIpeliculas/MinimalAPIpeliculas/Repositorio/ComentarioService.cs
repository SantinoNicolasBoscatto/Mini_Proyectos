using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Utilidades;
using System.Net.Http;

namespace MinimalAPIpeliculas.Repositorio
{
    public interface IComentarioService
    {
        Task Actualizar(Comentario comentario);
        Task<int> AgregarComentario(Comentario comentario);
        Task Borrar(int id);
        Task<bool> Existe(int id);
        Task<Comentario?> ObtenerPorId(int id);
        Task<List<Comentario>> ObtenerTodos(int peliculaId, PaginacionDTO paginacionDTO);
        Task<bool> ExistePelicula(int peliculaId);
    }
    public class ComentarioService : IComentarioService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly HttpContext httpContext;

        public ComentarioService(ApplicationDbContext dbContext, IHttpContextAccessor accessor)
        {
            this.dbContext = dbContext;
            this.httpContext = accessor.HttpContext!;
        }

        public async Task<List<Comentario>> ObtenerTodos(int peliculaId, PaginacionDTO paginacionDTO)
        {
            var query = dbContext.Comentarios.Where(x => x.PeliculaId == peliculaId).AsQueryable();
            await httpContext.InsertarParametrosPaginacionEnCabecera(query);
            var list = query.Paginar(paginacionDTO).ToList();
            return list;
        }

        public async Task<Comentario?> ObtenerPorId(int id)
        {
            return await dbContext.Comentarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AgregarComentario(Comentario comentario)
        {
            dbContext.Add(comentario);
            await dbContext.SaveChangesAsync();
            return comentario.Id;
        }

        public async Task Actualizar(Comentario comentario)
        {
            dbContext.Update(comentario);
            await dbContext.SaveChangesAsync();
        }

        public async Task Borrar(int id)
        {
            await dbContext.Comentarios.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<bool> Existe(int id) => await dbContext.Comentarios.AnyAsync(x => x.Id == id);

        public async Task<bool> ExistePelicula(int peliculaId) => await dbContext.Peliculas.AnyAsync(x => x.Id == peliculaId);
    }
}
