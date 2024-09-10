using SmartHome.Models;

namespace SmartHome.Patterns.Command.Commands.TVCommands
{
    public class ChangeChannelCommand : ICommand<TV>
    {
        private TV _tv;

        public ChangeChannelCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute(TV device)
        {
            _tv.ChangeChannel();
        }
    }
}
