using Cafe.Application.Services;
using Cafe.ConsoleUI.Menus;
using Cafe.Domain.Beverages;
using Cafe.Domain.Factories;
using Cafe.Infrastructure.Observers;

public class MainMenu
{
    private readonly IBeverageFactory beverageFactory;
    private readonly SimpleOrderEventPublisher eventPublisher;
    private readonly InMemoryOrderAnalytics analytics;

    public MainMenu(IBeverageFactory factory)
    {
        beverageFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        eventPublisher = new SimpleOrderEventPublisher();
        var consoleLogger = new ConsoleOrderLogger();
        analytics = new InMemoryOrderAnalytics();

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
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1) Place a new order");
            Console.WriteLine("2) Show statistics");
            Console.WriteLine("0) Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    IBeverage beverage = beverageMenu.Show();
                    if (beverage == null) break;

                    beverage = addonsMenu.Show(beverage);
                    var pricingStrategy = pricingMenu.Show();

                    var orderService = new OrderService(pricingStrategy, eventPublisher);
                    orderService.PlaceOrder(beverage);

                    Console.WriteLine("Order placed!\n");
                    break;

                case "2":
                    Console.WriteLine($"Total orders: {analytics.TotalOrders}");
                    Console.WriteLine($"Total revenue: {analytics.TotalRevenue:C}");
                    break;

                case "0":
                    Console.WriteLine("Thank you for visiting!");
                    return;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}
