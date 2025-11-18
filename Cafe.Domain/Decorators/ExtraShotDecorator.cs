namespace Cafe.Domain.Beverages
{
    public class ExtraShotDecorator : BeverageDecorator
    {
        private const decimal ShotCost = 0.80m;

        public override decimal Cost() => base.Cost() + ShotCost;

        public override string Describe() => $"{base.Describe()}, extra shot";

        public ExtraShotDecorator(IBeverage beverage) : base(beverage) { }

    }
}

