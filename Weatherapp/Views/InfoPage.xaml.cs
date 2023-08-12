using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Collections.Generic;
using Weatherapp.ViewModel;

namespace Weatherapp.Views;
public partial class InfoPage : ContentPage
{
    public InfoPage(MainViewModel viewModel)
    {


        InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var hanaLoc = new Location(44.179249, 28.649940);

        MapSpan mapSpan = MapSpan.FromCenterAndRadius(hanaLoc, Distance.FromKilometers(3));
        map2.MoveToRegion(mapSpan);
        map2.Pins.Add(new Pin
        {
            Label = "Here",
            Location = hanaLoc,
        });
    }
}