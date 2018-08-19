using DrawableGridLogic.Utilities;
using GalaSoft.MvvmLight;
using System.Windows;

namespace DrawableGridLogic.Models
{
    public class DrawableLine : ObservableObject
    {
        private double _x1;
        private double _x2;
        private double _y1;
        private double _y2;

        public double X1
        {
            get => _x1;
            set 
            {
                _x1 = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Length));
                RaisePropertyChanged(nameof(MidPoint));
            }
        }
        public double X2
        {
            get => _x2;
            set
            {
                _x2 = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Length));
                RaisePropertyChanged(nameof(MidPoint));
            }
        }
        public double Y1
        {
            get => _y1;
            set
            {
                _y1 = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Length));
                RaisePropertyChanged(nameof(MidPoint));
            }
        }
        public double Y2
        {
            get => _y2;
            set
            {
                _y2 = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Length));
                RaisePropertyChanged(nameof(MidPoint));
            }
        }

        public double Length { get { return LineUtilities.LengthOf(this); } }

        public Point StartPoint
        {
            get => new Point(X1, Y1);
        }

        public Point EndPoint
        {
            get => new Point(X2, Y2);
        }

        public Point MidPoint
        {
            get => LineUtilities.MidPoint(StartPoint, EndPoint);
        }
    }
}
