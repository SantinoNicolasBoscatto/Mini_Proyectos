using Clean_Architecture.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application
{
    public class GetSalesUseCase
    {
        private readonly IRepository<Sale> repository;

        public GetSalesUseCase(IRepository<Sale> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Sale>> ExecuteAsync() => await repository.GeAllAsync();

    }
}
