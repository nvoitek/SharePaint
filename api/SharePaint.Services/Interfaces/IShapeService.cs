using SharePaint.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePaint.Services.Interfaces
{
    public interface IShapeService
    {
        Task<List<Shape>> Get();

        Task<Shape> Get(string id);

        Task Create(Shape shape);

        Task Update(Shape shapeIn);

        Task Remove(string id);

        Task<List<Shape>> GetUnderPoint(Coord2D point);

        Task<List<Shape>> GetInsideRectangle(Coord2D[] points);
    }
}
