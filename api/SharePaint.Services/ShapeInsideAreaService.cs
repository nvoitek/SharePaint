using SharePaint.Models;
using SharePaint.Services.Interfaces;
using SharePaint.Services.Utils;

namespace SharePaint.Services
{
    public class ShapeInsideAreaService : IShapeInsideAreaService
    {
        public bool IsShapeInsideArea(Shape shape, Area2D area)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Triangle:
                    return IsTriangleInsideArea(shape, area);
                case ShapeType.Rectangle:
                    return IsRectangleInsideArea(shape, area);
                case ShapeType.Circle:
                    return IsCircleInsideArea(shape, area);
                default:
                    return false;
            }
        }

        private bool IsTriangleInsideArea(Shape triangle, Area2D area)
        {
            // all vertices have to be within area
            // ~5% equality tolerance
            bool insideArea = true;
            var x1 = triangle.Points[0].X;
            var x2 = triangle.Points[1].X;
            var x3 = triangle.Points[2].X;
            var y1 = triangle.Points[0].Y;
            var y2 = triangle.Points[1].Y;
            var y3 = triangle.Points[2].Y;

            if (!x1.BetweenPoints(area.Point1.X, area.Point2.X) || !y1.BetweenPoints(area.Point1.Y, area.Point2.Y))
            {
                insideArea = false;
            }

            if (insideArea && (!x2.BetweenPoints(area.Point1.X, area.Point2.X) || !y2.BetweenPoints(area.Point1.Y, area.Point2.Y)))
            {
                insideArea = false;
            }

            if (insideArea && (!x3.BetweenPoints(area.Point1.X, area.Point2.X) || !y3.BetweenPoints(area.Point1.Y, area.Point2.Y)))
            {
                insideArea = false;
            }

            return insideArea;
        }

        private bool IsRectangleInsideArea(Shape rectangle, Area2D area)
        {
            // all vertices have to be within area, but because it's rectangle, we only need to check two
            // ~5% equality tolerance
            bool insideArea = true;
            var x1 = rectangle.Points[0].X;
            var y1 = rectangle.Points[0].Y;
            var x2 = rectangle.Points[1].X;
            var y2 = rectangle.Points[1].Y;

            if (!x1.BetweenPoints(area.Point1.X, area.Point2.X) || !y1.BetweenPoints(area.Point1.Y, area.Point2.Y))
            {
                insideArea = false;
            }

            if (insideArea && (!x2.BetweenPoints(area.Point1.X, area.Point2.X) || !y2.BetweenPoints(area.Point1.Y, area.Point2.Y)))
            {
                insideArea = false;
            }

            return insideArea;
        }

        private bool IsCircleInsideArea(Shape circle, Area2D area)
        {
            // circle's center has to be within area
            // circle's center + radius in four directions have to be within area
            // ~5% equality tolerance
            bool insideArea = true;
            var circleCenter = circle.Points[0];

            if (!circleCenter.X.BetweenPoints(area.Point1.X, area.Point2.X) || !circleCenter.Y.BetweenPoints(area.Point1.Y, area.Point2.Y))
            {
                insideArea = false;
            }

            var radius = circleCenter.DistanceTo(circle.Points[1]);
            var testedPointX = circleCenter.X + radius;
            var testedPointY = circleCenter.Y;

            if (insideArea && (!testedPointX.BetweenPoints(area.Point1.X, area.Point2.X) || !testedPointY.BetweenPoints(area.Point1.Y, area.Point2.Y)))
            {
                insideArea = false;
            }

            testedPointX = circleCenter.X;
            testedPointY = circleCenter.Y + radius;
            if (insideArea && (!testedPointX.BetweenPoints(area.Point1.X, area.Point2.X) || !testedPointY.BetweenPoints(area.Point1.Y, area.Point2.Y)))
            {
                insideArea = false;
            }

            testedPointX = circleCenter.X - radius;
            testedPointY = circleCenter.Y;
            if (insideArea && (!testedPointX.BetweenPoints(area.Point1.X, area.Point2.X) || !testedPointY.BetweenPoints(area.Point1.Y, area.Point2.Y)))
            {
                insideArea = false;
            }

            testedPointX = circleCenter.X;
            testedPointY = circleCenter.Y - radius;
            if (insideArea && (!testedPointX.BetweenPoints(area.Point1.X, area.Point2.X) || !testedPointY.BetweenPoints(area.Point1.Y, area.Point2.Y)))
            {
                insideArea = false;
            }

            return insideArea;
        }
    }
}
