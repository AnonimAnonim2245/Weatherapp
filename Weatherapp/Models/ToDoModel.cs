using SQLite;
using Weatherapp.Models.WeatherModels;

namespace Weatherapp.Models;

[Table("ToDoModel")]
public class ToDoModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Culoare3 { get; set; }

    private string name;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Ok { get; set; }

}