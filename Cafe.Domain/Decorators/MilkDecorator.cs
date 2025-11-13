namespace Cafe.Domain.Beverages
{
    public class MilkDecorator : BeverageDecorator
    {
        private const decimal MilkCost = 0.40m;
        public override decimal Cost() => base.Cost() + MilkCost;
        public override string Describe() => $"{base.Describe()}, milk";
        public MilkDecorator(IBeverage beverage) : base(beverage) { }
    }
}
