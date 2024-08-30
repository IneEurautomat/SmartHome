using SmartHome.Patterns.State;
using SmartHome.Services;

namespace SmartHome.Models
{
    public class TV : IDevice
    {
        public ITVState State { get; set; }

        public TV()
        {
            State = new OffState(); // Start met de TV uitgeschakeld
        }
       
        public void On()
        {
            State.Handle(this);
            Console.WriteLine("TV is On");
        }

        public void Off()
        {
            State = new OffState();
            Console.WriteLine("TV is now off.");
        }

        public void Mute()
        {
            State = new MuteState();
            Console.WriteLine("TV is now muted.");
        }
    }
}
