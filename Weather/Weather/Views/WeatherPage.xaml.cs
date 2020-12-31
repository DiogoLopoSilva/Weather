using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Services;
using Weather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        WeatherViewModel _viewModel;

        public WeatherPage()
        {
          
            InitializeComponent();

            BindingContext = _viewModel = new WeatherViewModel();
        }
    }
}