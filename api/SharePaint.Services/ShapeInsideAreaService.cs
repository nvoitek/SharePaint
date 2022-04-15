using SharePaint.Models;
using SharePaint.Services.Interfaces;

namespace SharePaint.Services
{
    public class ShapeInsideAreaService : IShapeInsideAreaService
    {
        public bool IsShapeInsideRectangle(Shape shape, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private bool IsTriangleInsideRectangle(Shape triangle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private bool IsRectangleInsideRectangle(Shape rectangle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private bool IsCircleInsideRectangle(Shape circle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }
    }
}
