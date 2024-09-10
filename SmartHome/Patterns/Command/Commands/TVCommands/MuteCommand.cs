using SmartHome.Models;

namespace SmartHome.Patterns.Command.Commands.TVCommands
{
    public class MuteCommand : ICommand<TV>
    {
        private TV _tv;

        public MuteCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute(TV Device)
        {
            _tv.Mute();
        }
    }
}
