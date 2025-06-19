using Clean_Architecture.Application;
using Clean_Architecture.Domain;
using Clean_Architecture.Infrastructure;
using Clean_Architecture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Repository
{
    public class SaleRepository : IRepository<Sale>, IRepositorySearch<SaleModel, Sale>
    {
        private readonly AppDbContext _appDbContext;
        public SaleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Sale entity)
        {
            var model = new SaleModel();
            model.Total = entity.Total;
            model.CreationDate = entity.Date;
            model.Concepts = entity.Concepts.Select(x => new ConceptModel
            {
                UnitPrice = x.UnitPrice,
                IdBeer = x.IdBeer,
                Quantity = x.Quantity
            }).ToList();
            await _appDbContext.AddAsync(model);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Sale>> GeAllAsync()
        {
            return await _appDbContext.Sales.Select(x => new Sale(x.CreationDate, 
                _appDbContext.Concepts.Where(y => y.IdSale == x.Id)
                .Select(c => new Concept(c.IdBeer, c.Quantity, c.UnitPrice)).ToList())).ToListAsync();
        }
        public async Task<Sale> GetByIdAsync(int id)
        {
            var saleModel = await _appDbContext.Sales.FindAsync(id);
            return new Sale(saleModel!.CreationDate, _appDbContext.Concepts.Where(x => x.IdSale == saleModel.Id)
                           .Select(c => new Concept(c.IdBeer, c.Quantity, c.UnitPrice)).ToList());
        }

        public async Task<IEnumerable<Sale>> GetFiltrado(Expression<Func<SaleModel, bool>> predicate)
        {
            var salesModel= await _appDbContext.Sales.Include(x => x.Concepts).Where(predicate).ToListAsync();

            var sales = new List<Sale>();

            foreach (var saleModel in salesModel)
            {
                var concepts = new List<Concept>();
                foreach (var item in saleModel.Concepts)
                {
                    concepts.Add(new Concept(item.IdBeer, item.Quantity, item.UnitPrice));
                }
                sales.Add(new Sale(DateTime.Now, concepts));
            }

            return sales;
        }
    }
}
