using Clean_Architecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application
{
    // UseCase de esta busqueda filtrada flexible
    public class GetSalesSearchUseCases<TModel>
    {
        private readonly IRepositorySearch<TModel, Sale> repository;
        public GetSalesSearchUseCases(IRepositorySearch<TModel, Sale> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Sale>> ExecuteAsync(Expression<Func<TModel, bool>> predicate)
        {
           return await repository.GetFiltrado(predicate);
        }
    }
}
