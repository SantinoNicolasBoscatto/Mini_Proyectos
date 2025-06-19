using Pacagroup.Trade.Domain.Commons;
using Pacagroup.Trade.Domain.Enums;
namespace Pacagroup.Trade.Domain.Events
{
    public class OrderCreatedEvent : BaseEvent
    {
        public string Symbol { get; set; }
        public OrderSide Side { get; set; }
        public DateTime TrasactionTime { get; set; }
        public int Quanty { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }
    }
}
