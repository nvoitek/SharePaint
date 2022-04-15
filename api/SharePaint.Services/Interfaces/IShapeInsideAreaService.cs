using SharePaint.Models;

namespace SharePaint.Services.Interfaces
{
    public interface IShapeInsideAreaService
    {
        bool IsShapeInsideRectangle(Shape shape, Coord2D[] points);
    }
}
