namespace Cafe.Domain.Events
{
    public class OrderPlaced
    {
        public Guid OrderId { get; }
        public DateTimeOffset At { get; }
        public string Description { get; }
        public decimal Subtotal { get; }
        public decimal Total { get; }

        public OrderPlaced(Guid orderId, DateTimeOffset at, string description, decimal subtotal, decimal total)
        {
            OrderId = orderId;
            At = at;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Subtotal = subtotal;
            Total = total;
        }
    }
}
