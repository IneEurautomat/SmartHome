using SmartHome.Patterns.State;
using SmartHome.Patterns.Strategy.CoffeeStrategy;
using SmartHome.Patterns.Visitor;

namespace SmartHome.Models
{
    public class CoffeeMachine : ICoffeeMachine
    {
        private string _coffeeType;
        private string _strength;
        private int _waterAmount;
        private bool _hasMilk;
        private bool _hasSugar;
        private bool _isDecaf;

        public double EnergyUsage { get; set; } = 0.10;
        private IBrewingStrategy _brewingStrategy;
        private DeviceContext _context;
        public string CurrentStatus { get; private set; } = "off";


        public CoffeeMachine(string coffeeType, string strength, int waterAmount, bool hasMilk, bool hasSugar, bool isDecaf)
        {
            _coffeeType = coffeeType;
            _strength = strength;
            _waterAmount = waterAmount;
            _hasMilk = hasMilk;
            _hasSugar = hasSugar;
            _isDecaf = isDecaf;
            _context = new DeviceContext("CoffeeMachine", new OffState());

        }
        public void TurnOn()
        {
            _context.Request();
            CurrentStatus = "on";
            Console.WriteLine("Coffeemachine is On");
        }

        public void TurnOff()
        {
            _context.Request();
            CurrentStatus = "off";
            Console.WriteLine("CoffeeMachine is now off.");
        }
        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void SetBrewingStrategy(IBrewingStrategy strategy)
        {
            _brewingStrategy = strategy;
        }

        public void BrewCoffee()
        {
            _brewingStrategy.Brew();
        }

        public void Off()
        {
            Console.WriteLine("CoffeeMachine is Off");
        }

        public void On()
        {
            Console.WriteLine("CoffeeMachine is On");
        }
    }
}