using Cafe.Domain.Beverages;
using Cafe.Domain.Events;
using Cafe.Domain.Pricing;

namespace Cafe.Application.Services
{
    public class OrderOrchestrator : IOrderOrchestrator
    {
        private readonly IOrderEventPublisher eventPublisher;

        public OrderOrchestrator(IOrderEventPublisher eventPublisher)
        {
            this.eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
        }

        public void PlaceOrder(IBeverage beverage, IPricingStrategy pricingStrategy)
        {
            var service = new OrderService(pricingStrategy, eventPublisher);
            service.PlaceOrder(beverage);
        }
    }
}

