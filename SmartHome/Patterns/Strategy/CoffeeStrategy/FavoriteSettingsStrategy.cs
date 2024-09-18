using SmartHome.Models;
using SmartHome.Patterns.Strategy.CoffeeStrategy;

namespace SmartHome.Patterns.Decorator.Coffee
{
    public class FavoriteSettingsStrategy : IBrewingStrategy
    {
        private string _favoriteSettings;

        public FavoriteSettingsStrategy(string favoriteSettings)
        {
            _favoriteSettings = favoriteSettings;
        }

        public void SetFavoriteSettings(string settings)
        {
            _favoriteSettings = settings;
            Console.WriteLine($"Favorite settings updated: {_favoriteSettings}");
        }

        public void Brew()
        {
            Console.WriteLine($"Brewing coffee with favorite settings: {_favoriteSettings}");
        }
    }
}
