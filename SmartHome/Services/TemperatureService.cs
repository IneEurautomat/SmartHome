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


        public TemperatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public class TemperatureEntry
        {
            public string Day { get; set; }
            public double Temperature { get; set; }
            public string IconUrl { get; set; }
        }
    }
}
