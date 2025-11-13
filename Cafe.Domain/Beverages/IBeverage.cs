namespace Cafe.Domain.Beverages
{
    public interface IBeverage
    {
        string Name { get; }
        decimal Cost();
        string Describe();
    }
}
