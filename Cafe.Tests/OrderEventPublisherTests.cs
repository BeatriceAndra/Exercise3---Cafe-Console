using System;
using Cafe.Application.Services;
using Cafe.Domain.Events;
using Moq;
using Xunit;

public class OrderEventPublisherTests
{
    [Fact]
    public void Subscriber_IsNotified_WhenOrderPlaced()
    {
        // Given
        var subscriberMock = new Mock<IOrderEventSubscriber>();
        var publisher = new SimpleOrderEventPublisher();
        publisher.Subscribe(subscriberMock.Object);

        var orderEvent = new OrderPlaced(Guid.NewGuid(), DateTimeOffset.Now, "Espresso", 2.50m, 2.50m);

        // When
        publisher.Publish(orderEvent);

        // Then
        subscriberMock.Verify(s => s.On(It.Is<OrderPlaced>(o =>
            o.Total == 2.50m && o.Description == "Espresso")), Times.Once);
    }
}
