namespace Pacagroup.Trade.Domain.Commons
{
    public abstract class BaseEvent
    {
        public Guid MessageId { get; set; }
        public DateTime PusblishTime { get; set; }
    }
}
