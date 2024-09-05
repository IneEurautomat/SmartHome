using SmartHome.Patterns.State;
using SmartHome.Patterns.Visitor;

namespace SmartHome.Models
{
    public interface IMusicPlayer : IDevice
    {
        void Play();
        void Pause();
        void Stop();
        void IncreaseVolume();
        void DecreaseVolume();
    }

    public class MusicPlayer : IDevice, IMusicPlayer
    {
        public double EnergyUsage { get; set; } = 0.30;

        public string CurrentStatus { get; private set; } = "off";
        // Implementatie van IDevice interface
        public void TurnOn()
        {
            CurrentStatus = "on";
            Console.WriteLine("Music Player is On");
        }

        public void TurnOff()
        {
            CurrentStatus = "off";
            Console.WriteLine("Music Player is Off");
        }

        // Implementatie van IMusicPlayer interface
        public void Play()
        {
            CurrentStatus = "play";
            Console.WriteLine("Playing music");
        }

        public void Pause()
        {
            CurrentStatus = "pause";
            Console.WriteLine("Music paused");
        }

        public void Stop()
        {
            CurrentStatus = "stop";
            Console.WriteLine("Music stopped");
        }

        public void IncreaseVolume()
        {
            CurrentStatus = "increase";
            Console.WriteLine("Volume increased");
        }

        public void DecreaseVolume()
        {
            CurrentStatus = "decrease";
            Console.WriteLine("Volume decreased");
        }
        public void PlayPartylist()
        {
            CurrentStatus = "partylist";
            Console.WriteLine("Partylist is playing");
        }
        public void PlayBackgroundMusic()
        {
            CurrentStatus = "backgroundmusic";
            Console.WriteLine("Playing Background Music");
        }

        public string GetCurrentStatus()
        {
            return CurrentStatus;
        }

        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
