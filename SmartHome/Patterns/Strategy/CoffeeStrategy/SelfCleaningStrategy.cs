using SmartHome.Models;
using SmartHome.Patterns.Decorator.Coffee;

namespace SmartHome.Patterns.Strategy.CoffeeStrategy
{
    public class SelfCleaningStrategy : IBrewingStrategy
    {

        public void Brew()
        {
            Console.WriteLine("Brewing coffee...");
            Clean();
        }
        public void Clean()
        {
            Console.WriteLine("Cleaning the coffee machine...");
        }
    }
}
