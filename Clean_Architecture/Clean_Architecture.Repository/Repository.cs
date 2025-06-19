using Clean_Architecture.Application;
using Clean_Architecture.Domain;
using Clean_Architecture.Infrastructure;
using Clean_Architecture.Models;
using Microsoft.EntityFrameworkCore;


namespace Clean_Architecture.Repository
{
    public class Repository : IRepository<Beer>
    {
        private readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Beer beer)
        {
            var model = new BeerModel()
            {
                Id = beer.Id,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                Style = beer.Style
            };
            await _appDbContext.Beers.AddAsync(model);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Beer>> GeAllAsync()
        {
            return await _appDbContext.Beers.Select(x => new Beer()
            {
                Id = x.Id,
                Name = x.Name,
                Alcohol = x.Alcohol,
                Style = x.Style
            }).AsNoTracking().ToListAsync();
        }

        public async Task<Beer> GetByIdAsync(int id)
        {
            return await _appDbContext.Beers.Select(x => new Beer
            {
                Id = x.Id,
                Name = x.Name,
                Alcohol = x.Alcohol,
                Style = x.Style
            }).AsNoTracking().FirstAsync(x => x.Id == id);
        }
    }
}
