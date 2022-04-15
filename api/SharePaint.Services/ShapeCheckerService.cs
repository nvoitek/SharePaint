using SharePaint.Models;
using SharePaint.Services.Interfaces;
using System;

namespace SharePaint.Services
{
    public class ShapeCheckerService : IShapeCheckerService
    {
        private const double TOLERANCE = 5;
        public double Tolerance { get { return TOLERANCE; } }

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

            if (AreEqual(x1, point.X) && AreEqual(y1, point.Y))
            {
                return true;
            }

            if (AreEqual(x2, point.X) && AreEqual(y2, point.Y))
            {
                return true;
            }

            if (AreEqual(x3, point.X) && AreEqual(y3, point.Y))
            {
                return true;
            }

            if ((LessOrEqual(x1, point.X) && LessOrEqual(point.X, x2)) || (LessOrEqual(x2, point.X) && LessOrEqual(point.X, x1)))
            {
                if (AreEqual(x1,x2))
                {
                    if ((LessOrEqual(y1, point.Y) && LessOrEqual(point.Y, y2)) || LessOrEqual(y2, point.Y) && LessOrEqual(point.Y, y1))
                    {
                        return true;
                    }
                }
                else
                {
                    var b = (x1 * y2 - x2 * y1) / (x1 - x2);
                    double a;
                    if (AreEqual(x1, 0))
                    {
                        a = (y2 - b) / x2;
                    }
                    else
                    {
                        a = (y1 - b) / x1;
                    }
                    var yOnSide = a * point.X + b;

                    if (AreEqual(point.Y, yOnSide))
                    {
                        return true;
                    }
                }


            }

            if ((LessOrEqual(x1, point.X) && LessOrEqual(point.X, x3)) || (LessOrEqual(x3, point.X) && LessOrEqual(point.X, x1)))
            {
                if (AreEqual(x1, x3))
                {
                    if ((LessOrEqual(y1, point.Y) && LessOrEqual(point.Y, y3)) || LessOrEqual(y3, point.Y) && LessOrEqual(point.Y, y1))
                    {
                        return true;
                    }
                }
                else
                {
                    var b = (x1 * y3 - x3 * y1) / (x1 - x3);
                    double a;
                    if (AreEqual(x1, 0))
                    {
                        a = (y3 - b) / x3;
                    }
                    else
                    {
                        a = (y1 - b) / x1;
                    }
                    var yOnSide = a * point.X + b;

                    if (AreEqual(point.Y, yOnSide))
                    {
                        return true;
                    }
                }
            }

            if ((LessOrEqual(x2, point.X) && LessOrEqual(point.X, x3)) || (LessOrEqual(x3, point.X) && LessOrEqual(point.X, x2)))
            {
                if (AreEqual(x2, x3))
                {
                    if ((LessOrEqual(y2, point.Y) && LessOrEqual(point.Y, y3)) || LessOrEqual(y3, point.Y) && LessOrEqual(point.Y, y2))
                    {
                        return true;
                    }
                }
                else
                {
                    var b = (x2 * y3 - x3 * y2) / (x2 - x3);
                    double a;
                    if (AreEqual(x2, 0))
                    {
                        a = (y3 - b) / x3;
                    }
                    else
                    {
                        a = (y2 - b) / x2;
                    }
                    var yOnSide = a * point.X + b;

                    if (AreEqual(point.Y, yOnSide))
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

            if ((LessOrEqual(x1, point.X) && LessOrEqual(point.X,x2)) || LessOrEqual(x2, point.X) && LessOrEqual(point.X, x1))
            {
                if (AreEqual(y1, point.Y) || AreEqual(y2, point.Y))
                {
                    return true;
                }
            }

            if ((LessOrEqual(y1, point.Y) && LessOrEqual(point.Y, y2)) || LessOrEqual(y2, point.Y) && LessOrEqual(point.Y, y1))
            {
                if (AreEqual(x1, point.X) || AreEqual(x2, point.X))
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
            var radius = GetDistance(circleCenter, circle.Points[1]);
            var distanceFromCenter = GetDistance(circleCenter, point);

            return AreEqual(radius, distanceFromCenter);
        }
        public bool IsShapeInsideRectangle(Shape shape, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private bool IsTriangleInsideRectangle(Shape triangle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private bool IsRectangleInsideRectangle(Shape rectangle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private bool IsCircleInsideRectangle(Shape circle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private double GetDistance(Coord2D from, Coord2D to)
        {
            return Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));
        }

        private bool AreEqual(double d1, double d2)
        {
            return Math.Abs(d1 - d2) <= TOLERANCE;
        }

        private bool LessOrEqual(double d1, double d2)
        {
            return d1 < d2 || AreEqual(d1, d2);
        }
    }
}
