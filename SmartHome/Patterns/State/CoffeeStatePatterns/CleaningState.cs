using SmartHome.Models;

namespace SmartHome.Patterns.State.CoffeeStatePatterns
{
    public class CleaningState : IDeviceState
    {
        private CoffeeMachine _coffeeMachine;
        public void Handle(DeviceContext context)
        {
            Console.WriteLine("Coffeemachine is getting cleaning.");
            // You can add more behavior or transition to other states if needed
        }
        public CleaningState(CoffeeMachine coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }

        public void BrewCoffee()
        {
            Console.WriteLine("Cannot brew while cleaning.");
        }

        public void Clean()
        {
            Console.WriteLine("Already cleaning.");
        }
    }
}
