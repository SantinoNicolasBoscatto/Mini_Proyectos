using MinimalAPIpeliculas.Entitys;

namespace MinimalAPIpeliculas.Repositorio
{
    public class ErroresService : IErroresService
    {
        private readonly ApplicationDbContext dbContext;

        public ErroresService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Crear(Error error)
        {
            dbContext.Add(error);
            await dbContext.SaveChangesAsync();
        }
    }
}
