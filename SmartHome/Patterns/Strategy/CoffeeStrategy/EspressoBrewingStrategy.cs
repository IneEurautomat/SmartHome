namespace SmartHome.Patterns.Strategy.CoffeeStrategy
{
    public class EspressoBrewingStrategy : IBrewingStrategy
    {
        public void Brew()
        {
            Console.WriteLine("Brewing espresso...");
        }
    }
}
