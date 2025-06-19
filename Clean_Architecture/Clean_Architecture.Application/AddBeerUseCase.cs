using Clean_Architecture.Application.Exceptions;
using Clean_Architecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application
{
    public class AddBeerUseCase<TDTO>
    {
        private readonly IRepository<Beer> repository;
        private readonly IMapper<TDTO,Beer> mapper;
        public AddBeerUseCase(IRepository<Beer> repository, IMapper<TDTO, Beer> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task ExecuteAsync(TDTO dto)
        {
            var entity = mapper.ToEntity(dto);
            if (string.IsNullOrEmpty(entity.Name)) throw new ValidationException();
            await repository.AddAsync(entity);
        }
    }
}
