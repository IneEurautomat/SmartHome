using SmartHome.Models;

namespace SmartHome.Patterns.State.CoffeeStatePatterns
{
    public class ReadyState : IDeviceState
    {
        private CoffeeMachine _coffeeMachine;

        public void Handle(DeviceContext context)
        {
            Console.WriteLine("Coffee is ready.");
            context.SetState(new CleaningState(_coffeeMachine));
        }


        public void Clean()
        {
            Console.WriteLine("Cleaning the coffee machine...");
        }
    }
}
