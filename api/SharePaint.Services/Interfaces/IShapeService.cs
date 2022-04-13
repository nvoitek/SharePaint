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
    }
}
