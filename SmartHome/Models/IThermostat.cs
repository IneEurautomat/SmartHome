namespace SmartHome.Models
{
    public interface IThermostat
    {
        double CurrentTemperature { get; }
        void SetTemperature(double temperature);

        event Action<double> TemperatureChanged;
    }
}
