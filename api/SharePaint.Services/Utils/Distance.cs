using SharePaint.Models;
using System;

namespace SharePaint.Services.Utils
{
    public static class Distance
    {
        public static double DistanceTo(this Coord2D from, Coord2D to)
        {
            return Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));
        }
    }
}
