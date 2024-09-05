using SmartHome.Patterns.Visitor;

namespace SmartHome.Models
{
    public class CoffeeMachine : ICoffeeMachine
    {
        private string _coffeeType;
        private string _strength;
        private string _waterAmount;
        private string coffeeType;
        private string strength;
        private int waterAmount;
        public double EnergyUsage { get; set; } = 0.10; // Voorbeeldwaarde

        public CoffeeMachine(string coffeeType, string strength, string waterAmount)
        {
            _coffeeType = coffeeType;
            _strength = strength;
            _waterAmount = waterAmount;
        }

        public CoffeeMachine(string coffeeType, string strength, int waterAmount)
        {
            this.coffeeType = coffeeType;
            this.strength = strength;
            this.waterAmount = waterAmount;
        }

        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void BrewCoffee()
        {
            Console.WriteLine($"Brewing {_strength} {_coffeeType} with {_waterAmount}ml water.");
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