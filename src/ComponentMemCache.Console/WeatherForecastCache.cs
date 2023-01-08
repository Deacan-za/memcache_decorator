using ComponentMemCache.Console.Models;
using ComponentMemCache.Console.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace ComponentMemCache.Console;

internal sealed class WeatherForecastCache : IWeatherForecastCache
{
  private readonly IWeatherForecastService _weatherForecastService;
  private readonly IConfiguration _config;
  private readonly MemoryCache _memoryCache;

  public WeatherForecastCache(IWeatherForecastService weatherForecastService, IConfiguration config)
  {
    _weatherForecastService = weatherForecastService;
    _config = config;
    _memoryCache = new MemoryCache(new MemoryCacheOptions());
  }

  public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(string key)
  {
    var isEnabled = _config["UseCache"]?.Equals("true", StringComparison.InvariantCultureIgnoreCase) ?? false;

    if (!isEnabled)
    {
      return await _weatherForecastService.GetAsync();
    }

    return (await _memoryCache.GetOrCreateAsync(key, _ => _weatherForecastService.GetAsync()))!;
  }

}
