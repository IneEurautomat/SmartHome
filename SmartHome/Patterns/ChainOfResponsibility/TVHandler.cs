using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public class TVHandler : DeviceHandler
	{
		private readonly TV _tv;

		public TVHandler(TV tv)
		{
			_tv = tv;
		}

		protected override bool Handle(SmartHomeSettings settings)
		{
			if (settings.TVOn) _tv.On();
			else _tv.Off();
			return true;
		}
	}
}
