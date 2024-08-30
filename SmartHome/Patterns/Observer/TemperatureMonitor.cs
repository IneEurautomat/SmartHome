namespace SmartHome.Patterns.Observer
{
    public class TemperatureMonitor
    {
        private List<ITemperatureObserver> _observers = new List<ITemperatureObserver>();

        public void RegisterObserver(ITemperatureObserver observer)
        {
            _observers.Add(observer);
        }

        public void TemperatureChanged(int newTemp)
        {
            foreach (var observer in _observers)
            {
                observer.UpdateTemperature(newTemp);
            }
        }
    }
}
