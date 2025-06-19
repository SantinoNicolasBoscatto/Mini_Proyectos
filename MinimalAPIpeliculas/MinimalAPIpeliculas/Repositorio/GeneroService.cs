using Microsoft.EntityFrameworkCore;
using MinimalAPIpeliculas.Entitys;

namespace MinimalAPIpeliculas.Repositorio
{
    public interface IGeneroService
    {
        Task BorrarGenero(int id);
        Task<bool> Existe(int id);
        Task<bool> ExisteGeneroNombre(int id, string nombre);
        Task<List<int>> ExistenListado(List<int> Ids);
        Task<Genero?> GeneroPorId(int id);
        Task<int> InsertarGeneros(Genero genero);
        Task<List<Genero>> ListGeneros();
        Task<int> Modificar(Genero genero);
    }
    public class GeneroService : IGeneroService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public GeneroService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<Genero>> ListGeneros() => 
            await applicationDbContext.Generos.AsNoTracking().OrderBy(x => x.Nombre).ToListAsync();
        public async Task<Genero?> GeneroPorId(int id)
        {
            var genero = await applicationDbContext.Generos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if(genero == null) return null;
            return genero;
        }
        public async Task<int> InsertarGeneros(Genero genero) 
        {
            try
            {
                await applicationDbContext.Generos.AddAsync(genero);
                var r = await applicationDbContext.SaveChangesAsync();
                return genero.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Existe(int id)
        {
            return await applicationDbContext.Generos.AnyAsync(x => x.Id == id);
        }
        public async Task<int> Modificar(Genero genero)
        {
            applicationDbContext.Generos.Update(genero);
            var r = await applicationDbContext.SaveChangesAsync();
            return r;
        }

        public async Task BorrarGenero(int id)
        {
             await applicationDbContext.Generos.Where(x => x.Id==id).ExecuteDeleteAsync();
        }

        public async Task<List<int>> ExistenListado(List<int> Ids)
        {
            return await applicationDbContext.Generos.Where(g => Ids.Contains(g.Id)).Select(g => g.Id).ToListAsync();
        }

        public async Task<bool> ExisteGeneroNombre(int id,string nombre)
        {
            return await applicationDbContext.Generos.AnyAsync(x => x.Id != id && x.Nombre.ToLower() == nombre.ToLower());
        }
    }
}
