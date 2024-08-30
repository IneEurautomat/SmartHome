using SmartHome.Models;
using SmartHome.Services;

namespace SmartHome.Patterns.State
{
    public class MuteState : ITVState
    {
        public void Handle(TV context)
        {
            Console.WriteLine("TV is muted. Adjusting volume...");
        }
    }
}
