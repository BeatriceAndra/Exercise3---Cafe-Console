namespace Cafe.Domain.Pricing
{
    public class RegularPricing : IPricingStrategy
    {
        public decimal Apply(decimal subtotal)
        {
            if (subtotal < 0)
                throw new ArgumentOutOfRangeException(nameof(subtotal), "Subtotal cannot be negative.");
            return subtotal;
        }
    }
}
