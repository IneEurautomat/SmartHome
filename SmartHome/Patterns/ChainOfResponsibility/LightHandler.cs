using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public class LightHandler : DeviceHandler
	{
		private readonly Light _light;

		public LightHandler(Light light)
		{
			_light = light;
		}

		protected override bool Handle(SmartHomeSettings settings)
		{
			if (settings.LightOn) _light.On();
			else _light.Off();
			return true;
		}
	}
}
