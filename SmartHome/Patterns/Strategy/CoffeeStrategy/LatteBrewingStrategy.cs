namespace SmartHome.Patterns.Strategy.CoffeeStrategy
{
    public class LatteBrewingStrategy : IBrewingStrategy
    {
        public void Brew()
        {
            Console.WriteLine("Brewing latte...");
        }
    }
}
