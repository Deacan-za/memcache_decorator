using ComponentMemCache.Console.Models;

namespace ComponentMemCache.Console;

internal interface IWeatherForecastCache
{
  Task<IEnumerable<WeatherForecast>> GetForecastsAsync(string key);
}