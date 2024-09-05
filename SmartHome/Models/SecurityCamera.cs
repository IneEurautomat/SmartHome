﻿using SmartHome.Patterns.Mediator;
using SmartHome.Patterns.Visitor;

namespace SmartHome.Models
{
    public class SecurityCamera : IDevice
    {
        public double EnergyUsage { get; set; } = 0.05; // Voorbeeldwaarde

        public string CurrentStatus { get; private set; } = "on";

		public void StartStream()
        {
            Console.WriteLine("Simulated security camera started streaming...");
            // Hier zou je kunnen kiezen om bijvoorbeeld een video af te spelen of iets anders te doen.
        }

        public void StopStream()
        {
            Console.WriteLine("Simulated security camera stopped streaming...");
        }

		public string GetCurrentStatus()
		{
			return CurrentStatus;
		}

        public void TurnOn()
        {
            CurrentStatus = "on";
            Console.WriteLine("Security Camera is On");
        }

        public void TurnOff()
        {
            CurrentStatus = "off";
            Console.WriteLine("Security Camera is Off");
        }

        public void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
