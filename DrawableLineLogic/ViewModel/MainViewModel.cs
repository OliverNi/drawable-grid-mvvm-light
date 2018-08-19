using DrawableGridLogic.Events;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DrawableGridLogic.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                Title = "Drawable Grid Application (Design Mode)";
            }
            else
            {
                Title = "Drawable Grid Application";
            }

            DrawableGridViewModel = new DrawableGridViewModel();
            InitializeCommands();
        }

        public string Title { get; set; }

        public DrawableGridViewModel DrawableGridViewModel { get; set; }

        public RelayCommand<SwitchModeEventArgs> SwitchModeCommand { get; set; }

        private void InitializeCommands()
        {
            SwitchModeCommand = new RelayCommand<SwitchModeEventArgs>(OnSwitchMode);
        }

        private void OnSwitchMode(SwitchModeEventArgs e)
        {
            DrawableGridViewModel.ActiveMode = e.SwitchedMode;
        }
    }
}