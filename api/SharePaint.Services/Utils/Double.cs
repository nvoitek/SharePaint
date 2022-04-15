using SharePaint.Models;
using System;

namespace SharePaint.Services.Utils
{
    public static class Double
    {
        private const double TOLERANCE = 5;
        public static double Tolerance { get { return TOLERANCE; } }

        public static double GetDistance(Coord2D from, Coord2D to)
        {
            return Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));
        }

        public static bool AreEqual(double d1, double d2)
        {
            return Math.Abs(d1 - d2) <= TOLERANCE;
        }

        public static bool LessOrEqual(double d1, double d2)
        {
            return d1 < d2 || AreEqual(d1, d2);
        }
    }
}
