using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public abstract class DeviceHandler
	{
		protected DeviceHandler _nextHandler;

		public void SetNext(DeviceHandler nextHandler)
		{
			_nextHandler = nextHandler;
		}

		public void HandleRequest(SmartHomeSettings settings)
		{
			if (Handle(settings) && _nextHandler != null)
			{
				_nextHandler.HandleRequest(settings);
			}
		}

		protected abstract bool Handle(SmartHomeSettings settings);
	}
}
