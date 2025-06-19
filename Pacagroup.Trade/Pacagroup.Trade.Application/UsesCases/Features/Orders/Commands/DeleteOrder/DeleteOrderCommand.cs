using MediatR;

namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.DeleteOrder
{
    public sealed record DeleteOrderCommand : IRequest<bool>    
    {
        public int Id { get; init; }
    }
}
