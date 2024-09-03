using SmartHome.Models;

namespace SmartHome.Patterns.Mediator
{
    public class SecurityMediator : IMediator
    {
        private SecurityCamera _camera;
        private MotionSensor _sensor;

        public SecurityMediator(SecurityCamera camera, MotionSensor sensor)
        {
            _camera = camera;
            _sensor = sensor;

            _sensor.OnMotionDetected += _camera.StartStream;

        }

        public void Notify(object sender, string ev)
        {
            if (ev == "MotionDetected")
            {
                Console.WriteLine("Mediator reacts on motion detected and triggers camera.");
                _camera.StartStream();
            }
            else if (ev == "MotionStopped")
            {
                Console.WriteLine("Mediator reacts on motion stopped and stops camera.");
                _camera.StopStream();
            }
        }
    }

}
