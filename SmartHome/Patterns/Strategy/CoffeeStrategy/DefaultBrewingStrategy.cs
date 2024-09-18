namespace SmartHome.Patterns.Strategy.CoffeeStrategy
{
    public class DefaultBrewingStrategy : IBrewingStrategy
    {
        public void Brew()
        {
            Console.WriteLine("Brewing coffee...");
        }
    }
}
