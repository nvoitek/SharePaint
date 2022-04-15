using Microsoft.AspNetCore.Mvc;
using SharePaint.Models;
using SharePaint.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePaint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        private readonly IShapeService _shapeService;

        public ShapesController(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shape>>> Get()
        {
            return await _shapeService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetShape")]
        public async Task<ActionResult<Shape>> Get(string id)
        {
            var shape = await _shapeService.Get(id);

            if (shape == null)
            {
                return NotFound();
            }

            return shape;
        }

        [HttpPost("underPoint", Name = "GetShapesUnderPoint")]
        public async Task<ActionResult<List<Shape>>> Get(Coord2D point)
        {
            return await _shapeService.GetUnderPoint(point);
        }

        [HttpPost]
        public async Task<ActionResult<Shape>> Create(Shape shape)
        {
            await _shapeService.Create(shape);

            return CreatedAtRoute("GetShape", new { id = shape.Id.ToString() }, shape);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Shape shapeIn)
        {
            var shape = await _shapeService.Get(id);

            if (shape == null)
            {
                return NotFound();
            }

            shapeIn.Id = id;

            await _shapeService.Update(shapeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var shape = await _shapeService.Get(id);

            if (shape == null)
            {
                return NotFound();
            }

            await _shapeService.Remove(id);

            return NoContent();
        }
    }
}
