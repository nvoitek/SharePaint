using SharePaint.Models;

namespace SharePaint.Services.Interfaces
{
    public interface IShapeUnderPointService
    {
        bool IsShapeUnderPoint(Shape shape, Coord2D point);
    }
}
