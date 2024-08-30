using SmartHome.Component;
using SmartHome.Models;

namespace SmartHome.Patterns.Facade
{
    public class SmartHomeFacade
    {
        private readonly TV _tv;
        private readonly Light _light;
        private readonly OldThermostatAdapter _thermostat;
        private readonly Curtain _curtain;
        private readonly MusicPlayer _musicPlayer;

        public SmartHomeFacade(TV tv, Light light, OldThermostatAdapter thermostat, Curtain curtain, MusicPlayer musicPlayer)
        {
            _tv = tv;
            _light = light;
            _thermostat = thermostat;
            _curtain = curtain;
            _musicPlayer = musicPlayer;
        }

        public void StartMovieMode()
        {
            _tv.On();
            _light.Dim();
            _thermostat.SetTemperature(21);
            _curtain.Closed();
        }
    }
}
