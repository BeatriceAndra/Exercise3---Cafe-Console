using Cafe.Domain.Beverages;

namespace Cafe.Domain.Factories
{
    public interface IBeverageFactory
    {
        IBeverage Create(string key);
    }
}
