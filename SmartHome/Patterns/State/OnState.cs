using SmartHome.Models;
using SmartHome.Services;

namespace SmartHome.Patterns.State
{
    public class OnState : ITVState
    {
        public void Handle(TV context)
        {
            Console.WriteLine("TV is already on. Changing volume or channel...");
        }
    }
}
