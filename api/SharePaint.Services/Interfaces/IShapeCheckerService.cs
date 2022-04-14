using SharePaint.Models;
using System.Threading.Tasks;

namespace SharePaint.Services.Interfaces
{
    public interface IShapeCheckerService
    {
        Task<bool> IsShapeUnderPoint(Shape shape, Coord2D point);
        Task<bool> IsShapeInsideRectangle(Shape shape, Coord2D[] points);
    }
}
