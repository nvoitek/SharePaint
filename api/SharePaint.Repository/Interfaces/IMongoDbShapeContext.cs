using MongoDB.Driver;

namespace SharePaint.Repository.Interfaces
{
    public interface IMongoDbShapeContext
    {
        IMongoCollection<Shape> GetCollection<Shape>(string name);
    }
}
