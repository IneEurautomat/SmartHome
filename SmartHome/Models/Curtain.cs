using SmartHome.Patterns.Visitor;
using static SmartHome.Models.Curtain;

namespace SmartHome.Models
{
    public class Curtain : IDevice
    {
        public double EnergyUsage { get; set; } = 0.05;
        public string CurrentStatus { get; private set; } = "closed";

        public void Open()
        {
            CurrentStatus = "open";
            Console.WriteLine("Curtain is Open");
        }

        public void Close()
        {
            CurrentStatus = "closed";
            Console.WriteLine("Curtain is Closed");
        }

        public void HalfOpen()
        {
            CurrentStatus = "halfopen";
            Console.WriteLine("Curtain is HalfOpen");
        }

        public void TurnOn()
        {
            Console.WriteLine("Curtain is being operated");
        }

        public void TurnOff()
        {
            Console.WriteLine("Curtain has stopped operating");
        }

        public string GetCurrentStatus()
        {
            return CurrentStatus;
        }

        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
