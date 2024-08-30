using SmartHome.Models;

namespace SmartHome.Services
{
	//FACTORY Pattern
	//---------------------------------------------

	public class DeviceFactory
	{
		public IDevice CreateDevice(string type)
		{
			return type switch
			{
				"TV" => new TV(),
				"Light" => new Light(),
				"MusicPlayer" => new MusicPlayer(),
				"Thermostat" => new OldThermostat(),
				"Curtain" => new Curtain(),

				_ => throw new ArgumentException("Invalid device type")
			};
		}
	}
}
