using SmartHome.Patterns.State;

namespace SmartHome.Models
{
    public class MusicPlayer : IDevice
    {
        public void On()
        {
            Console.WriteLine("Light is On");
        }

        public void Off()
        {
            Console.WriteLine("Light is Off");
        }
        public void PlayPartyPlaylist()
        {
            Console.WriteLine("Light is Off");
        }
        public void Stop()
        {
            Console.WriteLine("Light is Off");
        }
    }
}
