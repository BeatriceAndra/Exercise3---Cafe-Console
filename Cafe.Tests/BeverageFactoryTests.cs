using System;
using Cafe.Domain.Factories;
using Cafe.Infrastructure.Factories;
using Cafe.Domain.Beverages;
using Xunit;

public class BeverageFactoryTests
{
    private readonly IBeverageFactory factory = new BeverageFactory();

    [Theory]
    [InlineData("espresso", typeof(Espresso))]
    [InlineData("tea", typeof(Tea))]
    [InlineData("hotchocolate", typeof(HotChocolate))]
    public void Create_ValidKey_ReturnsCorrectType(string key, Type expectedType)
    {
        var beverage = factory.Create(key);
        Assert.IsType(expectedType, beverage);
    }

    [Fact]
    public void Create_InvalidKey_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => factory.Create("mocha"));
    }
}
