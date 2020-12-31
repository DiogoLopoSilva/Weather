using System;
using System.Collections.Generic;
using System.Text;
using Weather.Models;

namespace Weather.ViewModels
{
    public class WeatherDetailViewModel : BaseViewModel
    {      
        private Daily _item;

        public Daily Item        
       {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        public WeatherDetailViewModel(Daily item)
        {
            Title = item.City;

            Item = item;
        }
    }
}
