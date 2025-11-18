namespace Cafe.Domain.Pricing
{
    public interface IPricingStrategy
    {
        decimal Apply(decimal subtotal);
    }
}

