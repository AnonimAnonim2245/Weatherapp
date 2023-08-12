using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Collections.Generic;
using Weatherapp.ViewModel;

namespace Weatherapp.Views;

public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel viewModel)
    {
        
        InitializeComponent();
        BindingContext = viewModel;
    }
    

}

