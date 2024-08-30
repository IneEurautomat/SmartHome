using SmartHome.Patterns.Observer;

namespace SmartHome.Models
{
    public class ThermostatDisplay : ITemperatureObserver
    {
        private Action<int> _onTemperatureUpdate;

        public ThermostatDisplay(Action<int> onTemperatureUpdate)
        {
            _onTemperatureUpdate = onTemperatureUpdate;
        }
        public void UpdateTemperature(int newTemp)
        {
            Console.WriteLine($"Thermostat Display: Temperature updated to {newTemp} degrees");
            _onTemperatureUpdate?.Invoke(newTemp);
        }
    }
}
