using SmartHome.Services;

namespace SmartHome.Models
{
    public class Light : IDevice
    {
        public void On()
        {
            Console.WriteLine("Light is On");
        }

        public void Off()
        {
            Console.WriteLine("Light is Off");
        }
        public void Dim() 
        {
            Console.WriteLine("Light is dimmed");
        }

        public void DiscoLights() 
        {
            Console.WriteLine("Discolights are On");
        }
    }
}
