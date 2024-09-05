using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public class SecurityHandler : DeviceHandler
	{
		private readonly SecurityCamera _camera;

		public SecurityHandler(SecurityCamera camera)
		{
			_camera = camera;
		}
		protected override bool Handle(SmartHomeSettings settings)
		{
			// Pas de security logica toe op basis van de ontvangen instellingen
			if (settings.SecurityOn)
			{
				Console.WriteLine("Activating security cameras...");
				_camera.StartStream();
				return true; // Request is afgehandeld
			}
			else
			{
				_camera.StopStream();
				Console.WriteLine("Deactivated security cameras...");

			}
			return false; // Request niet afgehandeld
		}
	}
}
