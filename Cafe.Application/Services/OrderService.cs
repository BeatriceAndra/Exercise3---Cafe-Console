using Cafe.Domain.Beverages;
using Cafe.Domain.Events;
using Cafe.Domain.Pricing;

namespace Cafe.Application.Services
{
    public class OrderService
    {
        private readonly IPricingStrategy pricingStrategy;
        private readonly IOrderEventPublisher eventPublisher;

        public OrderService(IPricingStrategy pricingStrategy, IOrderEventPublisher eventPublisher)
        {
            this.pricingStrategy = pricingStrategy ?? throw new ArgumentNullException(nameof(pricingStrategy));
            this.eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
        }

        public void PlaceOrder(IBeverage beverage)
        {
            if (beverage == null)
                throw new ArgumentNullException(nameof(beverage));

            var subtotal = beverage.Cost();
            var total = pricingStrategy.Apply(subtotal);

            var orderEvent = new OrderPlaced(
                Guid.NewGuid(),
                DateTimeOffset.Now,
                beverage.Describe(),
                subtotal,
                total
            );

            eventPublisher.Publish(orderEvent);
        }
    }
}
