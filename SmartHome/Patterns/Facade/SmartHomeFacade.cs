﻿using SmartHome.Models;

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
            _curtain.Close();
            _musicPlayer.Off();
        }

        public void StartPartyMode()
        {
            _tv.On();
            _light.DiscoLights();
            _thermostat.SetTemperature(22);
            _curtain.Open();
            _musicPlayer.PlayPartylist();
        }

        public void StartNightMode()
        {
            _tv.Off();
            _light.Dim();
            _thermostat.SetTemperature(18);
            _curtain.Close();
            _musicPlayer.Off();
        }

        public void StartDayMode()
        {
            _tv.On();
            _light.On();
            _thermostat.SetTemperature(20);
            _curtain.Open();
            _musicPlayer.PlayBackgroundMusic();
        }
        public void ResetSettings()
        {
            _tv.Off();
            _light.On();
            _thermostat.SetTemperature(20);
            _curtain.Open();
            _musicPlayer.PlayBackgroundMusic();
        }
        private void OffSettings()
        {
            _tv.Off();
            _light.Off();
            _thermostat.Off();
            _curtain.Open();
            _musicPlayer.PlayBackgroundMusic();
        }
    }
}
