namespace Weatherapp.Models;

public class Weather
{
    private double degree;

    public double Degree
    {
        get
        {
            return degree;
        }
        set
        {
            degree = value;
        }
    }

    public int Degrees { get; set; }
    public string Symbol { get; set; }

    public string Hour { get; set; }
    public int Day { get; set; }


}
