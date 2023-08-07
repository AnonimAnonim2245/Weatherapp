using Newtonsoft.Json;

namespace Weatherapp.Models.WeatherModels;
public class Forecast
{
    [JsonProperty("forecastday")]
    public List<Forecastday> Forecastday { get; set; }
}