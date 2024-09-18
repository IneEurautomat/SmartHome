namespace SmartHome.Patterns.Strategy.CoffeeStrategy
{
    public class CappuccinoBrewingStrategy : IBrewingStrategy
    {
        public void Brew()
        {
            Console.WriteLine("Brewing cappuccino...");
        }
    }
}
