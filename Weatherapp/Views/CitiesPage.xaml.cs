using Weatherapp.ViewModel;

namespace Weatherapp.Views
{
    public partial class CitiesPage : ContentPage
    {
        
        public CitiesPage(DataViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

        }


    }
}
