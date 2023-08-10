using Newtonsoft.Json;

namespace Weatherapp.Models.WeatherModels;

public class Locationo
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("region")]
    public string Region { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("lat")]
    public double Lat { get; set; }

    [JsonProperty("lon")]
    public double Lon { get; set; }

    [JsonProperty("tz_id")]
    public string TzId { get; set; }

    [JsonProperty("localtime_epoch")]
    public int LocaltimeEpoch { get; set; }

    [JsonProperty("localtime")]
    public string Localtime { get; set; }
}
