using Newtonsoft.Json;

namespace Weatherapp.Models.WeatherModels;

public class Current
{
    [JsonProperty("temp_c")]
    public double TempC { get; set; }

    [JsonProperty("temp_f")]
    public double TempF { get; set; }

    [JsonProperty("is_day")]
    public int IsDay { get; set; }

    [JsonProperty("condition")]
    public Condition Condition { get; set; }

    [JsonProperty("humidity")]
    public double Humidity { get; set; }

    [JsonProperty("cloud")]
    public double Cloud { get; set; }

    [JsonProperty("feelslike_c")]
    public double FeelslikeC { get; set; }

    [JsonProperty("feelslike_f")]
    public double FeelslikeF { get; set; }

    [JsonProperty("air_quality")]
    public Dictionary<string,double> AirQuality { get; set; }
}
