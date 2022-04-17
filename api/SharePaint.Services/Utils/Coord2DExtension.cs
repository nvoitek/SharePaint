using SharePaint.Models;
using System;

namespace SharePaint.Services.Utils
{
    public static class Coord2DExtension
    {
        public static bool IsOnLine(this Coord2D point, Coord2D p1, Coord2D p2)
        {
            // Check if point falls between two points on the X axis (necessary to be on the line segment)
            if (point.X.BetweenPoints(p1.X, p2.X))
            {
                // Check if those points are equal, in this case line is vertical and we need to check if point falls between two points on the Y axis
                if (p1.X.IsEqual(p2.X))
                {
                    if (point.Y.BetweenPoints(p1.Y, p2.Y))
                    {
                        return true;
                    }
                }
                // If not we have to calculate a and b parameters of line function y = ax + b
                // We have two points so we have two equations with two unknowns
                else
                {
                    var b = (p1.X * p2.Y - p2.X * p1.Y) / (p1.X - p2.X);
                    double a;

                    // We have to check which point to use to obtain a, we can't use point with x = 0
                    if (p1.X.IsEqual(0))
                    {
                        a = (p2.Y - b) / p2.X;
                    }
                    else
                    {
                        a = (p1.Y - b) / p1.X;
                    }

                    // We have to check what would be the value of y if x was on the line and compare that to the real y
                    var yOnLine = a * point.X + b;
                    if (point.Y.IsEqual(yOnLine))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static double DistanceTo(this Coord2D from, Coord2D to)
        {
            return Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));
        }
    }
}
