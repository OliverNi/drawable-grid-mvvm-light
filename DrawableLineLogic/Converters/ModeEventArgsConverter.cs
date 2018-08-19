using DrawableGridLogic.Events;
using GalaSoft.MvvmLight.Command;
using System;
using static DrawableGridLogic.ViewModel.DrawableGridViewModel;

namespace DrawableGridLogic.Converters
{
    public class ModeEventArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            return new SwitchModeEventArgs((Mode) Enum.Parse(typeof(Mode), (string)parameter));
        }
    }
}
