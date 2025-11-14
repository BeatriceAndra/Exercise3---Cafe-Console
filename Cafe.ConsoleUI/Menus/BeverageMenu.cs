using Cafe.ConsoleUI.Enums;
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
                Console.WriteLine("Choose base: 1) Espresso 2) Tea 3) Hot Chocolate 0) Exit ");

                if (!int.TryParse(Console.ReadLine(), out int input) ||
                    !Enum.IsDefined(typeof(BeverageChoice), input))
                {
                    Console.WriteLine("Invalid choice, try again.");
                    continue;
                }

                var choice = (BeverageChoice)input;

                if (choice == BeverageChoice.Exit)
                    return null;

                var key = choice switch
                {
                    BeverageChoice.Espresso => "espresso",
                    BeverageChoice.Tea => "tea",
                    BeverageChoice.HotChocolate => "hotchocolate",
                    _ => null
                };

                return beverageFactory.Create(key);
            }
        }
    }
}
