using DrawableGridLogic.Models;
using System;
using System.Windows;
using System.Windows.Shapes;

namespace DrawableGridLogic.Utilities
{
    public class LineUtilities
    {
        public static double Distance(Point pointA, Point pointB)
        {
            var d1 = new Point(pointA.X - pointB.X, pointA.Y - pointB.Y);
            return Math.Sqrt(d1.X * d1.X + d1.Y * d1.Y);
        }

        public static double LengthOf(DrawableLine line)
        {
            return Distance(line.StartPoint, line.EndPoint);
        }

        public static Point MidPoint(Point pointA, Point pointB)
        {
            return new Point((pointA.X + pointB.X) / 2, (pointA.Y + pointB.Y) / 2);
        }

        public static Point EndPoint(DrawableLine line)
        {
            return new Point(line.X2, line.Y2);
        }

        public static Point StartPoint(DrawableLine line)
        {
            return new Point(line.X1, line.Y1);
        }

        public static PointToLineDistance GetClosestPointOnLineSegment(Point point, DrawableLine line)
        {
            var P = new Vector(point.X, point.Y);
            var A = new Vector(line.X1, line.Y1);
            var B = new Vector(line.X2, line.Y2);
            var AP = P - A;       //Vector from A to P   
            var AB = B - A;       //Vector from A to B  

            var magnitudeAB = AB.LengthSquared;     //Magnitude of AB vector (it's length squared)     
            var ABAPproduct = Vector.Multiply(AP, AB);    //The DOT product of a_to_p and a_to_b     
            var distance = ABAPproduct / magnitudeAB; //The normalized "distance" from a to your closest point  

            if (distance < 0)     //Check if P projection is over vectorAB     
            {
                var pointOnLine = AsPoint(A);
                return new PointToLineDistance(Distance(point, pointOnLine), pointOnLine);
            }
            if (distance > 1)
            {
                var pointOnLine = AsPoint(B);
                return new PointToLineDistance(Distance(point, pointOnLine), pointOnLine);
            }
            else
            {
                var pointOnLine = AsPoint(A + AB * distance);
                return new PointToLineDistance(Distance(point, pointOnLine), pointOnLine);
            }
        }

        private static Point AsPoint(Vector vector)
        {
            return new Point(vector.X, vector.Y);
        }

        public static void ChangeDirection(DrawableLine line)
        {
            var start = StartPoint(line);
            line.X1 = line.X2;
            line.Y1 = line.Y2;
            line.X2 = start.X;
            line.Y2 = start.Y;
        }
    }
}
