using SmartHome.Patterns.Observer;
using SmartHome.Patterns.Visitor;

namespace SmartHome.Models
{
    public class IndoorThermostat : IThermostat, IDevice
    {
        private double _currentTemperature = 21.1;
        public double EnergyUsage { get; set; } = 0.10;
        public bool IsOn { get; private set; }
        public string CurrentStatus { get; private set; } = "on";


        private List<ITemperatureObserver> _observers = new List<ITemperatureObserver>();

        public double CurrentTemperature => _currentTemperature;

        public event Action<double> TemperatureChanged;
        public double GetTemperature()
        {
            return (double)_currentTemperature;
        }
        public void SetTemperature(double temperature)
        {
            _currentTemperature = temperature;
            NotifyObservers();
        }

        public void RegisterObserver(ITemperatureObserver observer)
        {
            _observers.Add(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateTemperature(_currentTemperature);
            }
        }
        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void TurnOn()
        {
            IsOn = true;
        }

        public void TurnOff()
        {
            IsOn = false;
        }
    }
}
