using Cafe.Domain.Events;

namespace Cafe.Infrastructure.Observers
{
    public class InMemoryOrderAnalytics : IOrderEventSubscriber
    {
        public int TotalOrders { get; private set; } = 0;
        public decimal TotalRevenue { get; private set; } = 0m;

        public void On(OrderPlaced evt)
        {
            if (evt == null) return;

            TotalOrders++;
            TotalRevenue += evt.Total;
        }
    }
}
