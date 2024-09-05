using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public class MusicPlayerHandler : DeviceHandler
	{
		private readonly MusicPlayer _musicPlayer;

		public MusicPlayerHandler(MusicPlayer musicPlayer)
		{
			_musicPlayer = musicPlayer;
		}

		protected override bool Handle(SmartHomeSettings settings)
		{
			if (settings.MusicPlaying) _musicPlayer.PlayBackgroundMusic();
			else _musicPlayer.Off();
			return true;
		}
	}
}
