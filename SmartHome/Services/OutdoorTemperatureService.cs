using System.Text.Json;

public class OutdoorTemperatureService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public OutdoorTemperatureService(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        _apiKey = apiKey;
    }

    // Standaard stad ingesteld op "Ghent"
    public string City { get; set; } = "Ghent";

    private async Task<string> GetLocationKeyAsync(string city)
    {
        var response = await _httpClient.GetStringAsync($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={_apiKey}&q={city}");
        var locationData = JsonSerializer.Deserialize<List<LocationResponse>>(response);
        if (locationData == null || locationData.Count == 0)
            throw new Exception("Location not found");

        return locationData[0].Key;
    }

    public async Task<WeatherResponse> GetCurrentWeatherAsync(string city)
    {
        var locationKey = await GetLocationKeyAsync(city);
        var response = await _httpClient.GetStringAsync($"http://dataservice.accuweather.com/currentconditions/v1/{locationKey}?apikey={_apiKey}");

        // Debugging: Log de ruwe JSON response
        Console.WriteLine($"Current weather JSON response: {response}");

        var weatherData = JsonSerializer.Deserialize<List<WeatherResponse>>(response);

        if (weatherData == null || weatherData.Count == 0)
            throw new Exception("No data found");

        return weatherData[0];
    }

    public async Task<List<TemperatureEntry>> GetDailyTemperaturesAsync(string city)
    {
        var locationKey = await GetLocationKeyAsync(city);
        var response = await _httpClient.GetStringAsync($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{locationKey}?apikey={_apiKey}");

        // Debugging: Log de ruwe JSON response
        Console.WriteLine($"Daily forecast JSON response: {response}");

        var weatherData = JsonSerializer.Deserialize<DailyWeatherResponse>(response);

        if (weatherData == null || weatherData.DailyForecasts == null)
            throw new Exception("No data found");

        var dailyTemperatures = new List<TemperatureEntry>();

        foreach (var item in weatherData.DailyForecasts)
        {
            dailyTemperatures.Add(new TemperatureEntry
            {
                Day = DateTimeOffset.FromUnixTimeSeconds(item.EpochDate).DateTime.DayOfWeek.ToString(),
                Temperature = item.Temperature.Maximum.Value,
                IconUrl = $"https://developer.accuweather.com/sites/default/files/{item.Day.Icon:00}-s.png"
            });
        }

        return dailyTemperatures;
    }

    public async Task<List<TemperatureEntry>> GetWeeklyTemperaturesAsync(string city)
    {
        var locationKey = await GetLocationKeyAsync(city);
        var response = await _httpClient.GetStringAsync($"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{locationKey}?apikey={_apiKey}");

        // Debugging: Log de ruwe JSON response
        Console.WriteLine($"Weekly forecast JSON response: {response}");

        var weatherData = JsonSerializer.Deserialize<WeeklyWeatherResponse>(response);

        if (weatherData == null || weatherData.DailyForecasts == null)
            throw new Exception("No data found");

        var temperatures = new List<TemperatureEntry>();

        foreach (var day in weatherData.DailyForecasts)
        {
            temperatures.Add(new TemperatureEntry
            {
                Day = DateTimeOffset.FromUnixTimeSeconds(day.EpochDate).DateTime.DayOfWeek.ToString(),
                Temperature = day.Temperature.Maximum.Value,
                IconUrl = $"https://developer.accuweather.com/sites/default/files/{day.Day.Icon:00}-s.png"
            });
        }

        return temperatures;
    }

    // Models for JSON deserialization
    public class LocationResponse
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
    }

    public class WeatherResponse
    {
        public Temperature Temperature { get; set; }
        public List<WeatherIcon> Weather { get; set; }
    }

    public class Temperature
    {
        public Metric Metric { get; set; }
    }

    public class Metric
    {
        public double Value { get; set; }
    }

    public class WeatherIcon
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
    }

    public class DailyWeatherResponse
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    public class WeeklyWeatherResponse
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    public class DailyForecast
    {
        public long EpochDate { get; set; }
        public TemperatureRange Temperature { get; set; }
        public DayPart Day { get; set; }
    }

    public class TemperatureRange
    {
        public Metric Maximum { get; set; }
        public Metric Minimum { get; set; }
    }

    public class DayPart
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
    }

    public class TemperatureEntry
    {
        public string Day { get; set; }
        public double Temperature { get; set; }
        public string IconUrl { get; set; }
    }
}
