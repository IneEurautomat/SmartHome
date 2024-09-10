using SmartHome.Patterns.Command;

namespace SmartHome.Models
{
    //COMMAND
    //---------------------------------------------
    public class RemoteControl<T> where T : IDevice
    {
        private Dictionary<string, ICommand<T>> _commands = new Dictionary<string, ICommand<T>>();

        public RemoteControl()
        {
        
        }
        public void SetCommand(string action, ICommand<T> command)
        {
            _commands[action] = command;
        }

        public void ExecuteCommand(string action, T device)
        {
            if (_commands.ContainsKey(action))
            {
                _commands[action].Execute(device);
            }
            else
            {
                Console.WriteLine($"No command registered for action: {action}");
            }
        }
    }
}
