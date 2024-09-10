using SmartHome.Models;

namespace SmartHome.Patterns.Command.Commands.TVCommands
{
    public class IncreaseVolumeCommand : ICommand<TV>
    {
        private TV _tv;

        public IncreaseVolumeCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute(TV device)
        {
            _tv.IncreaseVolume();
        }
    }
}
