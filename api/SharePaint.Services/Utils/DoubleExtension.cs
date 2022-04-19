using System;

namespace SharePaint.Services.Utils
{
    public static class DoubleExtension
    {
        private const double TOLERANCE = 2;
        public static double Tolerance { get { return TOLERANCE; } }

        public static bool IsEqual(this double d1, double d2)
        {
            return Math.Abs(d1 - d2) <= TOLERANCE;
        }

        public static bool LessOrEqual(this double d1, double d2)
        {
            return d1 < d2 || IsEqual(d1, d2);
        }

        public static bool IsBetween(this double x, double x1, double x2)
        {
            if ((LessOrEqual(x1, x) && LessOrEqual(x, x2)) || (LessOrEqual(x2, x) && LessOrEqual(x, x1)))
            {
                return true;
            }

            return false;
        }
    }
}
