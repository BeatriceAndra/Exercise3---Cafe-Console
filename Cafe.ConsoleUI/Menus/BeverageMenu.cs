using Cafe.Domain.Beverages;
using Cafe.Domain.Factories;

namespace Cafe.ConsoleUI.Menus
{
    public class BeverageMenu
    {
        private readonly IBeverageFactory beverageFactory;

        public BeverageMenu(IBeverageFactory factory)
        {
            beverageFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IBeverage Show()
        {
            while (true)
            {
                Console.WriteLine("Choose base: 1) Espresso 2) Tea 3) Hot Chocolate 0) Exit");
                var choice = Console.ReadLine();

                if (choice == "0") return null;

                string key = choice switch
                {
                    "1" => "espresso",
                    "2" => "tea",
                    "3" => "hotchocolate",
                    _ => null
                };

                if (key == null)
                {
                    Console.WriteLine("Invalid choice, try again.");
                    continue;
                }

                return beverageFactory.Create(key);
            }
        }
    }
}
