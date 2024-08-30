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
        public void ChangeChannel()
        {
            if (State is OnState)
            {
                Console.WriteLine("Channel changed");
            }
            else
            {
                Console.WriteLine("TV must be on to change channels");
            }
        }

        public void IncreaseVolume()
        {
            if (State is OnState)
            {
                Console.WriteLine("Volume increased");
            }
            else
            {
                Console.WriteLine("TV must be on to adjust volume");
            }
        }

        public void DecreaseVolume()
        {
            if (State is OnState)
            {
                Console.WriteLine("Volume decreased");
            }
            else
            {
                Console.WriteLine("TV must be on to adjust volume");
            }
        }
        public void Mute()
        {
            State = new MuteState();
            Console.WriteLine("TV is now muted.");
        }
    }
}
