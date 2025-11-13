using Cafe.Domain.Events;
using Cafe.Infrastructure.Observers;
using Xunit;

public class InMemoryOrderAnalyticsTests
{
    [Fact]
    public void PublishesMultipleOrders_AccumulatesRevenueAndCount()
    {
        var analytics = new InMemoryOrderAnalytics();

        var order1 = new OrderPlaced(Guid.NewGuid(), DateTimeOffset.Now, "Espresso", 3.00m, 3.50m);
        var order2 = new OrderPlaced(Guid.NewGuid(), DateTimeOffset.Now, "Tea", 2.00m, 2.00m);

        analytics.On(order1);
        analytics.On(order2);

        Assert.Equal(2, analytics.TotalOrders);
        Assert.Equal(5.50m, analytics.TotalRevenue);
    }
}
