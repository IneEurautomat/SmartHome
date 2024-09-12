using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SmartHome.Services
{
    public class TemperatureService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.open-meteo.com/v1/forecast";
        private const double Latitude = 51.05; // Latitude voor Gent
        private const double Longitude = 3.72; // Longitude voor Gent

        public TemperatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TemperatureEntry> GetDailyTemperatureAsync()
        {
            var url = $"{BaseUrl}?latitude={Latitude}&longitude={Longitude}&hourly=temperature_2m&forecast_days=1&timezone=auto";
            var response = await _httpClient.GetFromJsonAsync<OpenMeteoResponse>(url);

            if (response == null || response.Hourly == null || response.Hourly.Temperature2m == null)
            {
                throw new Exception("Geen weergegevens ontvangen.");
            }

            var currentHour = DateTime.UtcNow.Hour;
            var currentTemperature = response.Hourly.Temperature2m[currentHour];

            return new TemperatureEntry
            {
                Day = DateTime.UtcNow.DayOfWeek.ToString(),
                Temperature = currentTemperature,
                IconUrl = "https://openweathermap.org/img/wn/01d.png" // Placeholder voor het icoon
            };
        }

       

        public class OpenMeteoResponse
        {
            public Hourly Hourly { get; set; }
        }

        public class Hourly
        {
            public List<string> Time { get; set; }
            public List<double> Temperature2m { get; set; }
        }

        public class TemperatureEntry
        {
            public string Day { get; set; }
            public double Temperature { get; set; }
            public string IconUrl { get; set; }
        }
    }
}
