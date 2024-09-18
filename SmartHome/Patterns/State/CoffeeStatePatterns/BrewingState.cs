using SmartHome.Models;

namespace SmartHome.Patterns.State.CoffeeStatePatterns
{
    public class BrewingState : IDeviceState
    {
        private CoffeeMachine _coffeeMachine;
        public BrewingState(CoffeeMachine coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }
        public void Handle(DeviceContext context)
        {
            Console.WriteLine("Coffee is ready.");
            // Logica voor wanneer koffie klaar is
            context.SetState(new ReadyState()); // Transition to ReadyState or another state as needed
        }
        public void BrewCoffee()
        {
            Console.WriteLine("Brewing coffee...");
        }

        public void Clean()
        {
            Console.WriteLine("Cannot clean while brewing.");
        }
    }
}
