using SmartHome.Models;

namespace SmartHome.Patterns.Command.Commands
{
    public class TurnOffCommand<T> : ICommand<T> where T : IDevice
    {
        public void Execute(T device)
        {
            device.TurnOff();
        }
    }
}
