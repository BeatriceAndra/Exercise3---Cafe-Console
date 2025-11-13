using Cafe.Domain.Pricing;
using Xunit;

public class PricingStrategyTests
{
    [Fact]
    public void RegularPricing_ReturnsSameSubtotal()
    {
        var strategy = new RegularPricing();
        Assert.Equal(10.00m, strategy.Apply(10.00m));
    }

    [Fact]
    public void HappyHourPricing_Applies20PercentDiscount()
    {
        var strategy = new HappyHourPricing();
        Assert.Equal(8.00m, strategy.Apply(10.00m));
    }
}
