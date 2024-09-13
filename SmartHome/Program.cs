using Blazored.LocalStorage;
using SmartHome.Models;
using SmartHome.Patterns.Factory;
using SmartHome.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton(ConfigurationService.Instance);
builder.Services.AddTransient<DeviceFactory>();
builder.Services.AddTransient<SmartHomeFacade>();
builder.Services.AddTransient<TV>();
builder.Services.AddTransient<Light>();
builder.Services.AddTransient<IndoorThermostat>();
builder.Services.AddTransient<MusicPlayer>();
builder.Services.AddTransient<Curtain>();
builder.Services.AddTransient<SecurityCamera>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<SmartHomeFacadeFactory>();
builder.Services.AddTransient<SmartHomeSettings>();


//// Register HttpClient and OutdoorTemperatureService
builder.Services.AddHttpClient<OutdoorTemperatureService>(client =>
{
	client.BaseAddress = new Uri("https://api.weatherapi.com/v1/");
});
builder.Services.AddSingleton(new OutdoorTemperatureService(
	new HttpClient { BaseAddress = new Uri("https://api.weatherapi.com/v1/") },
	"1d2c5de7a6484c0285b91852241209"));


////https://api.weatherapi.com/v1/forecast.json?q=Ghent&days=1&key=1d2c5de7a6484c0285b91852241209

//builder.Services.AddTransient<OutdoorTemperatureService>(provider =>
//{
//	var httpClient = provider.GetRequiredService<HttpClient>();
//	var apiKey = "1d2c5de7a6484c0285b91852241209"; // Replace with your actual API key
//	return new OutdoorTemperatureService(httpClient, apiKey);
//});

// Register System.Action<double> as a delegate
builder.Services.AddTransient<System.Action<double>>(provider =>
{
	// Define the action to be performed when the temperature changes
	return temperature =>
	{
		// Example action: Log the temperature update
		Console.WriteLine($"Temperature updated to: {temperature}°C");
	};
});

// Register ThermostatDisplay with the required dependency
builder.Services.AddTransient<ThermostatDisplay>(provider =>
{
	var temperatureUpdateAction = provider.GetRequiredService<System.Action<double>>();
	return new ThermostatDisplay(temperatureUpdateAction);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
