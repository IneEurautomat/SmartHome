using SmartHome.Models;
using SmartHome.Patterns.Prototype;

public class SmartHomeFacade : IPrototype<SmartHomeFacade>
{
    private readonly TV _tv;
    private readonly Light _light;
    private readonly OldThermostatAdapter _thermostat;
    private readonly Curtain _curtain;
    private readonly MusicPlayer _musicPlayer;

    private string _currentMode;

    public SmartHomeFacade(TV tv, Light light, OldThermostatAdapter thermostat, Curtain curtain, MusicPlayer musicPlayer)
    {
        _tv = tv;
        _light = light;
        _thermostat = thermostat;
        _curtain = curtain;
        _musicPlayer = musicPlayer;
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
        ApplySettings(true, true, 21, true, false);
    }

    public void StartPartyMode()
    {
        _currentMode = "party-mode";
        ApplySettings(true, true, 22, false, true);
    }

    public void StartNightMode()
    {
        _currentMode = "night-mode";
        ApplySettings(false, true, 18, true, false);
    }

    public void StartDayMode()
    {
        _currentMode = "day-mode";
        ApplySettings(true, true, 20, false, true);
    }

    public void ResetSettings()
    {
        _currentMode = "default";
        ApplySettings(false, true, 20, true, true);
    }

    public void SetCustomMode(string modeName, bool tvOn, bool lightOn, int temperature, bool curtainClosed, bool musicPlaying)
    {
        _currentMode = modeName;
        ApplySettings(tvOn, lightOn, temperature, curtainClosed, musicPlaying);
    }

    private void ApplySettings(bool tvOn, bool lightOn, int temperature, bool curtainClosed, bool musicPlaying)
    {
        if (tvOn) _tv.On(); else _tv.Off();
        if (lightOn) _light.On(); else _light.Off();
        _thermostat.SetTemperature(temperature);
        if (curtainClosed) _curtain.Close(); else _curtain.Open();
        if (musicPlaying) _musicPlayer.PlayBackgroundMusic(); else _musicPlayer.Off();
    }


	//private void ApplySettings(Dictionary<string, object> settings)
	//{
	//	// Gebruik TryGetValue om de waarde op te halen of een standaardwaarde te gebruiken
	//	settings.TryGetValue("tvOn", out object tvOnObj);
	//	settings.TryGetValue("lightOn", out object lightOnObj);
	//	settings.TryGetValue("temperature", out object temperatureObj);
	//	settings.TryGetValue("curtainClosed", out object curtainClosedObj);
	//	settings.TryGetValue("musicPlaying", out object musicPlayingObj);

	//	bool tvOn = tvOnObj is bool tvOnBool ? tvOnBool : false;
	//	bool lightOn = lightOnObj is bool lightOnBool ? lightOnBool : false;
	//	int temperature = temperatureObj is int temp ? temp : 20;
	//	bool curtainClosed = curtainClosedObj is bool curtainClosedBool ? curtainClosedBool : false;
	//	bool musicPlaying = musicPlayingObj is bool musicPlayingBool ? musicPlayingBool : false;

	//	// Roep nu de bestaande ApplySettings-methode aan
	//	ApplySettings(tvOn, lightOn, temperature, curtainClosed, musicPlaying);
	//}

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
    public SmartHomeFacade Clone()
    {
        return (SmartHomeFacade)MemberwiseClone();
    }
}
