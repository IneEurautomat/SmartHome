using SmartHome.Models;

namespace SmartHome.Patterns.Factory
{
	public class SmartHomeFacadeFactory
	{
		private readonly TV _defaultTV;
		private readonly Light _defaultLight;
		private readonly OldThermostatAdapter _defaultThermostat;
		private readonly Curtain _defaultCurtain;
		private readonly MusicPlayer _defaultMusicPlayer;

		public SmartHomeFacadeFactory()
		{
			// Initialize default devices
			_defaultTV = new TV();
			_defaultLight = new Light();
			var oldThermostat = new OldThermostat();
			_defaultThermostat = new OldThermostatAdapter(oldThermostat);
			_defaultCurtain = new Curtain();
			_defaultMusicPlayer = new MusicPlayer();
		}

		public SmartHomeFacade CreateFacade()
		{
			return new SmartHomeFacade(_defaultTV, _defaultLight, _defaultThermostat, _defaultCurtain, _defaultMusicPlayer);
		}
	}

}
