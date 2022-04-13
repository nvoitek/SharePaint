using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SharePaint.Models
{
    public class Shape
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public ShapeType ShapeType { get; set; }

        public List<Coord2D> Points { get; set; }

        public string Author { get; set; }
    }
}
