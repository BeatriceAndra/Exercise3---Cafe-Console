using Cafe.Domain.Beverages;
using Cafe.Domain.Pricing;

namespace Cafe.Application.Services
{
    public interface IOrderOrchestrator
    {
        void PlaceOrder(IBeverage beverage, IPricingStrategy pricingStrategy);
    }
}

