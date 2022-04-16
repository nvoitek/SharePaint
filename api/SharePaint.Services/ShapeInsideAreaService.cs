using SharePaint.Models;
using SharePaint.Services.Interfaces;
using SharePaint.Services.Utils;

namespace SharePaint.Services
{
    public class ShapeInsideAreaService : IShapeInsideAreaService
    {
        public bool IsShapeInsideArea(Shape shape, Coord2D point1, Coord2D point2)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Triangle:
                    return IsTriangleInsideArea(shape, point1, point2);
                case ShapeType.Rectangle:
                    return IsRectangleInsideArea(shape, point1, point2);
                case ShapeType.Circle:
                    return IsCircleInsideArea(shape, point1, point2);
                default:
                    return false;
            }
        }

        private bool IsTriangleInsideArea(Shape triangle, Coord2D point1, Coord2D point2)
        {
            throw new System.NotImplementedException();
        }

        private bool IsRectangleInsideArea(Shape rectangle, Coord2D point1, Coord2D point2)
        {
            throw new System.NotImplementedException();
        }

        private bool IsCircleInsideArea(Shape circle, Coord2D point1, Coord2D point2)
        {
            // circle's center has to be within area
            // circle's center + radius in four directions have to be within area
            // ~5% equality tolerance
            bool insideArea = true;
            var circleCenter = circle.Points[0];

            if (!circleCenter.X.BetweenPoints(point1.X, point2.X) || !circleCenter.Y.BetweenPoints(point1.Y, point2.Y))
            {
                insideArea = false;
            }

            var radius = circleCenter.DistanceTo(circle.Points[1]);
            var testedPointX = circleCenter.X + radius;
            var testedPointY = circleCenter.Y;

            if (insideArea && (!testedPointX.BetweenPoints(point1.X, point2.X) || !testedPointY.BetweenPoints(point1.Y, point2.Y)))
            {
                insideArea = false;
            }

            testedPointX = circleCenter.X;
            testedPointY = circleCenter.Y + radius;
            if (insideArea && (!testedPointX.BetweenPoints(point1.X, point2.X) || !testedPointY.BetweenPoints(point1.Y, point2.Y)))
            {
                insideArea = false;
            }

            testedPointX = circleCenter.X - radius;
            testedPointY = circleCenter.Y;
            if (insideArea && (!testedPointX.BetweenPoints(point1.X, point2.X) || !testedPointY.BetweenPoints(point1.Y, point2.Y)))
            {
                insideArea = false;
            }

            testedPointX = circleCenter.X;
            testedPointY = circleCenter.Y - radius;
            if (insideArea && (!testedPointX.BetweenPoints(point1.X, point2.X) || !testedPointY.BetweenPoints(point1.Y, point2.Y)))
            {
                insideArea = false;
            }

            return insideArea;
        }
    }
}
