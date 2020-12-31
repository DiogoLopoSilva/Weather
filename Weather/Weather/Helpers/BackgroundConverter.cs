using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Weather.Models;
using Xamarin.Forms;

namespace Weather.Helpers
{
    public class BackgroundConverter : IValueConverter
    {
        // Define the Convert method to change a DateTime object to 
        // a month string.

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var weather = (Current)value;

            return weather.Dt>weather.Sunrise && weather.Dt<weather.Sunset? Application.Current.Resources["BackgroundDay"] : Application.Current.Resources["BackgroundNight"];
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
