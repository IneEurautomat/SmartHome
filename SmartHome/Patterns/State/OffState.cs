using SmartHome.Models;
using SmartHome.Services;

namespace SmartHome.Patterns.State
{
    public class OffState : ITVState
    {
        public void Handle(TV context)
        {
            Console.WriteLine("Turning the TV on...");
            context.State = new OnState();
        }
    }
}

