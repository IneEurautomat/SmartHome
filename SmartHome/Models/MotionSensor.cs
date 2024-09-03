using SmartHome.Patterns.Mediator;

namespace SmartHome.Models
{
    public class MotionSensor
    {
        public event Action OnMotionDetected;

        public void SimulateMotion()
        {
            OnMotionDetected?.Invoke();
            Console.WriteLine("Simulated motion detected!");
        }
    }
}
