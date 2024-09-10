using SmartHome.Models;

namespace SmartHome.Patterns.Command.Commands.ThermostatCommands
{
    public class SetTemperatureCommand<T> : ICommand<T> where T : OldThermostat
    {
        private readonly T _thermostat;
        private readonly int _temperature;

        public SetTemperatureCommand(T thermostat, int temperature)
        {
            _thermostat = thermostat;
            _temperature = temperature;
        }

        public void Execute(T Device)
        {
            _thermostat.SetTemperature(_temperature);
        }
    }
}
