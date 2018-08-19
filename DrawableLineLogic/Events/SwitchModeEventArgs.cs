using System;
using static DrawableGridLogic.ViewModel.DrawableGridViewModel;

namespace DrawableGridLogic.Events
{
    public class SwitchModeEventArgs : EventArgs
    {
        public Mode SwitchedMode { get; set; }

        public SwitchModeEventArgs(Mode newMode)
        {
            SwitchedMode = newMode;
        }
    }
}
