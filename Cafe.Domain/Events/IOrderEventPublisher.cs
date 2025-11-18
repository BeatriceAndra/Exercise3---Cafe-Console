namespace Cafe.Domain.Events
{
    public interface IOrderEventPublisher
    {
        void Publish(OrderPlaced evt);
        void Subscribe(IOrderEventSubscriber subscriber);
        void Unsubscribe(IOrderEventSubscriber subscriber);
    }
}

