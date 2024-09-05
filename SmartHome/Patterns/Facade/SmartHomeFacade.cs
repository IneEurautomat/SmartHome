using SmartHome.Models;
using SmartHome.Patterns.ChainOfResponsibility;
using SmartHome.Patterns.Prototype;
using SmartHome.Patterns.Visitor;

public class SmartHomeFacade : IPrototype<SmartHomeFacade>
{
	private readonly TV _tv;
	private readonly Light _light;
	private readonly OldThermostatAdapter _thermostat;
	private readonly Curtain _curtain;
	private readonly MusicPlayer _musicPlayer;
	private readonly SecurityCamera _securityCamera;

	private string _currentMode;
	private DeviceHandler _handlerChain;

	public SmartHomeFacade(TV tv, Light light, OldThermostatAdapter thermostat, Curtain curtain, MusicPlayer musicPlayer, SecurityCamera securityCamera)
    {
        _tv = tv;
        _light = light;
        _thermostat = thermostat;
        _curtain = curtain;
        _musicPlayer = musicPlayer;
		_securityCamera = securityCamera;

		// Stel de keten van handlers in
		var tvHandler = new TVHandler(_tv);
		var lightHandler = new LightHandler(_light);
		var thermostatHandler = new ThermostatHandler(_thermostat);
		var curtainHandler = new CurtainHandler(_curtain);
		var musicPlayerHandler = new MusicPlayerHandler(_musicPlayer);
		var securityHandler = new SecurityHandler(_securityCamera);

		// Ketting van verantwoordelijkheid opzetten
		tvHandler.SetNext(lightHandler);
		lightHandler.SetNext(thermostatHandler);
		thermostatHandler.SetNext(curtainHandler);
		curtainHandler.SetNext(musicPlayerHandler);
		musicPlayerHandler.SetNext(securityHandler);

		_handlerChain = tvHandler;
	}
	public bool IsTVOn()
	{
		return _tv.GetCurrentStatus() == "On"; // Pas aan volgens hoe de status wordt geretourneerd
	}

	public bool IsLightOn()
	{
		return _light.GetCurrentStatus() == "On"; // Pas aan volgens hoe de status wordt geretourneerd
	}

	public int GetTemperature()
	{
		return _thermostat.GetTemperature(); // Dit is waarschijnlijk al een int
	}

	public bool IsCurtainClosed()
	{
		return _curtain.GetCurrentStatus() == "Closed"; // Pas aan volgens hoe de status wordt geretourneerd
	}

	public bool IsMusicPlaying()
	{
		return _musicPlayer.GetCurrentStatus() == "Playing"; // Pas aan volgens hoe de status wordt geretourneerd
	}
	public void StartMovieMode()
    {
		_currentMode = "cozy-evening";
		ApplySettings(new SmartHomeSettings
		{
			TVOn = true,
			LightOn = true,
			Temperature = 21,
			CurtainClosed = true,
			MusicPlaying = false,
			SecurityOn = true
		});
	}

    public void StartPartyMode()
    {
		_currentMode = "party-mode";
		ApplySettings(new SmartHomeSettings
		{
			TVOn = true,
			LightOn = true,
			Temperature = 22,
			CurtainClosed = false,
			MusicPlaying = true,
			SecurityOn = true
		});
	}

    public void StartNightMode()
    {
		_currentMode = "night-mode";
		ApplySettings(new SmartHomeSettings
		{
			TVOn = false,
			LightOn = true,
			Temperature = 18,
			CurtainClosed = true,
			MusicPlaying = false,
			SecurityOn = true
		});
	}

    public void StartDayMode()
    {
		_currentMode = "day-mode";
		ApplySettings(new SmartHomeSettings
		{
			TVOn = true,
			LightOn = true,
			Temperature = 20,
			CurtainClosed = false,
			MusicPlaying = true,
			SecurityOn = true
		});
	}

    public void ResetSettings()
    {
		_currentMode = "default";
		ApplySettings(new SmartHomeSettings
		{
			TVOn = false,
			LightOn = true,
			Temperature = 20,
			CurtainClosed = true,
			MusicPlaying = true,
			SecurityOn = true
		});
	}

	public void SetCustomMode(string modeName, SmartHomeSettings settings)
	{
		_currentMode = modeName;
		ApplySettings(settings);
	}

	private void ApplySettings(SmartHomeSettings settings)
	{
		// Roep de keten van handlers aan
		_handlerChain.HandleRequest(settings);
	}

	public string GetCurrentMode()
    {
        return _currentMode;
    }
    public string GetCurrentSettings()
    {
        var tvStatus = _tv.GetCurrentStatus();  // Method to get current status
        var lightStatus = _light.GetCurrentStatus(); // Method to get current status
        var temperature = _thermostat.GetTemperature(); // Assuming this method exists
        var curtainStatus = _curtain.GetCurrentStatus(); // Method to get current status
        var musicStatus = _musicPlayer.GetCurrentStatus(); // Method to get current status
		var cameraStatus = _securityCamera.GetCurrentStatus();  // Method to get current status

		return $"TV: {tvStatus}, Light: {lightStatus}, Temperature: {temperature}°C, Curtain: {curtainStatus}, Music: {musicStatus}";
    }
    public object ToSerializableObject()
    {
        return new
        {
            TVStatus = _tv.GetCurrentStatus(),
            LightStatus = _light.GetCurrentStatus(),
            Temperature = _thermostat.GetTemperature(),
            CurtainStatus = _curtain.GetCurrentStatus(),
            MusicStatus = _musicPlayer.GetCurrentStatus(),
            CurrentMode = _currentMode
        };
    }
    public double CalculateTotalEnergyUsage()
    {
        var energyVisitor = new EnergyUsageVisitor();
        _tv.Accept(energyVisitor);
        _light.Accept(energyVisitor);
        _thermostat.Accept(energyVisitor);
        _curtain.Accept(energyVisitor);
        _musicPlayer.Accept(energyVisitor);
        _securityCamera.Accept(energyVisitor);
        // Voeg Accept-aanroepen toe voor andere apparaten indien nodig
        return energyVisitor.TotalEnergyUsage;
    }

    public IEnumerable<(string DeviceName, double EnergyUsage)> GetEnergyUsages()
    {
        var energyVisitor = new EnergyUsageVisitor();
        var devices = new List<IDevice> { _tv, _light, _thermostat, _curtain, _musicPlayer, _securityCamera };
        foreach (var device in devices)
        {
            device.Accept(energyVisitor);
        }
        return devices.Select(device => (device.GetType().Name, device.EnergyUsage));
    }

    public SmartHomeFacade Clone()
    {
        return (SmartHomeFacade)MemberwiseClone();
    }
}
