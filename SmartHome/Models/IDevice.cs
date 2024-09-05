using SmartHome.Patterns.Visitor;

namespace SmartHome.Models
{
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();

        double EnergyUsage { get; }
        void Accept(IDeviceVisitor visitor);

    }
}
