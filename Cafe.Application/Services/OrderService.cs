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
            ValidateArguments(pricingStrategy, eventPublisher);

            this.pricingStrategy = pricingStrategy;
            this.eventPublisher = eventPublisher;
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

        private static void ValidateArguments(IPricingStrategy pricingStrategy, IOrderEventPublisher eventPublisher)
        {
            if (pricingStrategy == null)
                throw new ArgumentNullException(nameof(pricingStrategy));
            if (eventPublisher == null)
                throw new ArgumentNullException(nameof(eventPublisher));
        }

    }
}

