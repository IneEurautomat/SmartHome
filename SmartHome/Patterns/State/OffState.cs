using SmartHome.Models;
using SmartHome.Patterns.State;
using SmartHome.Services;

namespace SmartHome.Patterns.State
{
    public class OffState : IDeviceState
    {
        public void Handle(DeviceContext context)
        {
            Console.WriteLine("Turning the TV on...");
            context.State = new OnState();
        }
    }
}

