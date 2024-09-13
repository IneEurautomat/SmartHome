﻿using SmartHome.Patterns.Observer;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class OutdoorTemperatureService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
	private List<ITemperatureObserver> _observers = new List<ITemperatureObserver>();

	public OutdoorTemperatureService(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        Console.WriteLine($"BaseUrl: {_httpClient.BaseAddress?.ToString()}");
        _apiKey = apiKey;
    }

    public async Task<CurrentWeatherResponse> GetCurrentWeatherAsync(string location)
    {		
		var response = await _httpClient.GetFromJsonAsync<CurrentWeatherResponse>($"current.json?key={_apiKey}&q={location}");
		return response;
	}

	public async Task<ForecastResponse> Get3DayForecastAsync(string location)
    {
		var response = await _httpClient.GetFromJsonAsync<ForecastResponse>($"forecast.json?key={_apiKey}&q={location}&days=3");
		return response;
	}
	public void RegisterObserver(ITemperatureObserver observer)
	{
		_observers.Add(observer);
	}

	private void NotifyObservers(double newTemp)
	{
		foreach (var observer in _observers)
		{
			observer.UpdateTemperature(newTemp);
		}
	}
	public class CurrentWeatherResponse
    {
		[JsonPropertyName("location")]
		public Location Location { get; set; }
		[JsonPropertyName("current")]
		public Current Current { get; set; }
    }

    public class Location
    {
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("region")]
		public string Region { get; set; }
		[JsonPropertyName("country")]
		public string Country { get; set; }
    }

    public class Current
    {
		[JsonPropertyName("temp_c")]
		public double TempC { get; set; }
		[JsonPropertyName("condition")]
		public Condition Condition { get; set; }
    }

    public class Condition
    {
		[JsonPropertyName("text")]
		public string Text { get; set; }
		[JsonPropertyName("icon")]
		public string Icon { get; set; }
    }

    public class ForecastResponse
    {
		[JsonPropertyName("location")]
		public Location Location { get; set; }
		[JsonPropertyName("forecast")]
		public Forecast Forecast { get; set; }
    }

    public class Forecast
    {
		[JsonPropertyName("forecastday")]
		public List<ForecastDay> ForecastDay { get; set; }
    }

    public class ForecastDay
    {
		[JsonPropertyName("date")]
		public string Date { get; set; }
		[JsonPropertyName("day")]
		public Day Day { get; set; }
    }

    public class Day
    {
		[JsonPropertyName("maxtemp_c")]
		public double MaxTempC { get; set; }
		[JsonPropertyName("mintemp_c")]
		public double MinTempC { get; set; }
		[JsonPropertyName("condition")]
		public Condition Condition { get; set; }
    }
}
