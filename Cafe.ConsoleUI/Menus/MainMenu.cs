using System;
using Cafe.Application.Services;
using Cafe.Domain.Beverages;
using Cafe.Domain.Events;
using Cafe.Domain.Factories;
using Cafe.Domain.Pricing;
using Cafe.Infrastructure.Observers;

namespace Cafe.ConsoleUI.Menus
{
    public class MainMenu
    {
        private readonly IBeverageFactory beverageFactory;
        private readonly SimpleOrderEventPublisher eventPublisher;

        public MainMenu(IBeverageFactory factory)
        {
            beverageFactory = factory ?? throw new ArgumentNullException(nameof(factory));
            eventPublisher = new SimpleOrderEventPublisher();
            var consoleLogger = new ConsoleOrderLogger();
            var analytics = new InMemoryOrderAnalytics();

            eventPublisher.Subscribe(consoleLogger);
            eventPublisher.Subscribe(analytics);
        }

        public void Start()
        {
            var beverageMenu = new BeverageMenu(beverageFactory);
            var addonsMenu = new AddonsMenu();
            var pricingMenu = new PricingMenu();

            while (true)
            {
                IBeverage beverage = beverageMenu.Show();
                if (beverage == null) break;

                beverage = addonsMenu.Show(beverage);
                var pricingStrategy = pricingMenu.Show();

                var orderService = new OrderService(pricingStrategy, eventPublisher);
                orderService.PlaceOrder(beverage);

                Console.WriteLine("Order placed!\n");
            }

            Console.WriteLine("Thank you for visiting!");
        }
    }
}
