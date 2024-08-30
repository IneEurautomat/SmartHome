namespace SmartHome.Models
{
    public class Curtain : IDevice
    {
        public void Open()
        {
            Console.WriteLine("Curtain is Open");
        }

        public void Close()
        {
            Console.WriteLine("Curtain is Closed");
        }
        public void HalfOpen()
        {
            Console.WriteLine("Curtain is HalfOpen");
        }

        public void On()
        {
            Console.WriteLine("Curtain is opening or closing");
        }

        public void Off()
        {
            Console.WriteLine("Curtain has stopped opening or closing");
        }
    }
}
