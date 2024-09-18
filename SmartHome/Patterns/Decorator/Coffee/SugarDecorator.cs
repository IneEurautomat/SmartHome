using SmartHome.Models;

namespace SmartHome.Patterns.Decorator.Coffee
{
    public class SugarDecorator : CoffeeMachineDecorator
    {
        public SugarDecorator(ICoffeeMachine coffeeMachine)
            : base(coffeeMachine)
        {
        }

        public override void BrewCoffee()
        {
            base.BrewCoffee();
            Console.WriteLine("Adding sugar...");
        }
    }
}
