using MongoDB.Driver;
using SharePaint.Models;
using System.Collections.Generic;
using System.Linq;

namespace SharePaint.API
{
    public class ShapeService
    {
        private readonly IMongoCollection<Shape> _shapes;

        public ShapeService(IConnectionSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shapes = database.GetCollection<Shape>(settings.CollectionName);
        }

        public List<Shape> Get() =>
            _shapes.Find(shape => true).ToList();

        public Shape Get(string id) =>
            _shapes.Find(shape => shape.Id == id).FirstOrDefault();

        public Shape Create(Shape shape)
        {
            _shapes.InsertOne(shape);
            return shape;
        }

        public void Update(string id, Shape shapeIn) =>
            _shapes.ReplaceOne(shape => shape.Id == id, shapeIn);

        public void Remove(Shape shapeIn) =>
            _shapes.DeleteOne(shape => shape.Id == shapeIn.Id);

        public void Remove(string id) =>
            _shapes.DeleteOne(shape => shape.Id == id);
    }
}
