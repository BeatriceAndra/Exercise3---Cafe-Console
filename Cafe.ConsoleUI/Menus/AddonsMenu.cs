using System;
using Cafe.Domain.Beverages;

namespace Cafe.ConsoleUI.Menus
{
    public class AddonsMenu
    {
        public IBeverage Show(IBeverage beverage)
        {
            while (true)
            {
                Console.WriteLine("1) Milk (+0.40) 2) Syrup (+0.50) 3) Extra shot (+0.80) 0) Done");
                var choice = Console.ReadLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        beverage = new MilkDecorator(beverage);
                        break;
                    case "2":
                        Console.Write("Enter syrup flavor: ");
                        var flavor = Console.ReadLine();
                        beverage = new SyrupDecorator(beverage, flavor);
                        break;
                    case "3":
                        beverage = new ExtraShotDecorator(beverage);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }

            return beverage;
        }
    }
}

