using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Services;
using Weather.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        public IApiService ApiService => DependencyService.Get<IApiService>();

        private CancellationTokenSource _cts;

        private Location _currentLocation;

        public Command LoadItemsCommand { get; }

        public Command<Daily> ItemTapped { get; }

        public WeatherData LocalWeatherData { get; set; }

        public string LocalCity { get; set; }

        private List<Daily> _dailyData;

        public List<Daily> DailyData
        {
            get => _dailyData;

            set
            {
                SetProperty(ref _dailyData, value);
            }
        }

        private WeatherData _weatherData;

        public WeatherData WeatherData {

            get => _weatherData;

            set
            {
                SetProperty(ref _weatherData, value);
            }
        }

        private string _city;

        public string City
        {
            get => _city;

            set
            {
                SetProperty(ref _city, value);
            }
        }

        private Command _searchCommand;
        public Command SearchCommand => _searchCommand ?? (_searchCommand = new Command(SearchCity));

        private string _search;

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);

                if (String.IsNullOrEmpty(_search))
                {
                    LoadLocalData();
                }
            }
        }

        public WeatherViewModel()
        {
            Title = "Weather";

            ItemTapped = new Command<Daily>(OnItemSelected);

            LoadLocalCity();
        }

        async void OnItemSelected(Daily item)
        {
            if (item == null)
                return;

            item.City = City;

            await Shell.Current.Navigation.PushAsync(new WeatherDetailPage(item));
        }

        public void LoadLocalData()
        {
            WeatherData = LocalWeatherData;
            DailyData = LocalWeatherData.Daily;
            City = LocalCity;
        }

        public async void LoadLocalCity()
        {
            await GetLocationInfo();
            await LoadWeatherData();
            LocalWeatherData = WeatherData;
            LoadLocalData();
        }

        public async void SearchCity()
        {
            IsBusy = true;

            if (string.IsNullOrEmpty(Search))
            {
                LoadLocalData();
                IsBusy = false;
                return;
            }

            var CityName = Search;

            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await ApiService.GetObjectAsync<City>(
                url,
                "data/2.5/",
                "weather?q=" +CityName+"&appid=" + App.Current.Resources["APIKey"].ToString());

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("City not found", "Try another city", "Accept");

                Search = "";
                IsBusy = false;

                return;
            }

            City cityAux = (City)response.Result;
            City = cityAux.Name;

            _currentLocation = new Location();
            _currentLocation.Latitude = cityAux.Coord.Lat;
            _currentLocation.Longitude = cityAux.Coord.Lon;

            IsBusy = false;

            await LoadWeatherData();
        }

        public async Task GetLocationInfo()
        {
            IsBusy = true;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", "No connection found", "Accept");
                Process.GetCurrentProcess().CloseMainWindow();
            }

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                _cts = new CancellationTokenSource();
                _currentLocation = await Geolocation.GetLocationAsync(request, _cts.Token);

                if (_currentLocation == null)
                {
                    await App.Current.MainPage.DisplayAlert("ERROR", "Current location not found", "Accept");
                    Process.GetCurrentProcess().CloseMainWindow();
                }

                var result = await Geocoding.GetPlacemarksAsync(_currentLocation);

                if (result.Any())
                    LocalCity = result.FirstOrDefault()?.Locality;

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", fnsEx.Message, "Accept");
                Process.GetCurrentProcess().CloseMainWindow();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "Accept");
                Process.GetCurrentProcess().CloseMainWindow();
            }

            IsBusy = false;
        }

        public async Task LoadWeatherData()
        {
            IsBusy = true; 

            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await ApiService.GetObjectAsync<WeatherData>(
                url,
                "data/2.5/",
                "onecall?lat="+_currentLocation.Latitude+"&lon="+_currentLocation.Longitude+"&units=metric&exclude=alerts,minutely,hourly&appid=" + App.Current.Resources["APIKey"].ToString());            

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", "Error message", "Accept");
                Process.GetCurrentProcess().CloseMainWindow();
            }

            WeatherData = (WeatherData)response.Result;

            WeatherData.Daily.RemoveAt(0);
            WeatherData.Daily.RemoveAt(WeatherData.Daily.Count-1);
            DailyData = WeatherData.Daily;

            IsBusy = false;
        }
    }
}
