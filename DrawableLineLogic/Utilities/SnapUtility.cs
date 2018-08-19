using DrawableGridLogic.Models;
using DrawableGridLogic.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace DrawableGridLogic.Utilities
{
    public class SnapUtility
    {
        private const double SnapDistance = 20;

        private readonly List<SnappableLineViewModel> _drawableLines;

        public SnapUtility(List<SnappableLineViewModel> drawableLines)
        {
            _drawableLines = drawableLines;
        }

        public void MoveLine(SnappableLineViewModel line, Point start, Point end)
        {
            SnapLineEndIfItIsCloseToAnotherLine(line, start, end);
        }

        private void SnapLineEndIfItIsCloseToAnotherLine(SnappableLineViewModel line, Point start, Point end)
        {
            foreach (var existingLine in _drawableLines)
            {
                var distance = LineUtilities.GetClosestPointOnLineSegment(end, existingLine.Line);
                if (!IsCloseEnoughToSnap(distance)) continue;

                SnapLineEndToPoint(line, start, distance.ClosestPointInLine);
                return;
            }

            line.Move(start, end);
        }

        private void SnapLineEndToPoint(SnappableLineViewModel line, Point start, Point snapPoint)
        {
            line.Move(start, snapPoint, false);
        }

        private bool IsCloseEnoughToSnap(PointToLineDistance distance)
        {
            return distance.Distance <= SnapDistance;
        }
    }
}
