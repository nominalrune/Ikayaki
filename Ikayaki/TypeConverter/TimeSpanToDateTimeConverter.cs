using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ikayaki.TypeConverter
{
    public class TimeSpanToDateTimeConverter : IValueConverter
    {
        public DateTime BaseDate { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return BaseDate.Add((TimeSpan)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (DateTime)value - BaseDate;
        }

    }
}
