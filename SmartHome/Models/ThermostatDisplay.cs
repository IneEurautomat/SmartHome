using SmartHome.Patterns.Observer;

namespace SmartHome.Models
{
    public class ThermostatDisplay : ITemperatureObserver
    {
        public void UpdateTemperature(int newTemp)
        {
            Console.WriteLine($"Thermostat Display: Temperature updated to {newTemp} degrees");
        }
    }
}
