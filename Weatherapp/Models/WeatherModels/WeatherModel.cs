using Newtonsoft.Json;

namespace Weatherapp.Models.WeatherModels;

public class WeatherModel
{
    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("current")]
    public Current Current { get; set; }
}
