using SmartHome.Models;

namespace SmartHome.Patterns.Command.Commands.TVCommands
{
    public class DecreaseVolumeCommand : ICommand<TV>
    {
        private TV _tv;

        public DecreaseVolumeCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute(TV Device)
        {
            _tv.DecreaseVolume();
        }
    }
}
