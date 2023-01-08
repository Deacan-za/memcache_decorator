namespace ComponentMemCache.Console.Models;

internal sealed class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string? Summary { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Date: {Date}" +
               $" Temperature in Celsius: {TemperatureCelsius}" +
               $" Summary: {Summary}";

    }
}

