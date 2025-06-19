using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Utilidades;
using System.Linq.Dynamic.Core;

namespace MinimalAPIpeliculas.Repositorio
{
    public interface IPeliculasService
    {
        Task Borrar(int id);
        Task<int> Crear(Pelicula pelicula);
        Task EditarActor(int id, List<ActoresPeliculas> actoresPelicula);
        Task EditarGenero(int id, List<int> generosIds);
        Task<bool> Existe(int id);
        Task<List<Pelicula>> ListPeliculas(PaginacionDTO paginacionDTO);
        Task Modificar(Pelicula pelicula);
        Task<Pelicula?> ObtenerPeliculaPorId(int id);
        Task<List<Pelicula>> Filtrar(PeliculasFiltrarDTO peliculasFiltrarDTO);

    }
    public class PeliculasService : IPeliculasService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<PeliculasService> logger;
        private readonly HttpContext httpContext;

        public PeliculasService(ApplicationDbContext dbContext, IHttpContextAccessor accessor, IMapper mapper, 
            ILogger<PeliculasService> logger)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.logger = logger;
            httpContext = accessor.HttpContext!;
        }

        public async Task<List<Pelicula>> ListPeliculas(PaginacionDTO paginacionDTO)
        {
           var query = dbContext.Peliculas.AsQueryable();
           await httpContext.InsertarParametrosPaginacionEnCabecera(query);
           return await query.Paginar(paginacionDTO).ToListAsync();
        }

        public async Task<Pelicula?> ObtenerPeliculaPorId(int id)
        {
            var r = await dbContext.Peliculas.Include(x => x.ListaComentarios)
                .Include(x => x.ListaGenerosPeliculas).ThenInclude(x => x.Genero)
                .Include(x => x.ListaPeliculaActor.OrderBy(y => y.Orden)).ThenInclude(x => x.Actor)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            return r;
        }

        public async Task<int> Crear(Pelicula pelicula)
        {
            dbContext.Add(pelicula);
            await dbContext.SaveChangesAsync();
            return pelicula.Id;
        }

        public async Task Modificar(Pelicula pelicula)
        {
            dbContext.Update(pelicula);
            await dbContext.SaveChangesAsync();
        }

        public async Task Borrar(int id)
        {
            await dbContext.Peliculas.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<bool> Existe(int id)
        {
            return await dbContext.Peliculas.AnyAsync(x => x.Id == id);
        }

        public async Task EditarGenero(int id, List<int> generosIds)
        {
            var pelicula = await dbContext.Peliculas.Include(x => x.ListaGenerosPeliculas).FirstOrDefaultAsync(x => x.Id == id);
            if (pelicula is null) throw new ArgumentException($"No Existe Pelicula con el Id {id}");

            var generosPeliculas = generosIds.Select(generoId => new GeneroPelicula() { GeneroId = generoId });
            pelicula.ListaGenerosPeliculas = mapper.Map(generosPeliculas, pelicula.ListaGenerosPeliculas);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditarActor(int id, List<ActoresPeliculas> actoresPelicula)
        {
            for (int i = 0; i < actoresPelicula.Count; i++) 
            {
                actoresPelicula[i].Orden = i;
            }
            var pelicula = await dbContext.Peliculas.Include(x => x.ListaPeliculaActor).FirstOrDefaultAsync(x => x.Id == id);
            if (pelicula is null) throw new ArgumentException($"No Existe Pelicula con el Id {id}");

            pelicula.ListaPeliculaActor = mapper.Map(actoresPelicula, pelicula.ListaPeliculaActor);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Pelicula>> Filtrar(PeliculasFiltrarDTO peliculasFiltrarDTO)
        {
            var peliculasQueryables = dbContext.Peliculas.AsQueryable();
            if(!string.IsNullOrEmpty(peliculasFiltrarDTO.Titulo))
            {
                peliculasQueryables  = peliculasQueryables.Where(x => x.Titulo.ToLower().Contains(peliculasFiltrarDTO.Titulo.ToLower()));
            }

            if (peliculasFiltrarDTO.EnCines)
            {
                peliculasQueryables = peliculasQueryables.Where(x => x.EnCines == true);
            }

            if (peliculasFiltrarDTO.ProximosEstrenos)
            {
                var hoy = DateTime.Today;
                peliculasQueryables = peliculasQueryables.Where(x => x.FechaLanzamiento > hoy);
            }

            if(peliculasFiltrarDTO.GeneroId != 0)
            {
                peliculasQueryables = peliculasQueryables.Where(x =>
                x.ListaGenerosPeliculas.Select(gp => gp.GeneroId).Contains(peliculasFiltrarDTO.GeneroId));
            }

            if(!string.IsNullOrEmpty(peliculasFiltrarDTO.CampoOrdenar))
            {
                var tipoOrden = peliculasFiltrarDTO.OrdenAscendente ? "ascending" : "descending";
                try
                {
                    peliculasQueryables = peliculasQueryables.OrderBy($"{peliculasFiltrarDTO.CampoOrdenar} {tipoOrden}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message, ex);
                }
            }

            await httpContext.InsertarParametrosPaginacionEnCabecera(peliculasQueryables);
            var peliculas = await peliculasQueryables.Paginar(peliculasFiltrarDTO.PaginacionDTO).ToListAsync();
            return peliculas;
        }
    }
}
