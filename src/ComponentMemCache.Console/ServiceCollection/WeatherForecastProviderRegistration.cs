using ComponentMemCache.Console.Providers;
using ComponentMemCache.Console.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComponentMemCache.Console.ServiceCollection;

internal static class WeatherForecastProviderRegistration
{
  public static IServiceCollection AddWeatherForecastProvider(this IServiceCollection services)
  {
    services
      .AddSingleton(provider =>
    {
      var weatherForecastService = provider.GetRequiredService<IWeatherForecastService>();
      var configuration = provider.GetRequiredService<IConfiguration>();

      return new WeatherForecastProviderFactory(weatherForecastService, configuration);
    })
      .AddSingleton(provider =>
      {
        var factory = provider.GetRequiredService<WeatherForecastProviderFactory>();
        return factory.GetWeatherForecastProvider();
      });

    return services;
  }
}
