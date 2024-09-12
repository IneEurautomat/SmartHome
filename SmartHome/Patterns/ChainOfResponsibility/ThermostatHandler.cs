using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public class ThermostatHandler : DeviceHandler
	{
		private readonly IndoorThermostat _thermostat;

		public ThermostatHandler(IndoorThermostat thermostat)
		{
			_thermostat = thermostat;
		}

		protected override bool Handle(SmartHomeSettings settings)
		{
			_thermostat.SetTemperature(settings.Temperature);
			return true;
		}
	}
}
