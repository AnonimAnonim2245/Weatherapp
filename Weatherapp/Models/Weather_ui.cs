namespace Weatherapp.Models;

public class Weatherul
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

    public double Degree_max { get; set; }
    
    public double Degree_min { get; set; }

    public string Weather_cond { get; set; }

    public string Symbol { get; set; }

    public string Hour { get; set; }
    public string Day { get; set; }


}
