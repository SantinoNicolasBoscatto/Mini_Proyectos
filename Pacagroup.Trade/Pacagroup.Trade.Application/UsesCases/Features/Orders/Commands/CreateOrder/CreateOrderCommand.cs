using MediatR;
using Pacagroup.Trade.Domain.Enums;


namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.CreateOrder
{
    public sealed record CreateOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public OrderSide Side { get; set; }
        public DateTime TrasactionTime { get; set; }
        public int Quanty { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        public string? Text { get; set; }
    }
}
