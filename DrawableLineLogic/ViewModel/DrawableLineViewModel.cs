using DrawableGridLogic.Events;
using DrawableGridLogic.Models;
using DrawableGridLogic.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using static DrawableGridLogic.ViewModel.DrawableGridViewModel;

namespace DrawableGridLogic.ViewModel
{
    public class DrawableLineViewModel : ViewModelBase
    {
        private DrawableLine _line;
        private bool _isSelected;
        private bool _isSelectable;
   
        public DrawableLineViewModel()
        {
            InitializeCommands();
        }

        public RelayCommand<DrawableGridMouseEventArgs> MouseUpCommand { get; set; }

        public DrawableLine Line
        {
            get => _line;
            set
            {
                _line = value;
                RaisePropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        public virtual void Move(Point start, Point end)
        {
            Line.X1 = start.X;
            Line.Y1 = start.Y;
            Line.X2 = end.X;
            Line.Y2 = end.Y;
        }

        public PointToLineDistance DistanceFrom(Point point)
        {
            return LineUtilities.GetClosestPointOnLineSegment(point, Line);
        }

        public void OnGridModeChange(object source, SwitchModeEventArgs e)
        {
            _isSelectable = Mode.Edit.Equals(e.SwitchedMode);
        }

        private void InitializeCommands()
        {
            MouseUpCommand = new RelayCommand<DrawableGridMouseEventArgs>(OnMouseUp);
        }

        private void OnMouseUp(DrawableGridMouseEventArgs e)
        {
            if (_isSelectable)
            {
                IsSelected = !IsSelected;
            }
        }
    }
}
