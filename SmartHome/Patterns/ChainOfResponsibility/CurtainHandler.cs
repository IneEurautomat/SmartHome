using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public class CurtainHandler : DeviceHandler
	{
		private readonly Curtain _curtain;

		public CurtainHandler(Curtain curtain)
		{
			_curtain = curtain;
		}

		protected override bool Handle(SmartHomeSettings settings)
		{
			if (settings.CurtainClosed) _curtain.Close();
			else _curtain.Open();
			return true;
		}
	}
}
