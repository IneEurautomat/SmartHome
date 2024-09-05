using SmartHome.Patterns.Visitor;
using SmartHome.Services;

namespace SmartHome.Models
{
    public class Light : IDevice
    {
        public double EnergyUsage { get; set; } = 0.25;
        public bool IsOn { get; private set; }
        public bool IsDimmed { get; private set; }
        public bool IsDiscoMode { get; private set; }
        public string CurrentStatus { get; private set; } = "off";


        public void TurnOn()
        {
            IsOn = true;
            IsDimmed = false;
            IsDiscoMode = false;
            CurrentStatus = "on";
            Console.WriteLine("Light is On");
        }

        public void TurnOff()
        {
            IsOn = false;
            IsDimmed = false;
            IsDiscoMode = false;
            CurrentStatus = "off";
            Console.WriteLine("Light is Off");
        }
        public void Dim() 
        {
            IsDimmed = true;
            IsOn = false;
            IsDiscoMode = false;
            CurrentStatus = "dim";
            Console.WriteLine("Light is dimmed");
        }

        public void DiscoLights() 
        {
            IsDiscoMode = true;
            IsOn = false;
            IsDimmed = false;
            CurrentStatus = "disco";
            Console.WriteLine("Discolights are On");
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
