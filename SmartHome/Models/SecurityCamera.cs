using SmartHome.Patterns.Mediator;

namespace SmartHome.Models
{
    public class SecurityCamera
    {
        public void StartStream()
        {
            Console.WriteLine("Simulated security camera started streaming...");
            // Hier zou je kunnen kiezen om bijvoorbeeld een video af te spelen of iets anders te doen.
        }

        public void StopStream()
        {
            Console.WriteLine("Simulated security camera stopped streaming...");
        }
    }
}
