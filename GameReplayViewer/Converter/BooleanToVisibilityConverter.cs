using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GameReplayViewer.Converter
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool IsInverse { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visibility = (bool)value;
            if (IsInverse)
            {
                visibility = !visibility;
            }

            return visibility ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
