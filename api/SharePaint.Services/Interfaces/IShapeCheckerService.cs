using SharePaint.Models;

namespace SharePaint.Services.Interfaces
{
    public interface IShapeCheckerService
    {
        bool IsShapeUnderPoint(Shape shape, Coord2D point);
        bool IsShapeInsideRectangle(Shape shape, Coord2D[] points);
    }
}
