using SharePaint.Models;
using SharePaint.Repository.Interfaces;

namespace SharePaint.Repository
{
    public class ShapeRepository : BaseRepository<Shape>, IShapeRepository
    {
        public ShapeRepository(IMongoDbShapeContext context) : base(context)
        {
        }
    }
}
