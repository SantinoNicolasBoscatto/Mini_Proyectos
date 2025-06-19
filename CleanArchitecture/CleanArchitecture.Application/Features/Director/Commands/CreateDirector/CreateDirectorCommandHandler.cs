using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Director.Commands.CreateDirector
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CreateDirectorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var director = mapper.Map<CleanArchitecture.Domain.Director>(request);
            var repository = unitOfWork.Repository<CleanArchitecture.Domain.Director>();

            repository.AddEntity(director);
            var result = await unitOfWork.Complete();
            unitOfWork.Dispose();

            if (result <= 0) throw new Exception("Error al insertar Record");

            return director.Id;
        }
    }
}
