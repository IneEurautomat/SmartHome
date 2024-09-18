using SmartHome.Patterns.State;
using SmartHome.Patterns.State.TVStatePatterns;
using SmartHome.Patterns.Visitor;
using SmartHome.Services;
using SmartHome.Patterns.Strategy.TVStrategy;

namespace SmartHome.Models
{
    public class TV : IDevice
    {
        public double EnergyUsage { get; set; } = 0.45;

        public ITVState State { get; set; }
        public IVolumeStrategy VolumeStrategy { get; set; }
        public string CurrentMode { get; private set; }
        public string CurrentStatus { get; private set; } = "off";
        private DeviceContext _context;


        public TV()
        {
            _context = new DeviceContext("TV", new OffState());
        }

        public void TurnOn()
        {
            _context.Request();
            CurrentStatus = "on";
            State.Handle(this);  // Handle state changes
            Console.WriteLine("TV is On");
        }

        public void TurnOff()
        {
            _context.Request();
            CurrentStatus = "off";
            Console.WriteLine("TV is now off.");
        }

        public void ChangeChannel()
        {
            if (State is OnState)
            {
                _context.Request();
                CurrentStatus = "changing-channel";
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
                _context.Request();
                CurrentStatus = "increase-volume";
                Console.WriteLine("Volume increased");
                VolumeStrategy?.AdjustVolume(this); // Apply volume strategy
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
                CurrentStatus = "decrease-volume";
                Console.WriteLine("Volume decreased");
                VolumeStrategy?.AdjustVolume(this); // Apply volume strategy
            }
            else
            {
                Console.WriteLine("TV must be on to adjust volume");
            }
        }

        public void Mute()
        {
            State = new MuteState();
            CurrentStatus = "mute";
            Console.WriteLine("TV is now muted.");
        }

        public void SetVolumeStrategy(IVolumeStrategy strategy)
        {
            VolumeStrategy = strategy;
            CurrentMode = strategy.GetType().Name.Replace("Mode", "").ToLower(); // Update mode
            Console.WriteLine($"Volume strategy set to {strategy.GetType().Name}");
        }

        public string GetCurrentMode()
        {
            return CurrentMode;
        }

        public string GetCurrentStatus()
        {
            return CurrentStatus;
        }

        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
