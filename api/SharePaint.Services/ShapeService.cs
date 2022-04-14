using SharePaint.Models;
using SharePaint.Repository.Interfaces;
using SharePaint.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePaint.Services
{
    public class ShapeService : IShapeService
    {
        private readonly IShapeRepository _shapeRepository;
        private readonly IShapeCheckerService _shapeChecker;

        public ShapeService(IShapeRepository shapeRepository, IShapeCheckerService shapeChecker)
        {
            _shapeRepository = shapeRepository;
            _shapeChecker = shapeChecker;
        }

        public async Task<List<Shape>> Get()
        {
            return await _shapeRepository.Get();
        }

        public async Task<Shape> Get(string id)
        {
            return await _shapeRepository.Get(id);
        }

        public async Task Create(Shape shape)
        {
            await _shapeRepository.Create(shape);
        }

        public async Task Update(Shape shapeIn)
        {
            await _shapeRepository.Update(shapeIn);
        }

        public async Task Remove(string id)
        {
            await _shapeRepository.Delete(id);
        }

        public async Task<List<Shape>> GetUnderPoint(Coord2D point)
        {
            var allShapes = await _shapeRepository.Get();

            var shapes = new List<Shape>();

            foreach (var shape in allShapes)
            {
                var isShapeUnderPoint = await _shapeChecker.IsShapeUnderPoint(shape, point);

                if (isShapeUnderPoint)
                {
                    shapes.Add(shape);
                }
            }

            return shapes;
        }

        public async Task<List<Shape>> GetInsideRectangle(Coord2D[] points)
        {
            var allShapes = await _shapeRepository.Get();

            var shapes = new List<Shape>();

            foreach (var shape in allShapes)
            {
                var isShapeUnderPoint = await _shapeChecker.IsShapeInsideRectangle(shape, points);

                if (isShapeUnderPoint)
                {
                    shapes.Add(shape);
                }
            }

            return shapes;
        }
    }
}
