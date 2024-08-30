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
        // Implementatie van IDevice interface
        public void On()
        {
            Console.WriteLine("Music Player is On");
        }

        public void Off()
        {
            Console.WriteLine("Music Player is Off");
        }

        // Implementatie van IMusicPlayer interface
        public void Play()
        {
            Console.WriteLine("Playing music");
        }

        public void Pause()
        {
            Console.WriteLine("Music paused");
        }

        public void Stop()
        {
            Console.WriteLine("Music stopped");
        }

        public void IncreaseVolume()
        {
            Console.WriteLine("Volume increased");
        }

        public void DecreaseVolume()
        {
            Console.WriteLine("Volume decreased");
        }
        public void PlayPartylist()
        {
            Console.WriteLine("Partylist is playing");
        }
        public void PlayBackgroundMusic()
        {
            Console.WriteLine("Playing Background Music");
        }
    }
}
