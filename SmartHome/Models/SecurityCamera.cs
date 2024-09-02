using SmartHome.Patterns.Mediator;

namespace SmartHome.Models
{
    public class SecurityCamera
    {
        private IMediator _mediator;

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void StartRecording()
        {
            Console.WriteLine("Security Camera starts recording.");
        }

        public void StopRecording()
        {
            Console.WriteLine("Security Camera stops recording.");
        }

        public void MotionDetected()
        {
            Console.WriteLine("Security Camera detects motion.");
            _mediator?.Notify(this, "MotionDetected");
        }

        public void MotionStopped()
        {
            Console.WriteLine("Security Camera detects motion stopped.");
            _mediator?.Notify(this, "MotionStopped");
        }
    }
}
