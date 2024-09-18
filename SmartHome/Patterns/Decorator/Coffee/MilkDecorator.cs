using SmartHome.Models;

namespace SmartHome.Patterns.Decorator.Coffee
{
    public class MilkDecorator : CoffeeMachineDecorator
    {
        public MilkDecorator(ICoffeeMachine coffeeMachine)
            : base(coffeeMachine)
        {
        }

        public override void BrewCoffee()
        {
            base.BrewCoffee();
            Console.WriteLine("Adding milk...");
        }
    }
}
