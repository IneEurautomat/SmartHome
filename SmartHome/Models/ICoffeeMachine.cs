using SmartHome.Patterns.Strategy.CoffeeStrategy;

namespace SmartHome.Models
{
    public interface ICoffeeMachine
    {
        void BrewCoffee();
        void SetBrewingStrategy(IBrewingStrategy strategy);
    }
}
