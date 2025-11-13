namespace Cafe.Domain.Events
{
    public interface IOrderEventPublisher
    {
        void Publish(OrderPlaced evt);
    }
}
