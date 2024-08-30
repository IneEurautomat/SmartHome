
//ADAPTER Pattern
//---------------------------------------------
namespace SmartHome.Models
{
    public class OldThermostat : IDevice
    {
        private int _currentTemperature = 18;

        public int GetCurrentTemperature()
        {
            return _currentTemperature;
        }
        public void On()
        {
            Console.WriteLine("Thermostat is On");
        }

        public void Off()
        {
            Console.WriteLine("Thermostat is Off");
        }
        public void SetOldTemperature(int degrees)
        {
            // Logica om de oude thermostaat in te stellen
            if (degrees < 10 || degrees > 30)
            {
                Console.WriteLine("Temperature out of range! Please set a temperature between 10 and 30 degrees.");
            }
            else
            {
                _currentTemperature = degrees;
                Console.WriteLine($"Old thermostat set to {_currentTemperature} degrees.");
            }
        }
    }

    public interface INewThermostat
    {
        void SetTemperature(int degrees);
    }

    public class OldThermostatAdapter : INewThermostat
    {
        private readonly OldThermostat _oldThermostat;

        public OldThermostatAdapter(OldThermostat oldThermostat)
        {
            _oldThermostat = oldThermostat;
        }
        public void On()
        {
            Console.WriteLine("Thermostat is On");
        }

        public void Off()
        {
            Console.WriteLine("Thermostat is Off");
        }

        public void SetTemperature(int degrees)
        {
            _oldThermostat.SetOldTemperature(degrees);
        }

        public int GetTemperature()
        {
            return _oldThermostat.GetCurrentTemperature();
        }
    }
}
