using Cafe.Domain.Events;

namespace Cafe.Infrastructure.Observers
{
    public class ConsoleOrderLogger : IOrderEventSubscriber
    {
        public void On(OrderPlaced evt)
        {
            Console.WriteLine($@"
                Order {evt.OrderId} placed at {evt.At}
                Items: {evt.Description}
                Subtotal: {evt.Subtotal:C}
                Total: {evt.Total:C}");
        }
    }
}

