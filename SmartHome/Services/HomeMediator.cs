using SmartHome.Component;
using SmartHome.Models;
using SmartHome.Patterns.State;
using System;

namespace SmartHome.Services
{
    public class HomeMediator
    {
        private readonly TV _tv;
        private readonly Light _light;
        private readonly Curtain _curtain;
        private readonly OldThermostatAdapter _thermostat;
        private readonly MusicPlayer _musicPlayer;

        public HomeMediator(TV tv, Light light, Curtain curtain, OldThermostatAdapter thermostat, MusicPlayer musicPlayer)
        {
            _tv = tv;
            _light = light;
            _curtain = curtain;
            _thermostat = thermostat;
            _musicPlayer = musicPlayer;
        }

        public void CozyEvening()
        {
            if (_tv.State is OffState)
            {
                _tv.On();
            }

            _curtain.Closed();
            _light.Dim();
            _thermostat.SetTemperature(22);
        }

        public void EndCozyEvening()
        {
            _tv.Off();
            _curtain.Open();
            _light.On();
            _thermostat.SetTemperature(20);
        }

        public void PartyMode()
        {
            if (_tv.State is OnState)
            {
                _tv.Off();
            }

            _curtain.Open();
            _light.DiscoLights(); // Assuming the lights can blink in PartyMode
            _thermostat.SetTemperature(23);
            _musicPlayer.PlayPartyPlaylist();
        }

        public void EndPartyMode()
        {
            _musicPlayer.Stop();
            _light.On();
            _thermostat.SetTemperature(21); // Returning to a comfortable room temperature
            _curtain.Closed();
        }

        public void NightMode()
        {
            if (_tv.State is OnState)
            {
                _tv.Off();
            }

            _curtain.Closed();
            _light.Off();
            _thermostat.SetTemperature(18); // Set a cooler temperature for sleeping
        }

        public void DayMode()
        {
            if (_tv.State is OnState)
            {
                _tv.Off();
            }

            _curtain.Open();
            _light.Off();
            _thermostat.SetTemperature(20);
        }
    }
}

