using SmartHome.Models;
using SmartHome.Services;

namespace SmartHome.Patterns.Command
{
    public class TurnOffLightCommand : ICommand
    {
        private readonly Light _light;

        public TurnOffLightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }
    }
}
