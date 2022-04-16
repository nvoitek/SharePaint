using SharePaint.Models;

namespace SharePaint.Services.Interfaces
{
    public interface IShapeInsideAreaService
    {
        bool IsShapeInsideArea(Shape shape, Coord2D point1, Coord2D point2);
    }
}
