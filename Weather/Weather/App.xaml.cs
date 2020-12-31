using System;
using Weather.Services;
using Weather.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IApiService,ApiService>(); //NAO DÁ, VER
            //DependencyService.Register<ApiService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
