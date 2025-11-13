namespace Cafe.Domain.Beverages
{
    public class HotChocolate : IBeverage
    {
        public string Name => "Hot Chocolate";
        public decimal Cost() => 3.00m;
        public string Describe() => Name;
    }
}