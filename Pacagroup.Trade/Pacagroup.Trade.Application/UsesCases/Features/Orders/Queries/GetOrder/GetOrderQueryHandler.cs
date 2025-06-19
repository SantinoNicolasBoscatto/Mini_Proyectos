using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interfaces.Persistence;

namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, GetOrderResponseDTO>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext context;
        public GetOrderQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<GetOrderResponseDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (order == null) throw new Exception("Not found");

            var response = mapper.Map<GetOrderResponseDTO>(order);
            return response;
        }
    }
}
