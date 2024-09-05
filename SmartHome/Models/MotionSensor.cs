using SmartHome.Patterns.Mediator;
using SmartHome.Patterns.Visitor;

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
