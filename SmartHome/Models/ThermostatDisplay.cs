using SmartHome.Patterns.Observer;

namespace SmartHome.Models
{
    public class ThermostatDisplay : ITemperatureObserver
    {
        private Action<double> _onTemperatureUpdate;

        public ThermostatDisplay(Action<double> onTemperatureUpdate)
        {
            _onTemperatureUpdate = onTemperatureUpdate;
        }
        public void UpdateTemperature(double newTemp)
        {
            Console.WriteLine($"Thermostat Display: Temperature updated to {newTemp} degrees");
            _onTemperatureUpdate?.Invoke(newTemp);
        }
    }
}
