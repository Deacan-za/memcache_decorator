using ComponentMemCache.Console;
using ComponentMemCache.Console.Models;
using ComponentMemCache.Console.Providers;
using ComponentMemCache.Console.ServiceCollection;
using ComponentMemCache.Console.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

_ = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json")
  .Build();

using var host = Host.CreateDefaultBuilder(args)
  .ConfigureServices((_, services) =>
    services
      .AddSingleton<IWeatherForecastService, WeatherForecastService>()
      .AddSingleton<IWeatherForecastCache, WeatherForecastCache>()
      .AddWeatherForecastProvider())
  .Build();

await UseCaching(host.Services);
await UseProvider(host.Services);

await host.RunAsync();

static async Task UseCaching(IServiceProvider services)
{
  using var serviceScope = services.CreateScope();
  var provider = serviceScope.ServiceProvider;

  var cache = provider.GetRequiredService<IWeatherForecastCache>();

  var forecasts = await cache.GetForecastsAsync("query1");

  PrintForecasts(forecasts);

  var forecasts2 = await cache.GetForecastsAsync("query1");

  PrintForecasts(forecasts2);
}

static async Task UseProvider(IServiceProvider services)
{
  using var serviceScope = services.CreateScope();
  var provider = serviceScope.ServiceProvider;

  var cache = provider.GetRequiredService<IWeatherForecastProvider>();

  var forecasts = await cache.GetForecastsAsync("query1");

  PrintForecasts(forecasts);

  var forecasts2 = await cache.GetForecastsAsync("query1");

  PrintForecasts(forecasts2);

}

static void PrintForecasts(IEnumerable<WeatherForecast> forecasts2)
{
  foreach (var forecast in forecasts2)
  {
    Console.WriteLine(forecast.ToString());
  }
}
