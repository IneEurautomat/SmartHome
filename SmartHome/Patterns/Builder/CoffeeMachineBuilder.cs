using SmartHome.Models;

namespace SmartHome.Patterns.Builder
{
    public class CoffeeMachineBuilder
    {
        private string _coffeeType;
        private string _strength;
        private int _waterAmount;

        public CoffeeMachineBuilder SetCoffeeType(string coffeeType)
        {
            _coffeeType = coffeeType;
            return this;
        }

        public CoffeeMachineBuilder SetStrength(string strength)
        {
            _strength = strength;
            return this;
        }

        public CoffeeMachineBuilder SetWaterAmount(int amount)
        {
            _waterAmount = amount;
            return this;
        }

        public ICoffeeMachine Build()
        {
            return new CoffeeMachine(_coffeeType, _strength, _waterAmount);
        }
    }

}
