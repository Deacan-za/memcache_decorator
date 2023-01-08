using ComponentMemCache.Console.Services;
using Microsoft.Extensions.Configuration;

namespace ComponentMemCache.Console.Providers;

internal class WeatherForecastProviderFactory
{
  private readonly IWeatherForecastService _service;
  private readonly IConfiguration _configuration;

  public WeatherForecastProviderFactory(IWeatherForecastService service, IConfiguration configuration)
  {
    _service = service;
    _configuration = configuration;
  }

  public IWeatherForecastProvider GetWeatherForecastProvider()
  {
    var isCachingEnabled = _configuration["UseCache"]?.Equals("true", StringComparison.InvariantCultureIgnoreCase) ?? false;

    if (isCachingEnabled)
    {
      return new WeatherForecastProvider(new BaseWeatherForecastProvider(_service));
    }

    return new BaseWeatherForecastProvider(_service);
  }
}