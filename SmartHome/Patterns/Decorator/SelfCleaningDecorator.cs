using SmartHome.Models;

namespace SmartHome.Patterns.Decorator
{
    public class SelfCleaningDecorator : CoffeeMachineDecorator
    {
        public SelfCleaningDecorator(ICoffeeMachine coffeeMachine)
            : base(coffeeMachine)
        {
        }

        public void Clean()
        {
            Console.WriteLine("Cleaning the coffee machine...");
        }

        public override void BrewCoffee()
        {
            base.BrewCoffee();
            Clean();
        }
    }
}
