using SharePaint.Models;
using SharePaint.Services.Interfaces;
using SharePaint.Services.Utils;

namespace SharePaint.Services
{
    public class ShapeUnderPointService : IShapeUnderPointService
    {
        public bool IsShapeUnderPoint(Shape shape, Coord2D point)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Triangle:
                    return IsTriangleUnderPoint(shape, point);
                case ShapeType.Rectangle:
                    return IsRectangleUnderPoint(shape, point);
                case ShapeType.Circle:
                    return IsCircleUnderPoint(shape, point);
                default:
                    return false;
            }
        }

        private bool IsTriangleUnderPoint(Shape triangle, Coord2D point)
        {
            // three line function y = ax + b
            // we check if point is on the line
            // then check if point on line is in bounds
            // some equality tolerance

            var x1 = triangle.Points[0].X;
            var x2 = triangle.Points[1].X;
            var x3 = triangle.Points[2].X;
            var y1 = triangle.Points[0].Y;
            var y2 = triangle.Points[1].Y;
            var y3 = triangle.Points[2].Y;

            if (x1.IsEqual(point.X) && y1.IsEqual(point.Y))
            {
                return true;
            }

            if (x2.IsEqual(point.X) && y2.IsEqual(point.Y))
            {
                return true;
            }

            if (x3.IsEqual(point.X) && y3.IsEqual(point.Y))
            {
                return true;
            }

            if (point.IsOnLine(triangle.Points[0], triangle.Points[1]))
            {
                return true;
            }

            if (point.IsOnLine(triangle.Points[0], triangle.Points[2]))
            {
                return true;
            }

            if (point.IsOnLine(triangle.Points[1], triangle.Points[2]))
            {
                return true;
            }

            return false;
        }

        private bool IsRectangleUnderPoint(Shape rectangle, Coord2D point)
        {
            // it has to lie on one of four sides
            // we check if it has x in bounds for left or right y, or y in bounds for top or bottom x
            // some equality tolerance

            var x1 = rectangle.Points[0].X;
            var x2 = rectangle.Points[1].X;
            var y1 = rectangle.Points[0].Y;
            var y2 = rectangle.Points[1].Y;

            if (point.X.BetweenPoints(x1, x2))
            {
                if (y1.IsEqual(point.Y) || y2.IsEqual(point.Y))
                {
                    return true;
                }
            }

            if (point.Y.BetweenPoints(y1, y2))
            {
                if (x1.IsEqual(point.X) || x2.IsEqual(point.X))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCircleUnderPoint(Shape circle, Coord2D point)
        {
            // its distance from circle center must be equal to radius
            // some equality tolerance
            var circleCenter = circle.Points[0];
            var radius = circleCenter.DistanceTo(circle.Points[1]);
            var distanceFromCenter = circleCenter.DistanceTo(point);

            return distanceFromCenter.IsEqual(radius);
        }
    }
}
