using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrawableGridLogic.ViewModel
{
    public class SnappableLineViewModel : DrawableLineViewModel
    {
        private readonly int _gridSize = 20; //TODO Fix hardcoding

        public override void Move(Point start, Point end)
        {
            base.Move(SnappedPointOf(start, _gridSize), SnappedPointOf(end, _gridSize));
        }

        public void Move(Point start, Point end, bool shouldSnapEndToGrid)
        {
            if (shouldSnapEndToGrid)
                Move(start, end);
            else
                base.Move(SnappedPointOf(start, _gridSize), end);
        }

        protected static Point SnappedPointOf(Point point, int gridSize)
        {
            var xSnap = point.X % gridSize;
            var ySnap = point.Y % gridSize;

            // If it's less than half the grid size, snap left/up 
            // (by subtracting the remainder), 
            // otherwise move it the remaining distance of the grid size right/down
            // (by adding the remaining distance to the next grid point).
            if (xSnap <= gridSize / 2.0)
                xSnap *= -1;
            else
                xSnap = gridSize - xSnap;
            if (ySnap <= gridSize / 2.0)
                ySnap *= -1;
            else
                ySnap = gridSize - ySnap;

            xSnap += point.X;
            ySnap += point.Y;
            return new Point(xSnap, ySnap);
        }
    }
}
