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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;
using Weatherapp.Models.WeatherModels;
using Weatherapp.Services;


using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using Weatherapp.Views;
using static Microsoft.Maui.ApplicationModel.Permissions;
using Map = Microsoft.Maui.Controls.Maps.Map;


namespace Weatherapp.ViewModel
{

    public partial class LineViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
    {



        

       
        [ObservableProperty]
        List<Weatherul> weather_10;

        [ObservableProperty]
        List<Weatherul> weather_2;

        string apiKey2 = "039f898f16ef43eca21213452230708&q=Constanța";


        [ObservableProperty]
        bool testElement2;


        [ObservableProperty]
        ObservableCollection<string> airQList2;

        private CancellationTokenSource _cancelTokenSource2;
        private bool _isCheckingLocation2;

        [ObservableProperty]
        WeatherModel weather2;


        [ObservableProperty]
        Color culoare_background2;




        

        private readonly IHttpService _httpService2;

        public ToDoModel Todo { get; private set; }

       

        public LineViewModel(IHttpService httpService)
        {
            
            Title = "Weather2";
            _httpService2 = httpService;
            AirQList2 = new ObservableCollection<string>();
            GetInitalDataCommand.Execute(null);
           
            
        }
        static Color ParseCustomColor(string colorString)
        {
            string[] colorComponents = colorString.Split(',');

            if (colorComponents.Length == 3)
            {
                int red, green, blue;

                if (int.TryParse(colorComponents[0], out red) &&
                    int.TryParse(colorComponents[1], out green) &&
                    int.TryParse(colorComponents[2], out blue))
                {
                    return Color.FromRgb(red, green, blue);
                }
            }

            throw new FormatException("Invalid color string format.");
        }
        [RelayCommand]
        private async void GetInitalData()
        {
            IsBusy = true;
            Pin currentLocation = new Pin();

            try
            {

                _isCheckingLocation2 = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource2 = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource2.Token);

                if (location != null)
                {
                    Weather2 = await _httpService2.GetData(new WeatherModel(), $"https://api.weatherapi.com/v1/forecast.json?key={apiKey2}&q={location.Latitude},{location.Longitude}&days=10&aqi=yes&alerts=no");


                    foreach (KeyValuePair<string, double> pair in Weather2.Current.AirQuality)
                    {
                        AirQList2.Add($"{pair.Key.ToUpper()}\n{pair.Value:0.00}");
                    }


                    IsBusy = false;
                }
                else
                {
                    Weather2 = new WeatherModel();
                }
                Functie3();

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






        }


        void Functie3()
        {

            Weather_10 = new List<Weatherul>
            {
            new Weatherul
            {
                Day = Weather2.Forecast.Forecastday[0].Date[^2 ..] ,
                Degree_max = Weather2.Forecast.Forecastday[0].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[0].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[0].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[0].Day.MintempC
            },
            new Weatherul
            {
                Day = Weather2.Forecast.Forecastday[1].Date[^2..] ,
                Degree_max = Weather2.Forecast.Forecastday[1].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[1].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[1].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[1].Day.MintempC


            },
             new Weatherul
            {
                Day = Weather2.Forecast.Forecastday[2].Date[^ 2 ..] ,
                Degree_max = Weather2.Forecast.Forecastday[2].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[2].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[2].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[2].Day.MintempC


            },
             new Weatherul
            {
                 Day = Weather2.Forecast.Forecastday[3].Date[^ 2 ..] ,
                Degree_max = Weather2.Forecast.Forecastday[3].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[3].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[3].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[3].Day.MintempC


            }, new Weatherul
            {

                Day = Weather2.Forecast.Forecastday[4].Date[^ 2 ..],
                Degree_max = Weather2.Forecast.Forecastday[4].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[4].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[4].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[4].Day.MintempC


            },
              new Weatherul
            {

                Day = Weather2.Forecast.Forecastday[5].Date[^ 2 ..] ,
                Degree_max = Weather2.Forecast.Forecastday[5].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[5].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[5].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[5].Day.MintempC


            }, new Weatherul
            {
               Day = Weather2.Forecast.Forecastday[6].Date[^ 2 ..] ,
                Degree_max = Weather2.Forecast.Forecastday[6].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[6].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[6].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[6].Day.MintempC


            }, new Weatherul
            {

                Day = Weather2.Forecast.Forecastday[7].Date[^ 2 ..],
                Degree_max = Weather2.Forecast.Forecastday[7].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[7].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[7].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[7].Day.MintempC


            },
              new Weatherul
            {

                Day = Weather2.Forecast.Forecastday[8].Date[^ 2 ..] ,
                Degree_max = Weather2.Forecast.Forecastday[8].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[8].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[8].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[8].Day.MintempC


            }, new Weatherul
            {
               Day = Weather2.Forecast.Forecastday[9].Date[^ 2 ..] ,
                Degree_max = Weather2.Forecast.Forecastday[9].Day.MaxtempC,
                Symbol = Weather2.Forecast.Forecastday[9].Day.Condition.Icon,
                Weather_cond = Weather2.Forecast.Forecastday[9].Day.Condition.Text,
                Degree_min = Weather2.Forecast.Forecastday[9].Day.MintempC


            }

        };
            foreach (var days in Weather2.Forecast.Forecastday)
            {
                Weather_2.Add(new Weatherul() { Day = days.Date[^2..], Degree_max = days.Day.MaxtempC, Symbol = days.Day.Condition.Icon, Weather_cond = days.Day.Condition.Text, Degree_min = days.Day.MaxtempC });

            }
            Console.WriteLine("###"+Weather_10[0].Degree_min);
            Console.WriteLine("###"+Weather_10[0].Degree_max);



        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Todo = query["Todo"] as ToDoModel;
            OnPropertyChanged("Todo");

            Console.WriteLine(Todo.Culoare3);
            Culoare_background2 = ParseCustomColor(Todo.Culoare3);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }






}



