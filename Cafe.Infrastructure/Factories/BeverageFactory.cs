using Cafe.Domain.Beverages;
using Cafe.Domain.Factories;

namespace Cafe.Infrastructure.Factories
{
    public class BeverageFactory : IBeverageFactory
    {
        public IBeverage Create(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty.");

            return key.ToLower() switch
            {
                "espresso" => new Espresso(),
                "tea" => new Tea(),
                "hotchocolate" => new HotChocolate(),
                _ => throw new ArgumentException($"Unknown beverage key: {key}")
            };
        }
    }
}
