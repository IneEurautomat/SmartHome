using SmartHome.Services;

namespace SmartHome.Models
{
    public class Light : IDevice
    {
        public bool IsOn { get; private set; }
        public bool IsDimmed { get; private set; }
        public bool IsDiscoMode { get; private set; }

        public void On()
        {
            IsOn = true;
            IsDimmed = false;
            IsDiscoMode = false;
            Console.WriteLine("Light is On");
        }

        public void Off()
        {
            IsOn = false;
            IsDimmed = false;
            IsDiscoMode = false;
            Console.WriteLine("Light is Off");
        }
        public void Dim() 
        {
            IsDimmed = true;
            IsOn = false;
            IsDiscoMode = false;
            Console.WriteLine("Light is dimmed");
        }

        public void DiscoLights() 
        {
            IsDiscoMode = true;
            IsOn = false;
            IsDimmed = false;
            Console.WriteLine("Discolights are On");
        }
    }
}
