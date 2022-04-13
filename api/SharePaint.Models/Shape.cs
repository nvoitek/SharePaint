using System.Collections.Generic;

namespace SharePaint.Models
{
    public class Shape : Entity
    {
        public ShapeType ShapeType { get; set; }

        public List<Coord2D> Points { get; set; }

        public string Author { get; set; }
    }
}
