using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static OutdoorTemperatureService;

namespace SmartHome.Services
{
    public class TemperatureService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "HEbpLE4ZmAqeC0Nhqjc6syPzNGKv22xt"; // Voeg je API-sleutel toe hier

        public TemperatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TemperatureEntry> GetDailyTemperatureAsync(string locationKey, bool metric = false)
        {
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{locationKey}?apikey={_apiKey}&metric={metric.ToString().ToLower()}";

            var response = await _httpClient.GetStringAsync(url);
            var weatherData = JsonSerializer.Deserialize<DailyForecastResponse>(response);

            if (weatherData == null || weatherData.DailyForecasts.Count == 0)
                throw new Exception("No data found");

            var dailyForecast = weatherData.DailyForecasts[0];

            return new TemperatureEntry
            {
                Day = DateTime.UtcNow.DayOfWeek.ToString(),
                Temperature = dailyForecast.Temperature.Max
            };
        }

        public async Task<List<TemperatureEntry>> GetWeeklyTemperaturesAsync(string locationKey, bool metric = false)
        {
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/10day/{locationKey}?apikey={_apiKey}&metric={metric.ToString().ToLower()}";

            var response = await _httpClient.GetStringAsync(url);
            var weatherData = JsonSerializer.Deserialize<DailyForecastResponse>(response);

            if (weatherData == null || weatherData.DailyForecasts.Count == 0)
                throw new Exception("No data found");

            var weeklyTemperatures = new List<TemperatureEntry>();

            foreach (var forecast in weatherData.DailyForecasts)
            {
                weeklyTemperatures.Add(new TemperatureEntry
                {
                    Day = DateTimeOffset.FromUnixTimeSeconds(forecast.EpochDate).DateTime.DayOfWeek.ToString(),
                    Temperature = forecast.Temperature.Max
                });
            }

            return weeklyTemperatures;
        }
    }

    public class DailyForecastResponse
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    public class DailyForecast
    {
        public Temperature Temperature { get; set; }
        public long EpochDate { get; set; }
    }
    public class TempEntry
    {
        public string Day { get; set; }
        public double Temperature { get; set; }
        public string IconUrl { get; set; }
    }

    public class Temperature
    {
        public double Day { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Night { get; set; }
        public double Eve { get; set; }
        public double Morn { get; set; }
    }
}
