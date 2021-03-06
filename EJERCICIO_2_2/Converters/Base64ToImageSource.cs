using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace EJERCICIO_2_2.Converters
{
    public class Base64ToImageSource : IValueConverter  
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] bytes = System.Convert.FromBase64String(value.ToString());
            return ImageSource.FromStream(() => new MemoryStream (bytes));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
