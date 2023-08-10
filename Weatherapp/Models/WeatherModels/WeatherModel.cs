using Newtonsoft.Json;

namespace Weatherapp.Models.WeatherModels;

public class WeatherModel
{
    [JsonProperty("location")]
    public Locationo Locationo { get; set; }

    [JsonProperty("current")]
    public Current Current { get; set; }

    [JsonProperty("forecast")]
    public Forecast Forecast { get; set; }
}
