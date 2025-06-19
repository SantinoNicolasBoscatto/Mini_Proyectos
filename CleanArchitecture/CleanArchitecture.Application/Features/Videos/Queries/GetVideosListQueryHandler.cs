using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries
{
    // Aqui definimos de que clase viene el request (GetVideosListQuery) y que valor devolveremos
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<Video>>
    {
        // Instanciamos un objeto que implemente IVideoRepository
        private readonly IVideoRepository _repository;
        public GetVideosListQueryHandler(IVideoRepository repository)
        {
            _repository = repository;
        }

        // Ejecutamos el Query de lectura
        public async Task<List<Video>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetVideoByUsername(request.Username!);
            return list.ToList();
        }
    }
}
