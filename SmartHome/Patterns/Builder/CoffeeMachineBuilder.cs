using SmartHome.Models;

namespace SmartHome.Patterns.Builder
{
    public class CoffeeMachineBuilder
    {
        private string _coffeeType;
        private string _strength;
        private int _waterAmount;
        private bool _hasMilk;
        private bool _hasSugar;
        private bool _isDecaf;

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
        public CoffeeMachineBuilder AddMilk(bool hasMilk)
        {
            _hasMilk = hasMilk;
            return this;
        }

        public CoffeeMachineBuilder AddSugar(bool hasSugar)
        {
            _hasSugar = hasSugar;
            return this;
        }

        public CoffeeMachineBuilder SetDecaf(bool isDecaf)
        {
            _isDecaf = isDecaf;
            return this;
        }
        public ICoffeeMachine Build()
        {
            return new CoffeeMachine(_coffeeType, _strength, _waterAmount, _hasMilk, _hasSugar, _isDecaf);
        }
    }

}
