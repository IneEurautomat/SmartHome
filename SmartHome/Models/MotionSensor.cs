using SmartHome.Patterns.Mediator;

namespace SmartHome.Models
{
    public class MotionSensor
    {
        private IMediator _mediator;

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void DetectMotion()
        {
            Console.WriteLine("Motion Sensor detects motion.");
            _mediator?.Notify(this, "MotionDetected");
        }

        public void NoMotion()
        {
            Console.WriteLine("Motion Sensor detects no motion.");
            _mediator?.Notify(this, "MotionStopped");
        }
    }
}
