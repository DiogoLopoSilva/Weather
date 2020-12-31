using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Weather.Helpers
{
    public class DateConverter : IValueConverter
    {
        // Define the Convert method to change a DateTime object to 
        // a month string.

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds((int)value);
            DateTime date = dateTimeOffset.LocalDateTime;

            if (parameter==null)
            {
                return date;
            }

            switch (parameter.ToString().ToLower())
            {
                case "weekday":
                    return date.DayOfWeek;
                case "short":
                    return date.ToString("d MMMM yyy");
                default:
                    return date;
            }
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
