using Weatherapp.ViewModel;

namespace Weatherapp;

public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

