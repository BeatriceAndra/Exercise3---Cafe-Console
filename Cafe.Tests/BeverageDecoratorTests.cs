using Cafe.Domain.Beverages;
using Xunit;

public class BeverageDecoratorTests
{
    [Fact]
    public void Espresso_WithMilkAndExtraShot_CalculatesCorrectCostAndDescription()
    {
        // Given
        IBeverage beverage = new Espresso();

        // When
        beverage = new MilkDecorator(beverage);
        beverage = new ExtraShotDecorator(beverage);

        // Then
        Assert.Equal(2.50m + 0.40m + 0.80m, beverage.Cost());
        var desc = beverage.Describe().ToLower();
        Assert.Contains("milk", desc);
        Assert.Contains("extra shot", desc);
    }
}
