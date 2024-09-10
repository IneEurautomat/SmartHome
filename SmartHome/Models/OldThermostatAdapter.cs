
//ADAPTER Pattern
//---------------------------------------------
using SmartHome.Patterns.Visitor;

namespace SmartHome.Models
{
    public class OldThermostat : IDevice
    {
        public double EnergyUsage { get; set; } = 0.05;

        private int _currentTemperature = 18;

        public int GetCurrentTemperature()
        {
            return _currentTemperature;
        }
        public void TurnOn()
        {
            Console.WriteLine("Thermostat is On");
        }

        public void TurnOff()
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

        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }

        internal void SetTemperature(int temperature)
        {
            throw new NotImplementedException();
        }
    }

    public interface INewThermostat : IDevice
    {
        void SetTemperature(int degrees);
    }

    public class OldThermostatAdapter : INewThermostat
    {
        public double EnergyUsage { get; set; } = 0.05;

        private readonly OldThermostat _oldThermostat;

        public OldThermostatAdapter(OldThermostat oldThermostat)
        {
            _oldThermostat = oldThermostat;
        }
        public void TurnOn()
        {
            Console.WriteLine("Thermostat is On");
        }

        public void TurnOff()
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

        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
