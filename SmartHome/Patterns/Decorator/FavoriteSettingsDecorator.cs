using SmartHome.Models;

namespace SmartHome.Patterns.Decorator
{
    public class FavoriteSettingsDecorator : CoffeeMachineDecorator
    {
        private string _favoriteSettings;

        public FavoriteSettingsDecorator(ICoffeeMachine coffeeMachine, string favoriteSettings)
            : base(coffeeMachine)
        {
            _favoriteSettings = favoriteSettings;
        }

        public void SetFavoriteSettings(string settings)
        {
            _favoriteSettings = settings;
            Console.WriteLine($"Favorite settings updated: {_favoriteSettings}");

        }

        public override void BrewCoffee()
        {
            Console.WriteLine($"Brewing coffee with favorite settings: {_favoriteSettings}");
            base.BrewCoffee();
        }
    }
}
