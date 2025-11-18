namespace Cafe.Domain.Beverages
{
    public abstract class BeverageDecorator : IBeverage
    {
        protected readonly IBeverage beverage;

        public virtual string Name => beverage.Name;

        public virtual decimal Cost() => beverage.Cost();

        public virtual string Describe() => beverage.Describe();

        protected BeverageDecorator(IBeverage beverage)
        {
            this.beverage = beverage ?? throw new ArgumentNullException(nameof(beverage));
        }

    }
}

