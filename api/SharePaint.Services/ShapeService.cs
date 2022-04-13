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

        public ShapeService(IShapeRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
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
    }
}
