using Cafe.Application.Services;
using Cafe.Domain.Beverages;
using Cafe.Domain.Factories;
using Cafe.Infrastructure.Observers;

namespace Cafe.ConsoleUI.Menus
{
    public class MainMenu
    {
        private readonly IBeverageFactory beverageFactory;
        private readonly IOrderOrchestrator orderOrchestrator;

        public MainMenu(IBeverageFactory factory)
        {
            beverageFactory = factory ?? throw new ArgumentNullException(nameof(factory));

            var eventPublisher = new SimpleOrderEventPublisher();
            eventPublisher.Subscribe(new ConsoleOrderLogger());
            eventPublisher.Subscribe(new InMemoryOrderAnalytics());

            orderOrchestrator = new OrderOrchestrator(eventPublisher);
        }

        public void Start()
        {
            var beverageMenu = new BeverageMenu(beverageFactory);
            var addonsMenu = new AddonsMenu();
            var pricingMenu = new PricingMenu();

            while (true)
            {
                var beverage = beverageMenu.Show();
                if (beverage == null) break;

                beverage = addonsMenu.Show(beverage);
                var pricingStrategy = pricingMenu.Show();

                orderOrchestrator.PlaceOrder(beverage, pricingStrategy);

                Console.WriteLine("Order placed!\n");
            }

            Console.WriteLine("Thank you for visiting!");
        }

    }
}

