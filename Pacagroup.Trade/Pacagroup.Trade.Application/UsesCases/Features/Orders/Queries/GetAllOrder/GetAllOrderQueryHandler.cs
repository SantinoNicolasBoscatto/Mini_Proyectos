using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interfaces.Persistence;

namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<GetAllOrderResponseDTO>>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext context;
        public GetAllOrderQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<GetAllOrderResponseDTO>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .ProjectTo<GetAllOrderResponseDTO>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return orders;
        }
    }
}
