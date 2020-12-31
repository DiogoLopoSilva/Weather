using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Weather.Helpers
{
    public class WeatherImageConverter : IValueConverter
    {
        // Define the Convert method to change a DateTime object to 
        // a month string.

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "https://openweathermap.org/img/wn/" + value + "@" + (parameter?? 4) + "x.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
