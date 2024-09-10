using SmartHome.Models;

namespace SmartHome.Patterns.Command.Commands
{
    public class TurnOnCommand<T> : ICommand<T> where T : IDevice
    {
        public void Execute(T device)
        {
            device.TurnOn();
        }
    }
}
