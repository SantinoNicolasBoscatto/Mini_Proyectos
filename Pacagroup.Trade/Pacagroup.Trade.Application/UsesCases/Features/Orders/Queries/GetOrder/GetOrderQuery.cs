using MediatR;


namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetOrder
{
    public sealed record GetOrderQuery : IRequest<GetOrderResponseDTO>
    {
        public int Id { get; init; }
    }
}
