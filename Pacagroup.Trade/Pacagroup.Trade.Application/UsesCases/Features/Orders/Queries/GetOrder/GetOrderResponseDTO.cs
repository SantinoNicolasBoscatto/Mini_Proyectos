
using Pacagroup.Trade.Domain.Enums;

namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetOrder
{
    public class GetOrderResponseDTO
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
