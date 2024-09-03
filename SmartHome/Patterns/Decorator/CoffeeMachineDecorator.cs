using SmartHome.Models;

namespace SmartHome.Patterns.Decorator
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
    }
}
