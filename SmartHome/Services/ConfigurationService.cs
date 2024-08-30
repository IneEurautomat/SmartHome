namespace SmartHome.Services
{
	public class ConfigurationService
	{
		//SINGLETON Pattern
		//---------------------------------------------
		private static readonly Lazy<ConfigurationService> _instance =
			new Lazy<ConfigurationService>(() => new ConfigurationService());

		public static ConfigurationService Instance => _instance.Value;

		public string GetSetting(string key)
		{
			// Return some mock settings
			return key switch
			{
				"TemperatureUnit" => "Celsius",
				"DefaultVolume" => "15",
				_ => "Unknown"
			};
		}
	}
}
