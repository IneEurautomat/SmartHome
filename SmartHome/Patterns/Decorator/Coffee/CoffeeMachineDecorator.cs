using SmartHome.Models;
using SmartHome.Patterns.Strategy.CoffeeStrategy;

namespace SmartHome.Patterns.Decorator.Coffee
{
    public class CoffeeMachineDecorator : ICoffeeMachine
    {
        public readonly ICoffeeMachine _coffeeMachine;

        public CoffeeMachineDecorator(ICoffeeMachine coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }

        public virtual void BrewCoffee()
        {
            _coffeeMachine.BrewCoffee();
        }

        public void SetBrewingStrategy(IBrewingStrategy strategy)
        {
            _coffeeMachine.SetBrewingStrategy(strategy);
        }
    }
}
