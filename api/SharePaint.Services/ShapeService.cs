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
        private readonly IShapeUnderPointService _shapeUnderPointService;
        private readonly IShapeInsideAreaService _shapeInsideAreaService;

        public ShapeService(IShapeRepository shapeRepository, IShapeUnderPointService shapeUnderPointService, IShapeInsideAreaService shapeInsideAreaService)
        {
            _shapeRepository = shapeRepository;
            _shapeUnderPointService = shapeUnderPointService;
            _shapeInsideAreaService = shapeInsideAreaService;
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
                var isShapeUnderPoint = await Task.Run(() => _shapeUnderPointService.IsShapeUnderPoint(shape, point));

                if (isShapeUnderPoint)
                {
                    shapes.Add(shape);
                }
            }

            return shapes;
        }

        public async Task<List<Shape>> GetInsideArea(Coord2D point1, Coord2D point2)
        {
            var allShapes = await _shapeRepository.Get();

            var shapes = new List<Shape>();

            foreach (var shape in allShapes)
            {
                var isShapeUnderPoint = await Task.Run(() =>_shapeInsideAreaService.IsShapeInsideArea(shape, point1, point2));

                if (isShapeUnderPoint)
                {
                    shapes.Add(shape);
                }
            }

            return shapes;
        }
    }
}
