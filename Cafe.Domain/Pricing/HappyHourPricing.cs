namespace Cafe.Domain.Pricing
{
    public class HappyHourPricing : IPricingStrategy
    {
        private const decimal DiscountRate = 0.20m;

        public decimal Apply(decimal subtotal)
        {
            if (subtotal < 0)
                throw new ArgumentOutOfRangeException("Subtotal cannot be negative.");
            var discounted = subtotal * (1 - DiscountRate);
            return Math.Round(discounted, 2);
        }
    }
}
