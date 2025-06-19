using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interfaces.Persistence;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext context;
        public UpdateOrderCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (order == null) throw new Exception("Not found");
             mapper.Map(request, order);
            context.Orders.Update(order);
            if(await context.SaveChangesAsync(cancellationToken) > 0) return true;
            return false;
        }
    }
}
