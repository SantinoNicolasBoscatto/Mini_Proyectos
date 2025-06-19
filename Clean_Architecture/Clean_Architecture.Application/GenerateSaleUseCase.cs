using Clean_Architecture.Application.Exceptions;
using Clean_Architecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application
{
    public class GenerateSaleUseCase<TDTO>
    {
        private readonly IRepository<Sale> _repo;
        private readonly IMapper<TDTO, Sale> mapper;
        public GenerateSaleUseCase(IRepository<Sale> repo, IMapper<TDTO, Sale> mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }

        public async Task ExecuteAsync(TDTO dto)
        {
            var sale = mapper.ToEntity(dto);
            if (sale.Concepts.Count == 0) throw new ValidationException();
            if (sale.Total <= 0) throw new ValidationException();
            await _repo.AddAsync(sale);
        }
    }
}
