namespace Cafe.Domain.Beverages
{
    public class SyrupDecorator : BeverageDecorator
    {
        private const decimal SyrupCost = 0.50m;
        private readonly string flavor;
        public override decimal Cost() => base.Cost() + SyrupCost;
        public override string Describe() => $"{base.Describe()}, {flavor} syrup";
        public SyrupDecorator(IBeverage beverage, string flavor) : base(beverage)
        {
            if (string.IsNullOrWhiteSpace(flavor))
                throw new ArgumentException("Flavor cannot be empty.", nameof(flavor));
            this.flavor = flavor;
        }
    }
}
