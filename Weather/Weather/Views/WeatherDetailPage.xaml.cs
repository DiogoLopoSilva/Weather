using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
using Weather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherDetailPage : ContentPage
    {
        WeatherDetailViewModel _viewModel;

        public WeatherDetailPage(Daily item)
        {
            InitializeComponent();


            BindingContext = _viewModel = new WeatherDetailViewModel(item);
        }
    }
}