using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class OutdoorTemperatureService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public OutdoorTemperatureService(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        Console.WriteLine($"BaseUrl: {_httpClient.BaseAddress?.ToString()}");
        _apiKey = apiKey;
    }

    public async Task<CurrentWeatherResponse> GetCurrentWeatherAsync(string location)
    {

		var url = $"forecast.json?key={_apiKey}&q={location}";
        var response = await _httpClient.GetAsync(url);
        Console.WriteLine(response);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CurrentWeatherResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<ForecastResponse> Get3DayForecastAsync(string location)
    {
        var url = $"forecast.json?key={_apiKey}&q={location}&days=3";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ForecastResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public class CurrentWeatherResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }

    public class Current
    {
        public double TempC { get; set; }
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
    }

    public class ForecastResponse
    {
        public Location Location { get; set; }
        public Forecast Forecast { get; set; }
    }

    public class Forecast
    {
        public List<ForecastDay> ForecastDay { get; set; }
    }

    public class ForecastDay
    {
        public string Date { get; set; }
        public Day Day { get; set; }
    }

    public class Day
    {
        public double MaxTempC { get; set; }
        public double MinTempC { get; set; }
        public Condition Condition { get; set; }
    }
}
