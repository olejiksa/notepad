using System;
using Notepad.Controls;
using Windows.UI.Xaml.Data;

namespace Notepad.Converters
{
    public class ObjectToBackstageItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
                return (BackstageItem)value;
            return value;
        }
    }
}
