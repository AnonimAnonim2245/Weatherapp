using AlohaKit.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Weatherapp.Models;

namespace Weatherapp.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    List<Weather> weathers;
    [ObservableProperty]
    List<Weather> weathersday;
    ObservableCollection<ChartItem> _chartCollection = new ObservableCollection<ChartItem>()
        {
            {new ChartItem(){ Value= 12, Label = "12°", IsLabelBold = false}},
            {new ChartItem(){ Value= 14, Label = "14°"} },
            {new ChartItem(){ Value= 16, Label = "16°"} },
            {new ChartItem(){ Value= 14, Label = "14°"} },
            {new ChartItem(){ Value= 16, Label = "16°"} },
            {new ChartItem(){ Value= 16, Label = "16°"}},
            {new ChartItem(){ Value= 17, Label = "17°"} },
            {new ChartItem(){ Value= 15, Label = "15°"} },
            {new ChartItem(){ Value= 14, Label = "14°"} },
            {new ChartItem(){ Value= 16, Label = "16°"} },
            {new ChartItem(){ Value= 15, Label = "15°"} },
            {new ChartItem(){ Value= 14, Label = "14°"} }
        };


    public ObservableCollection<ChartItem> ChartCollection
    {
        get => _chartCollection;
        set => _chartCollection = value;
    }
    ObservableCollection<ChartItem> _secondchartCollection = new ObservableCollection<ChartItem>()
    {
            {new ChartItem(){ Value= 3, Label = "3°", IsLabelBold = false}},
            {new ChartItem(){ Value= 4, Label = "4°"} },
            {new ChartItem(){ Value= 4, Label = "4°"} },
            {new ChartItem(){ Value= 5, Label = "5°"} },
            {new ChartItem(){ Value= 4, Label = "4°"} },
            {new ChartItem(){ Value= 3, Label = "3°"}},
            {new ChartItem(){ Value= 6, Label = "6°"} },
            {new ChartItem(){ Value= 4, Label = "4°"} },
            {new ChartItem(){ Value= 2, Label = "2°"} },
            {new ChartItem(){ Value= 4, Label = "4°"} },
            {new ChartItem(){ Value= 7, Label = "7°"} },
            {new ChartItem(){ Value= 5, Label = "5°"} }
    };


    public ObservableCollection<ChartItem> secondChartCollection
    {
        get => _secondchartCollection;
        set => _secondchartCollection = value;
    }
    public MainViewModel()
    {
        
        Weathers = new List<Weather>
        {
            new Weather
            {
                Hour="0:00",
                Degree = "12C",
                Symbol = "\ue900"


            },
            new Weather
            {
               Hour="0:00",
                Degree = "12C",
                Symbol = "\ue900"


            },
            new Weather
            {
            Hour="0:00",
            Degrees=8,
                Degree = "12C",
                Symbol = "\ue900"


            },
            new Weather
            {
               Hour="0:00",
                Degree = "12C",
                Symbol = "\ue900"


            },
            new Weather
            {
                Hour="0:00",
                Degree = "12C",
                Symbol = "\ue900"



            },
            new Weather
            {
                Hour="0:00",
                Degree = "12C",
                Symbol = "\ue900"


            },new Weather
            {
                Hour="0:00",
                Degree = "12C",
                Symbol = "\ue900"


            },new Weather
            {
               Hour="0:00",
                Degree = "12C",
                Symbol = "\ue900"


            },new Weather
            {
                  Hour="0:00",
                Degree = "12C",
                Symbol = "\ue900"


            },new Weather
            {
                Hour="0:00",

                Degree = "12C",
                Symbol = "\ue900"


            },new Weather
            {Hour = "0:00",
                Degree = "12C",
                Symbol = "\ue900"


            },new Weather
            {
                Hour = "0:00",
                Degree = "12C",
                Symbol = "\ue900"


            }
        };
        Weathersday = new List<Weather>
        {
            new Weather
            {
                Day = 9,
                Degrees = 12,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 10,
                Degrees=14,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 11,

                Degrees=16,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 12,
                Degrees = 14,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 13,
                Degrees = 16,
                Symbol = "\ue900"



            },
            new Weather
            {
                Day = 14,
                Degrees = 16,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 15,
                Degrees = 17,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 16,
                Degrees = 15,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 17,
                Degrees = 14,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 18,
                Degrees = 16,
                Symbol = "\ue900"
            },
            new Weather
            {
                Day = 19,
                Degrees = 15,
                Symbol = "\ue900"


            },
            new Weather
            {
                Day = 20,
                Degrees = 14,
                Symbol = "\ue900"


            }
        };
     
}
   
    

}
