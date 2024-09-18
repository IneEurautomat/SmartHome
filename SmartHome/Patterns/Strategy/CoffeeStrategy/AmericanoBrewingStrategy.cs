namespace SmartHome.Patterns.Strategy.CoffeeStrategy
{
    public class AmericanoBrewingStrategy : IBrewingStrategy
    {
        public void Brew()
        {
            Console.WriteLine("Brewing americano...");
        }
    }
}
