using Cafe.Domain.Events;

namespace Cafe.Application.Services
{
    public class SimpleOrderEventPublisher : IOrderEventPublisher
    {
        private readonly List<IOrderEventSubscriber> subscribers = new();

        public void Subscribe(IOrderEventSubscriber subscriber)
        {
            if (subscriber != null)
                subscribers.Add(subscriber);
        }

        public void Publish(OrderPlaced evt)
        {
            foreach (var s in subscribers)
                s.On(evt);
        }
    }
}
