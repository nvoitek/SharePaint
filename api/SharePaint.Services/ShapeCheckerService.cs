using SharePaint.Models;
using SharePaint.Services.Interfaces;
using System.Threading.Tasks;

namespace SharePaint.Services
{
    public class ShapeCheckerService : IShapeCheckerService
    {
        public async Task<bool> IsShapeUnderPoint(Shape shape, Coord2D point)
        {
            throw new System.NotImplementedException();
        }

        private async Task<bool> IsTriangleUnderPoint(Shape triangle, Coord2D point)
        {
            // three line function y = ax + b
            // we check if point is on the line
            // then check if point on line is in bounds
            // ~5% equality tolerance
            throw new System.NotImplementedException();
        }

        private async Task<bool> IsRectangleUnderPoint(Shape rectangle, Coord2D point)
        {
            // it has to lie on one of four sides
            // we check if it has x in bounds for left or right y, or y in bounds for top or bottom x
            // ~5% equality tolerance
            throw new System.NotImplementedException();
        }

        private async Task<bool> IsCircleUnderPoint(Shape circle, Coord2D point)
        {
            // its distance from circle center must be equal to radius
            // ~5% equality tolerance
            throw new System.NotImplementedException();
        }
        public async Task<bool> IsShapeInsideRectangle(Shape shape, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private async Task<bool> IsTriangleInsideRectangle(Shape triangle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private async Task<bool> IsRectangleInsideRectangle(Shape rectangle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }

        private async Task<bool> IsCircleInsideRectangle(Shape circle, Coord2D[] points)
        {
            throw new System.NotImplementedException();
        }
    }
}
