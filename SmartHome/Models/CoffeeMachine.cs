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

        public void BrewCoffee()
        {
            Console.WriteLine($"Brewing {_strength} {_coffeeType} with {_waterAmount}ml water.");
        }
    }
}