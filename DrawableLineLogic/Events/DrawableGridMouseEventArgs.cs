using System;
using System.Windows;

namespace DrawableGridLogic.Events
{
    public class DrawableGridMouseEventArgs : EventArgs
    {
        public Point Position { get; set; }

        public DrawableGridMouseEventArgs(Point position)
        {
            Position = position;
        }
    }
}
