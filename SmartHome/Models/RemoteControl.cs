using SmartHome.Patterns.Command;

namespace SmartHome.Models
{
    //COMMAND
    //---------------------------------------------
    public class RemoteControl
    {
        private readonly ICommand _onCommand;
        private readonly ICommand _offCommand;

        public RemoteControl(ICommand onCommand, ICommand offCommand)
        {
            _onCommand = onCommand;
            _offCommand = offCommand;
        }

        public void TurnOn()
        {
            _onCommand.Execute();
        }

        public void TurnOff()
        {
            _offCommand.Execute();
        }
    }
}
