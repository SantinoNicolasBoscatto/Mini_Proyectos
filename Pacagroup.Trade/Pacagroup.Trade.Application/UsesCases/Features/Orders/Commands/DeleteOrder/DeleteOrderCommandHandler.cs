using MediatR;
using Pacagroup.Trade.Application.Interfaces.Persistence;

namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IApplicationDbContext context;
        public DeleteOrderCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FindAsync(request.Id);
            if (order == null) throw new Exception("Not found");
            context.Orders.Remove(order);
            if(await context.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}
