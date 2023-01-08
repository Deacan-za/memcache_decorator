using ComponentMemCache.Console.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ComponentMemCache.Console.Providers;

internal class WeatherForecastProvider : IWeatherForecastProvider
{

  private readonly IWeatherForecastProvider _provider;
  private readonly MemoryCache _cache;

  public WeatherForecastProvider(IWeatherForecastProvider provider)
  {
    _provider = provider;
    _cache = new MemoryCache(new MemoryCacheOptions());
  }

  /// <inheritdoc />
  public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(string key)
  {
    return (await _cache.GetOrCreateAsync(key, _ => _provider.GetForecastsAsync(key)))!;
  }
}