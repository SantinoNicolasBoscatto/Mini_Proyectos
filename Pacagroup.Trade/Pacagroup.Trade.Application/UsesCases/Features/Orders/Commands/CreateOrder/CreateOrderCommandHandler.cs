using MediatR;
using AutoMapper;
using Pacagroup.Trade.Application.Interfaces.Persistence;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext context;

        public CreateOrderCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = mapper.Map<Order>(request);
            await context.Orders.AddAsync(order, cancellationToken);

            if(await context.SaveChangesAsync(cancellationToken) > 0) return true;
            return false;
        }
    }
}
