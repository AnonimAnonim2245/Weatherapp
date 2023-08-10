using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Weatherapp.ViewModel;

namespace Weatherapp;

public partial class MainPage : ContentPage
{
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var hanaLoc = new Location(20.7557, -155.9880);

        MapSpan mapSpan = MapSpan.FromCenterAndRadius(hanaLoc, Distance.FromKilometers(3));
        map.MoveToRegion(mapSpan);
        map.Pins.Add(new Pin
        {
            Label = "Welcome to .NET MAUI!",
            Location = hanaLoc,
        });
    }
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

