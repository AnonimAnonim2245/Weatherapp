using AlohaKit.Models;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using Weatherapp.Models;
using Weatherapp.Models.WeatherModels;
using Weatherapp.Services;
namespace Weatherapp.ViewModel;

using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using static Microsoft.Maui.ApplicationModel.Permissions;
using Map = Microsoft.Maui.Controls.Maps.Map;
public partial class MainViewModel : BaseViewModel
{
    

    [ObservableProperty]
    List<Weatherul> weathers;
    [ObservableProperty]
    List<Weatherul> weathersday;

    string apiKey = "a42ff4f6d3d44df0ace113329230108&q=Constanța";

    [ObservableProperty]
    WeatherModel weather;

    [ObservableProperty]
    bool testElement;


    [ObservableProperty]
    ObservableCollection<string> airQList;

    [ObservableProperty]
    ObservableCollection<ChartItem> chartCollection;

    [ObservableProperty]
    ObservableCollection<ChartItem> secondChartCollection;

    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    [ObservableProperty]
    int time_start;
    [ObservableProperty]
    int time_current;
    [ObservableProperty]
    int time_end;

    [ObservableProperty]
    Color culoare;

    [ObservableProperty]
    string text_timp;

    [ObservableProperty]
    int percentage;

    [ObservableProperty]
    Color culoare_background;

    [ObservableProperty]
    string time_a;

    [ObservableProperty]
    string time_b;

    [ObservableProperty]
    string time_c;

    [ObservableProperty]
    int ok2;

    [ObservableProperty]
    string direction_wind;

    [ObservableProperty]
    string uv;

    [ObservableProperty]
    List<Pin> pins = new List<Pin>();

    [ObservableProperty]
    MapSpan dist2;

    private readonly IHttpService _httpService;
    
    public MainViewModel(IHttpService httpService)
    {
        Title = "Weather";
        _httpService = httpService;
        AirQList = new ObservableCollection<string>();
        ChartCollection = new ObservableCollection<ChartItem>();
        SecondChartCollection = new ObservableCollection<ChartItem>();

        GetInitalDataCommand.Execute(null);
    }
    [RelayCommand]
    private async void GetInitalData()
    {
        IsBusy = true;
        Pin currentLocation = new Pin();

        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
            {
                Weather = await _httpService.GetData(new WeatherModel(), $"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location.Latitude},{location.Longitude}&days=7&aqi=yes&alerts=no");
                currentLocation.Location = new Location(Weather.Locationo.Lat, Weather.Locationo.Lon);
                currentLocation.Label = "Sunt aici!";
                currentLocation.Type = PinType.SearchResult;
                foreach (KeyValuePair<string, double> pair in Weather.Current.AirQuality)
                {
                    AirQList.Add($"{pair.Key.ToUpper()}\n{pair.Value:0.00}");
                }

               
                IsBusy = false;
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

        double a, b;
        a=Weather.Locationo.Lat; 
        b=Weather.Locationo.Lon;
        

        Pins = new List<Pin>
                {
                new Pin
                {
                    Location = new Location(a, b),
                    Label = "I'm here",
                    Address = Weather.Locationo.Name,
                    Type = PinType.SearchResult
                },
                currentLocation
                      
                };

    }
    

    void Functie()
     {
        Console.WriteLine(Weather.Forecast.Forecastday[0].Hour[0].Time);

        Distance dist = Distance.FromMiles(2);
        Dist2 = MapSpan.FromCenterAndRadius(Pins[0].Location, dist);
        Map Locatie = new Map();
        MapSpan mapSpan = MapSpan.FromCenterAndRadius(Pins[0].Location, Distance.FromKilometers(3));
        map.MoveToRegion(mapSpan);

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
        TestElement = true;
        TestElement = false;
        foreach (var days in Weather.Forecast.Forecastday)
        {
            ChartCollection.Add(new ChartItem() { Value = Convert.ToInt16(days.Day.MaxtempC), Label = $"{Convert.ToInt16(days.Day.MaxtempC)}°", IsLabelBold = false });

        }
        TestElement = true;
        TestElement = false;
        foreach (var days in Weather.Forecast.Forecastday)
        {
            SecondChartCollection.Add(new ChartItem() { Value = Convert.ToInt16(days.Day.MintempC), Label = $"{Convert.ToInt16(days.Day.MintempC)}°", IsLabelBold = false });

        }
        Time_c = Weather.Locationo.Localtime[^5..];
        Culoare_background = Color.FromRgb(40, 120, 255);
        Culoare = Color.FromRgb(255, 204, 51);
        Text_timp = "SUNRISE & SUNSET";
        if (Weather.Forecast.Forecastday[0].Astro.IsMoonUp == 0)
        {
            Culoare = Color.FromRgb(255, 250, 250);
            Culoare_background = Color.FromRgb(0, 0, 139);
            Text_timp = "MOONRISE & MOONSET";
            Time_a = Weather.Forecast.Forecastday[0].Astro.Moonrise;
            Time_b = Weather.Forecast.Forecastday[0].Astro.Moonset;
            string a, b;
            a = Time_a;
            b = "No moonrise";
            Boolean result = a.Contains(b);

            if(result==true)
            {
                Percentage = 0;
                Ok2 = 0;
            }
            else
            {
                Ok2 = 1;
            }

            

        }
        else
        {
            
            Time_a = Weather.Forecast.Forecastday[0].Astro.Sunrise;
            Time_b = Weather.Forecast.Forecastday[0].Astro.Sunset;
            Console.WriteLine("$$$" + Time_b);
            
            string a, b;
            a = Time_a;
            b = "No sunrise";
            Boolean result = a.Contains(b);

            if (result == true)
            {
                Percentage = 0;
                Ok2= 0; 
            }
            else
            {
                Ok2 = 1;
            }


        }

        if(Ok2==1)
        {

            char a1, b1;

            if (Time_a[0] == ' ')
            {
                a1 = '0';
            }
            else
                a1 = Time_a[0];

            if (Time_b[0] == ' ')
            {
                b1 = '0';
            }
            else
                b1 = Time_b[0];


            Time_start = (10 * ((int)(a1)-48) + ((int)(Time_a[1])-48)) % 12;
            Time_end = (10 * ((int)(b1)-48) + ((int)(Time_b[1])-48)) % 12;
            Boolean result2 = Time_a.Contains('P');
            Boolean result3 = Time_b.Contains('P');

            if (result2 == true)
            {
                Time_start += 12;
            }
            if (result3 == true)
            {
                Time_end += 12;
            }

            Console.WriteLine("RHHR" + Time_end);

            Time_start = Time_start * 60 + (((int)(Time_a[3])-48)*10 + ((int)(Time_a[4])-48));
            Time_end = Time_end * 60 + (((int)(Time_b[3])-48)*10 + ((int)(Time_b[4])-48));

            if (Time_start > Time_end)
                Time_end += (24 * 60);
            Console.WriteLine("RHHRy" + Time_start);
            Console.WriteLine("RHHRh" + Time_end);
            Console.WriteLine("RHHRh" + Time_c[0]);
            Console.WriteLine("RHHRh" + Time_c[1]);

            int a, b, c, d;
            if (Time_c[0]==' ')
                a = (int)(Time_c[0]) - 32;
            else
                a = (int)(Time_c[0]) - 48;

            b = (int)(Time_c[1]) - 48;
            c = (int)(Time_c[3]) - 48;
            d = (int)(Time_c[4]) - 48;
            Console.WriteLine("RHHR#" + a);
            Console.WriteLine("RHHR#" + b);
            Console.WriteLine("RHHR#" + c);
            Console.WriteLine("RHHR#" + d);

            Time_current = (a * 10 + b); 
            Console.WriteLine("RHHRt" + Time_current);
            Time_current = Time_current *60 + (c * 10 + d);
            Console.WriteLine("RHHRt" + Time_current);

            Percentage = ((Time_current-Time_start)*100)/(Time_end - Time_start);

            if((Time_current - Time_start) > (Time_end - Time_start) && Weather.Forecast.Forecastday[0].Astro.IsMoonUp == 1)
            {
                Culoare = Color.FromRgb(255, 250, 250);
                Culoare_background = Color.FromRgb(0, 0, 139);
                Text_timp = "MOONRISE & MOONSET";
                Time_a = Weather.Forecast.Forecastday[0].Astro.Moonrise;
                Time_b = Weather.Forecast.Forecastday[0].Astro.Moonset;
                Percentage = 0;
                
            }
            Console.WriteLine("RHHR gfhhf" + Percentage);






        }

        if (Weather.Current.WindDegree >= 315 || Weather.Current.WindDegree <= 45)
        {

            Direction_wind = "North";

            if (Weather.Current.WindDegree == 315)
                Direction_wind += "-West";
            else if (Weather.Current.WindDegree == 45)
                Direction_wind += "-East";
        }
        else if (Weather.Current.WindDegree > 45 && Weather.Current.WindDegree < 135)
        {
            Direction_wind = "East";
        }
        else if(Weather.Current.WindDegree >=135 && Weather.Current.WindDegree<=225)
        {
            Direction_wind = "North";

            if (Weather.Current.WindDegree == 315)
                Direction_wind += "-West";
            else if (Weather.Current.WindDegree == 45)
                Direction_wind += "-East";
        }
        else if(Weather.Current.WindDegree > 225 && Weather.Current.WindDegree < 315)
        {
            Direction_wind = "West";

        }

        if (Weather.Current.Uv >= 1 && Weather.Current.Uv <= 2)
            Uv = "Low";
        else if (Weather.Current.Uv >= 3 && Weather.Current.Uv <= 5)
            Uv = "Moderate";
        else if (Weather.Current.Uv >= 6 && Weather.Current.Uv <= 7)
            Uv = "High";
        else if (Weather.Current.Uv >= 8 && Weather.Current.Uv <= 10)
            Uv = "Very High";
        else if (Weather.Current.Uv >= 11)
            Uv = "Extreme";


        Console.WriteLine("###" + Weather.Forecast.Forecastday[0].Astro.IsMoonUp);
        Console.WriteLine("###" + Weather.Forecast.Forecastday[0].Astro.Sunrise);
        Console.WriteLine("###" + Weather.Forecast.Forecastday[0].Astro.Sunset);

    }
   







}

