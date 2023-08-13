using Weatherapp.ViewModel;
using Weatherapp.Services;

namespace Weatherapp.Views
{
    public partial class CitiesPage : ContentPage
    {
        private DataViewModel vm;

        public CitiesPage(DbConnection dbConnection)
        {
            InitializeComponent();
            vm = new DataViewModel(dbConnection);
            BindingContext = vm;
        }


    }
}
