using SmartHome.Patterns.State;
using SmartHome.Patterns.Strategy;
using SmartHome.Patterns.Visitor;
using SmartHome.Services;

namespace SmartHome.Models
{
    public class TV : IDevice
    {
        public double EnergyUsage { get; set; } = 0.45;

        public ITVState State { get; set; }
        public IVolumeStrategy VolumeStrategy { get; set; }
        public string CurrentMode { get; private set; }
        public string CurrentStatus { get; private set; } = "off";

        public TV()
        {
            // Default state can be off
            State = new OffState();
        }

        public void TurnOn()
        {
            State = new OnState();
            CurrentStatus = "on";
            State.Handle(this);  // Handle state changes
            Console.WriteLine("TV is On");
        }

        public void TurnOff()
        {
            State = new OffState();
            CurrentStatus = "off";
            Console.WriteLine("TV is now off.");
        }

        public void ChangeChannel()
        {
            if (State is OnState)
            {
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
