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
    List<Weatherul> weathers;
    [ObservableProperty]
    List<Weatherul> weathersday;

    string apiKey = "a42ff4f6d3d44df0ace113329230108&q=Bucharest";

    [ObservableProperty]
    WeatherModel weather;

    [ObservableProperty]
    ObservableCollection<string> airQList;


    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;
    ObservableCollection<ChartItem> _chartCollection = new ObservableCollection<ChartItem>();
    public ObservableCollection<ChartItem> ChartCollection
    {
        get => _chartCollection;
        set => _chartCollection = value;
    }


    private readonly IHttpService _httpService;
    public MainViewModel(IHttpService httpService)
    {
        Title = "Weather";
        _httpService = httpService;
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
            Functie();
            Functie2();
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
   
    void Functie()
     {
        Console.WriteLine(Weather.Forecast.Forecastday[0].Hour[0].Time);


        Weathers = new List<Weatherul>
        {
            new Weatherul
            {
                Hour= Weather.Forecast.Forecastday[0].Hour[0].Time[^5..],
                Degree = Weather.Forecast.Forecastday[0].Hour[0].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[0].Condition.Icon
            },
            new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[1].Time[^5..],
                Degree = Weather.Forecast.Forecastday[0].Hour[1].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[1].Condition.Icon


            },
             new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[2].Time[^5..],
                Degree = Weather.Forecast.Forecastday[0].Hour[2].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[2].Condition.Icon


            },
             new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[3].Time[^5..],
                Degree = Weather.Forecast.Forecastday[0].Hour[3].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[3].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[4].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[4].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[4].Condition.Icon


            },
              new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[5].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[5].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[5].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[6].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[6].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[6].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[7].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[7].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[7].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[8].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[8].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[8].Condition.Icon


            },
               new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[9].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[9].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[9].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[10].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[10].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[10].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[11].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[11].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[11].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[12].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[12].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[12].Condition.Icon


            },
                new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[13].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[13].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[13].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[14].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[14].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[14].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[15].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[15].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[15].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[16].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[16].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[16].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[17].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[17].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[17].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[18].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[18].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[18].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[19].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[19].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[19].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[20].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[20].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[20].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[21].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[21].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[21].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[22].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[22].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[22].Condition.Icon


            }, new Weatherul
            {
                Hour=Weather.Forecast.Forecastday[0].Hour[23].Time[^ 5 ..],
                Degree = Weather.Forecast.Forecastday[0].Hour[23].TempC,
                Symbol = Weather.Forecast.Forecastday[0].Hour[23].Condition.Icon


            }
        };
        Weathersday = new List<Weatherul>
        {
            new Weatherul
            {
                Day = Weather.Forecast.Forecastday[0].Date[^2 ..] ,
                Degree_max = Weather.Forecast.Forecastday[0].Day.MaxtempC,
                Symbol = Weather.Forecast.Forecastday[0].Day.Condition.Icon,
                Weather_cond = Weather.Forecast.Forecastday[0].Day.Condition.Text,
                Degree_min = Weather.Forecast.Forecastday[0].Day.MintempC
            },
            new Weatherul
            {
                Day = Weather.Forecast.Forecastday[1].Date[^2..] ,
                Degree_max = Weather.Forecast.Forecastday[1].Day.MaxtempC,
                Symbol = Weather.Forecast.Forecastday[1].Day.Condition.Icon,
                Weather_cond = Weather.Forecast.Forecastday[1].Day.Condition.Text,
                Degree_min = Weather.Forecast.Forecastday[1].Day.MintempC


            },
             new Weatherul
            {
                Day = Weather.Forecast.Forecastday[2].Date[^ 2 ..] ,
                Degree_max = Weather.Forecast.Forecastday[2].Day.MaxtempC,
                Symbol = Weather.Forecast.Forecastday[2].Day.Condition.Icon,
                Weather_cond = Weather.Forecast.Forecastday[2].Day.Condition.Text,
                Degree_min = Weather.Forecast.Forecastday[2].Day.MintempC


            },
             new Weatherul
            {
                 Day = Weather.Forecast.Forecastday[3].Date[^ 2 ..] ,
                Degree_max = Weather.Forecast.Forecastday[3].Day.MaxtempC,
                Symbol = Weather.Forecast.Forecastday[3].Day.Condition.Icon,
                Weather_cond = Weather.Forecast.Forecastday[3].Day.Condition.Text,
                Degree_min = Weather.Forecast.Forecastday[3].Day.MintempC


            }, new Weatherul
            {

                Day = Weather.Forecast.Forecastday[4].Date[^ 2 ..],
                Degree_max = Weather.Forecast.Forecastday[4].Day.MaxtempC,
                Symbol = Weather.Forecast.Forecastday[4].Day.Condition.Icon,
                Weather_cond = Weather.Forecast.Forecastday[4].Day.Condition.Text,
                Degree_min = Weather.Forecast.Forecastday[4].Day.MintempC


            },
              new Weatherul
            {

                Day = Weather.Forecast.Forecastday[5].Date[^ 2 ..] ,
                Degree_max = Weather.Forecast.Forecastday[5].Day.MaxtempC,
                Symbol = Weather.Forecast.Forecastday[5].Day.Condition.Icon,
                Weather_cond = Weather.Forecast.Forecastday[5].Day.Condition.Text,
                Degree_min = Weather.Forecast.Forecastday[5].Day.MintempC


            }, new Weatherul
            {
               Day = Weather.Forecast.Forecastday[6].Date[^ 2 ..] ,
                Degree_max = Weather.Forecast.Forecastday[6].Day.MaxtempC,
                Symbol = Weather.Forecast.Forecastday[6].Day.Condition.Icon,
                Weather_cond = Weather.Forecast.Forecastday[6].Day.Condition.Text,
                Degree_min = Weather.Forecast.Forecastday[6].Day.MintempC


            }

        };
        
        

    }
    void Functie2()
    {
        const int val1 = 20, val2 = 21, val3 = 45;

        ChartCollection = new ObservableCollection<ChartItem>()
        {
           {new ChartItem(){ Value= (int)(Weather.Forecast.Forecastday[0].Day.MaxtempC), Label = "12°", IsLabelBold = false}},
            {new ChartItem(){ Value= (int)(Weather.Forecast.Forecastday[1].Day.MaxtempC), Label = "14°"} },
            {new ChartItem(){ Value= (int)Weather.Forecast.Forecastday[2].Day.MaxtempC, Label = "16°"} },
            {new ChartItem(){ Value= (int)Weather.Forecast.Forecastday[3].Day.MaxtempC, Label = "14°"} },
            {new ChartItem(){ Value= (int)Weather.Forecast.Forecastday[4].Day.MaxtempC, Label = "16°"} },
            {new ChartItem(){ Value= (int)Weather.Forecast.Forecastday[5].Day.MaxtempC, Label = "16°"}},
            {new ChartItem(){ Value= (int)Weather.Forecast.Forecastday[6].Day.MaxtempC, Label = "17°"} },
        };
        Console.WriteLine("$#"+ChartCollection[1].Value);
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

