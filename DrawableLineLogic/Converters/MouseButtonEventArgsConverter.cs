using DrawableGridLogic.Events;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace DrawableGridLogic.Converters
{
    public class MouseButtonEventArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var args = (MouseEventArgs) value;
            var element = (FrameworkElement) parameter;
            return new DrawableGridMouseEventArgs(args.GetPosition(element));
        }
    }
}
