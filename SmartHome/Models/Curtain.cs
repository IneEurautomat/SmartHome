namespace SmartHome.Models
{
    public class Curtain : IDevice
    {
        public string CurrentStatus { get; private set; } = "closed";

        public void Open()
        {
            CurrentStatus = "open";
            Console.WriteLine("Curtain is Open");
        }

        public void Close()
        {
            CurrentStatus = "close";
            Console.WriteLine("Curtain is Closed");
        }
        public void HalfOpen()
        {
            CurrentStatus = "halfopen";
            Console.WriteLine("Curtain is HalfOpen");
        }

        public void On()
        {
            CurrentStatus = "on";
            Console.WriteLine("Curtain is opening or closing");
        }

        public void Off()
        {
            CurrentStatus = "off";
            Console.WriteLine("Curtain has stopped opening or closing");
        }

        public string GetCurrentStatus()
        {
            return CurrentStatus;
        }
    }
}
