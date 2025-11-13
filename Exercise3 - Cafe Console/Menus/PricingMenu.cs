using Cafe.Domain.Pricing;

namespace Cafe.ConsoleUI.Menus
{
    public class PricingMenu
    {
        public IPricingStrategy Show()
        {
            Console.WriteLine("1) Regular 2) Happy Hour");
            var choice = Console.ReadLine();

            return choice switch
            {
                "1" => new RegularPricing(),
                "2" => new HappyHourPricing(),
                _ => new RegularPricing()
            };
        }
    }
}
