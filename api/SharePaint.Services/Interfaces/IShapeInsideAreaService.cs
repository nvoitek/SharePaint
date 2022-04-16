using SharePaint.Models;

namespace SharePaint.Services.Interfaces
{
    public interface IShapeInsideAreaService
    {
        bool IsShapeInsideArea(Shape shape, Area2D area);
    }
}
