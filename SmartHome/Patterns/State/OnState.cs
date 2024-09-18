using SmartHome.Models;
using SmartHome.Patterns.State;
using SmartHome.Services;

namespace SmartHome.Patterns.State
{
    public class OnState : IDeviceState
    {
        public void Handle(DeviceContext context)
        {
            Console.WriteLine("TV is already on. Changing volume or channel...");
        }
    }
}
