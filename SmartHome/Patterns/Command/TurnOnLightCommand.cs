using SmartHome.Models;
using SmartHome.Services;

namespace SmartHome.Patterns.Command
{
    public class TurnOnLightCommand : ICommand
    {
        private readonly Light _light;

        public TurnOnLightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }
    }
}
