using SQLite;
namespace Weatherapp.Models;

[Table("ToDoModel")]
public class ToDoModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public Color Culoare3 { get; set; }
    public List<Weatherul> Weather2 { get; set; }

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