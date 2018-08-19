using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using static DrawableGridLogic.ViewModel.DrawableGridViewModel;

namespace DrawableGridLogic.Converters
{
    public class DrawModeIsActiveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Mode activeMode = (Mode)value;
            Debug.WriteLine("Mode is draw: " + Mode.Draw.Equals(activeMode));
            return Mode.Draw.Equals(activeMode);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
