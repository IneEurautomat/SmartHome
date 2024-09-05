using SmartHome.Models;

namespace SmartHome.Patterns.ChainOfResponsibility
{
	public class SmartHomeSystem
	{
		private DeviceHandler chain;

		public SmartHomeSystem(TV tv, Light light, Curtain curtain, SecurityCamera security)
		{
			// Create handlers
			var tvHandler = new TVHandler(tv);
			var lightHandler = new LightHandler(light);
			var curtainHandler = new CurtainHandler(curtain);
			var securityHandler = new SecurityHandler(security);

			// Set up the chain of responsibility
			tvHandler.SetNext(lightHandler);
			lightHandler.SetNext(curtainHandler);
			curtainHandler.SetNext(securityHandler);

			// Set the chain
			chain = tvHandler;
		}

		public void ActivateSleepMode()
		{
			Console.WriteLine("Activating Sleep Mode...");

			// Maak een nieuwe SmartHomeSettings aan met de juiste configuratie voor de slaapmodus
			SmartHomeSettings sleepModeSettings = new SmartHomeSettings
			{
				TVOn = false,
				LightOn = false,
				Temperature = 18,
				CurtainClosed = true,
				MusicPlaying = false,
				SecurityOn = true // Zorg ervoor dat deze eigenschap is toegevoegd aan de SmartHomeSettings-klasse
			};

			// Roep de HandleRequest-methode aan met het SmartHomeSettings-object
			chain.HandleRequest(sleepModeSettings);
		}
	}
}
