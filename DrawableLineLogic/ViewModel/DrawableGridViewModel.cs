using DrawableGridLogic.Events;
using DrawableGridLogic.Models;
using DrawableGridLogic.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DrawableGridLogic.ViewModel
{
    public class DrawableGridViewModel : ViewModelBase
    {
        private Mode _activeMode;

        public DrawableGridViewModel()
        {
            Grid = new Grid(20, 20);
            ActiveMode = Mode.Draw;
            PreviewLine = new SnappableLineViewModel();
            InitializeCommands();
        }

        public delegate void ModeChangeEventHandler(object source, SwitchModeEventArgs e);
        public event ModeChangeEventHandler ModeChange;

        public enum Mode { Draw, Edit };

        public Mode ActiveMode
        {
            get => _activeMode;
            set
            {
                _activeMode = value;
                RaisePropertyChanged();
                ModeChange?.Invoke(this, new SwitchModeEventArgs(ActiveMode));
            }
        }

        public Grid Grid { get; set; }
        public SnappableLineViewModel PreviewLine { get; set; }
        public ObservableCollection<DrawableLineViewModel> Lines { get; set; } =
            new ObservableCollection<DrawableLineViewModel>();

        public RelayCommand<DrawableGridMouseEventArgs> MouseDownCommand { get; set; }
        public RelayCommand<DrawableGridMouseEventArgs> MouseUpCommand { get; set; }
        public RelayCommand<DrawableGridMouseEventArgs> MouseMoveCommand { get; set; }

        private void InitializeCommands()
        {
            MouseDownCommand = new RelayCommand<DrawableGridMouseEventArgs>(OnMouseDown);
            MouseUpCommand = new RelayCommand<DrawableGridMouseEventArgs>(OnMouseUp);
            MouseMoveCommand = new RelayCommand<DrawableGridMouseEventArgs>(OnMouseMove);
        }

        private void OnMouseDown(DrawableGridMouseEventArgs e)
        {
            PreviewLine.Line = new DrawableLine() //@TODO replace with factory
            {
                X1 = e.Position.X,
                Y1 = e.Position.Y,
                X2 = e.Position.X,
                Y2 = e.Position.Y
            };
        }

        private void OnMouseUp(DrawableGridMouseEventArgs e)
        {
            if (PreviewLine.Line == null) return;
            if (LineUtilities.LengthOf(PreviewLine.Line) > 0)
            {
                SnappableLineViewModel newLine = new SnappableLineViewModel() { Line = PreviewLine.Line };
                ModeChange += newLine.OnGridModeChange;

                Lines.Add(newLine);
            }

            PreviewLine.Line = null;
        }

        private void OnMouseMove(DrawableGridMouseEventArgs e)
        {
            if (PreviewLine.Line == null) return;
            if (LineUtilities.Distance(new Point(PreviewLine.Line.X1, PreviewLine.Line.Y1), e.Position) > 10)
            {
                PreviewLine.Move(PreviewLine.Line.StartPoint, e.Position);
                new SnapUtility(
                    Lines.OfType<SnappableLineViewModel>().ToList()
                )
                .MoveLine(PreviewLine, PreviewLine.Line.StartPoint, e.Position); //@TODO improve performance
            }
        }
    }
}