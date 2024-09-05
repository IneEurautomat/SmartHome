using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public class ThermostatHandler : DeviceHandler
	{
		private readonly OldThermostatAdapter _thermostat;

		public ThermostatHandler(OldThermostatAdapter thermostat)
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
