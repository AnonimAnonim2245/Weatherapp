using System.Data.Common;
using Weatherapp.ViewModel;
using Weatherapp.Services;

namespace Weatherapp.Views
{

    public partial class ForecastPage : ContentPage
    {
        public string TodoId { get; set; }
        public ForecastPage(LineViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    

    }
}


