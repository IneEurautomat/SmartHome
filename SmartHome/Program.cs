using Blazored.LocalStorage;
using SmartHome.Models;
using SmartHome.Patterns.Factory;
using SmartHome.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton(ConfigurationService.Instance);
builder.Services.AddTransient<DeviceFactory>();
builder.Services.AddTransient<SmartHomeFacade>();
builder.Services.AddTransient<TV>();
builder.Services.AddTransient<Light>();
builder.Services.AddTransient<OldThermostat>();
builder.Services.AddTransient<OldThermostatAdapter>();
builder.Services.AddTransient<MusicPlayer>();
builder.Services.AddTransient<Curtain>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<SmartHomeFacadeFactory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
