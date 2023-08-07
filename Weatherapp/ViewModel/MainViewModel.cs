using AlohaKit.Models;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Weatherapp.Models;
using Weatherapp.Models.WeatherModels;
using Weatherapp.Services;

namespace Weatherapp.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    

    [ObservableProperty]
    List<Weather> weathers;
    [ObservableProperty]
    List<Weather> weathersday;

    string apiKey = "a42ff4f6d3d44df0ace113329230108&q=Bucharest";

    [ObservableProperty]
    WeatherModel weather;

    [ObservableProperty]
    ObservableCollection<string> airQList;


    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    private readonly IHttpService _httpService;
    public MainViewModel(IHttpService httpService)
    {
        _httpService = httpService;
        Title = "Weather";
        AirQList = new ObservableCollection<string>();
        GetInitalDataCommand.Execute(null);
    }



    [RelayCommand]
    private async void GetInitalData()
    {
        IsBusy = true;
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Microsoft.Maui.Devices.Sensors.Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
            {
                Weather = await _httpService.GetData(new WeatherModel(), $"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location.Latitude},{location.Longitude}&days=7&aqi=yes&alerts=no");

                foreach (KeyValuePair<string, double> pair in Weather.Current.AirQuality)
                {
                    AirQList.Add($"{pair.Key.ToUpper()}\n{pair.Value:0.00}");
                }
            }
            else
            {
                Weather = new WeatherModel();
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Handle not supported on device exception
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // Handle not enabled on device exception
        }
        catch (PermissionException pEx)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to get location
        }
        IsBusy = false;

    }
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
