namespace Cafe.Domain.Events
{
    public interface IOrderEventSubscriber
    {
        void On(OrderPlaced evt);
    }
}
