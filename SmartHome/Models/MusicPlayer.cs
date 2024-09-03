using SmartHome.Patterns.State;

namespace SmartHome.Models
{
    public interface IMusicPlayer
    {
        void Play();
        void Pause();
        void Stop();
        void IncreaseVolume();
        void DecreaseVolume();
    }

    public class MusicPlayer : IDevice, IMusicPlayer
    {
        public string CurrentStatus { get; private set; } = "off";
        // Implementatie van IDevice interface
        public void On()
        {
            CurrentStatus = "on";
            Console.WriteLine("Music Player is On");
        }

        public void Off()
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
    }
}
