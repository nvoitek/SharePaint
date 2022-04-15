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
            // ~5% equality tolerance

            var x1 = triangle.Points[0].X;
            var x2 = triangle.Points[1].X;
            var x3 = triangle.Points[2].X;
            var y1 = triangle.Points[0].Y;
            var y2 = triangle.Points[1].Y;
            var y3 = triangle.Points[2].Y;

            if (Double.AreEqual(x1, point.X) && Double.AreEqual(y1, point.Y))
            {
                return true;
            }

            if (Double.AreEqual(x2, point.X) && Double.AreEqual(y2, point.Y))
            {
                return true;
            }

            if (Double.AreEqual(x3, point.X) && Double.AreEqual(y3, point.Y))
            {
                return true;
            }

            if ((Double.LessOrEqual(x1, point.X) && Double.LessOrEqual(point.X, x2)) || (Double.LessOrEqual(x2, point.X) && Double.LessOrEqual(point.X, x1)))
            {
                if (Double.AreEqual(x1,x2))
                {
                    if ((Double.LessOrEqual(y1, point.Y) && Double.LessOrEqual(point.Y, y2)) || Double.LessOrEqual(y2, point.Y) && Double.LessOrEqual(point.Y, y1))
                    {
                        return true;
                    }
                }
                else
                {
                    var b = (x1 * y2 - x2 * y1) / (x1 - x2);
                    double a;
                    if (Double.AreEqual(x1, 0))
                    {
                        a = (y2 - b) / x2;
                    }
                    else
                    {
                        a = (y1 - b) / x1;
                    }
                    var yOnSide = a * point.X + b;

                    if (Double.AreEqual(point.Y, yOnSide))
                    {
                        return true;
                    }
                }


            }

            if ((Double.LessOrEqual(x1, point.X) && Double.LessOrEqual(point.X, x3)) || (Double.LessOrEqual(x3, point.X) && Double.LessOrEqual(point.X, x1)))
            {
                if (Double.AreEqual(x1, x3))
                {
                    if ((Double.LessOrEqual(y1, point.Y) && Double.LessOrEqual(point.Y, y3)) || Double.LessOrEqual(y3, point.Y) && Double.LessOrEqual(point.Y, y1))
                    {
                        return true;
                    }
                }
                else
                {
                    var b = (x1 * y3 - x3 * y1) / (x1 - x3);
                    double a;
                    if (Double.AreEqual(x1, 0))
                    {
                        a = (y3 - b) / x3;
                    }
                    else
                    {
                        a = (y1 - b) / x1;
                    }
                    var yOnSide = a * point.X + b;

                    if (Double.AreEqual(point.Y, yOnSide))
                    {
                        return true;
                    }
                }
            }

            if ((Double.LessOrEqual(x2, point.X) && Double.LessOrEqual(point.X, x3)) || (Double.LessOrEqual(x3, point.X) && Double.LessOrEqual(point.X, x2)))
            {
                if (Double.AreEqual(x2, x3))
                {
                    if ((Double.LessOrEqual(y2, point.Y) && Double.LessOrEqual(point.Y, y3)) || Double.LessOrEqual(y3, point.Y) && Double.LessOrEqual(point.Y, y2))
                    {
                        return true;
                    }
                }
                else
                {
                    var b = (x2 * y3 - x3 * y2) / (x2 - x3);
                    double a;
                    if (Double.AreEqual(x2, 0))
                    {
                        a = (y3 - b) / x3;
                    }
                    else
                    {
                        a = (y2 - b) / x2;
                    }
                    var yOnSide = a * point.X + b;

                    if (Double.AreEqual(point.Y, yOnSide))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsRectangleUnderPoint(Shape rectangle, Coord2D point)
        {
            // it has to lie on one of four sides
            // we check if it has x in bounds for left or right y, or y in bounds for top or bottom x
            // ~5% equality tolerance

            var x1 = rectangle.Points[0].X;
            var x2 = rectangle.Points[1].X;
            var y1 = rectangle.Points[0].Y;
            var y2 = rectangle.Points[1].Y;

            if ((Double.LessOrEqual(x1, point.X) && Double.LessOrEqual(point.X,x2)) || Double.LessOrEqual(x2, point.X) && Double.LessOrEqual(point.X, x1))
            {
                if (Double.AreEqual(y1, point.Y) || Double.AreEqual(y2, point.Y))
                {
                    return true;
                }
            }

            if ((Double.LessOrEqual(y1, point.Y) && Double.LessOrEqual(point.Y, y2)) || Double.LessOrEqual(y2, point.Y) && Double.LessOrEqual(point.Y, y1))
            {
                if (Double.AreEqual(x1, point.X) || Double.AreEqual(x2, point.X))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCircleUnderPoint(Shape circle, Coord2D point)
        {
            // its distance from circle center must be equal to radius
            // ~5% equality tolerance
            var circleCenter = circle.Points[0];
            var radius = Double.GetDistance(circleCenter, circle.Points[1]);
            var distanceFromCenter = Double.GetDistance(circleCenter, point);

            return Double.AreEqual(radius, distanceFromCenter);
        }
    }
}
