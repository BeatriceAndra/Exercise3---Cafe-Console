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
            ValidateArguments(description);

            OrderId = orderId;
            At = at;
            Description = description;
            Subtotal = subtotal;
            Total = total;
        }

        private static void ValidateArguments(string description)
        {
            if (description == null)
                throw new ArgumentNullException(nameof(description));
        }

    }
}

