using SmartHome.Models;
using SmartHome.Services;
using SmartHome.Patterns.ChainOfResponsibility;

namespace SmartHome.Patterns.Factory
{
    public class SmartHomeFacadeFactory
    {
        private readonly TV _defaultTV;
        private readonly Light _defaultLight;
        private readonly IndoorThermostat _defaultThermostat;
        private readonly OutdoorTemperatureService _defaultOutdoorTemperatureService;
        private readonly Curtain _defaultCurtain;
        private readonly MusicPlayer _defaultMusicPlayer;
        private readonly SecurityCamera _defaultSecurityCamera;
        private readonly ThermostatDisplay _defaultThermostatDisplay;

        public SmartHomeFacadeFactory(IServiceProvider serviceProvider)
        {
            _defaultTV = new TV();
            _defaultLight = new Light();
            _defaultThermostat = new IndoorThermostat();
            _defaultOutdoorTemperatureService = serviceProvider.GetRequiredService<OutdoorTemperatureService>();
            _defaultCurtain = new Curtain();
            _defaultMusicPlayer = new MusicPlayer();
            _defaultSecurityCamera = new SecurityCamera();
            _defaultThermostatDisplay = new ThermostatDisplay(temp => { /* Handle temperature update */ });
        }

        public SmartHomeFacade CreateFacade()
        {
            return new SmartHomeFacade(
                _defaultTV,
                _defaultLight,
                _defaultThermostat,
                _defaultOutdoorTemperatureService,
                _defaultCurtain,
                _defaultMusicPlayer,
                _defaultSecurityCamera,
                _defaultThermostatDisplay
            );
        }
    }
}
