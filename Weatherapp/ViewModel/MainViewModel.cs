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
    public MainViewModel()
    {
        Title = "Weather";

        AirQList = new ObservableCollection<string>();
        GetInitalDataCommand.Execute(null);
    }
    [RelayCommand]
    private async void GetInitalData(IHttpService httpService)
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
                Weather = await httpService.GetData(new WeatherModel(), $"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location.Latitude},{location.Longitude}&days=7&aqi=yes&alerts=no");

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
    public MainViewModel(IHttpService httpService)
    {
        Console.WriteLine("#hfhf");


        Weathers = new List<Weather>
        {
            new Weather
            {
                Hour= Weather.Forecast.Forecastday[1].Hour[1].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[1].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[1].Condition.Icon
            },
            new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[2].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[2].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[2].Condition.Icon


            },
             new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[3].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[3].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[3].Condition.Icon


            },
             new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[4].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[4].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[4].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[5].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[5].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[5].Condition.Icon


            },
              new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[6].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[6].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[6].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[7].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[7].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[7].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[8].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[8].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[8].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[9].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[9].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[9].Condition.Icon


            },
               new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[10].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[10].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[10].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[11].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[11].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[11].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[12].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[12].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[12].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[13].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[13].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[13].Condition.Icon


            },
                new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[14].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[14].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[14].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[15].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[15].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[15].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[16].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[16].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[16].Condition.Icon


            },
                 new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[17].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[17].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[17].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[18].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[18].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[18].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[19].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[19].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[19].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[20].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[20].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[20].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[21].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[21].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[21].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[22].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[22].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[22].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[23].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[23].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[23].Condition.Icon


            }, new Weather
            {
                Hour=Weather.Forecast.Forecastday[1].Hour[24].Time,
                Degree = Weather.Forecast.Forecastday[1].Hour[24].TempC,
                Symbol = Weather.Forecast.Forecastday[1].Hour[24].Condition.Icon


            }
        };
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
    
   


}
