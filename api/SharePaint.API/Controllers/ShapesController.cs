using Microsoft.AspNetCore.Mvc;
using SharePaint.Models;
using System.Collections.Generic;

namespace SharePaint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        private readonly ShapeService _shapeService;

        public ShapesController(ShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        [HttpGet]
        public ActionResult<List<Shape>> Get() =>
            _shapeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetShape")]
        public ActionResult<Shape> Get(string id)
        {
            var shape = _shapeService.Get(id);

            if (shape == null)
            {
                return NotFound();
            }

            return shape;
        }

        [HttpPost]
        public ActionResult<Shape> Create(Shape shape)
        {
            _shapeService.Create(shape);

            return CreatedAtRoute("GetShape", new { id = shape.Id.ToString() }, shape);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Shape shapeIn)
        {
            var shape = _shapeService.Get(id);

            if (shape == null)
            {
                return NotFound();
            }

            _shapeService.Update(id, shapeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var shape = _shapeService.Get(id);

            if (shape == null)
            {
                return NotFound();
            }

            _shapeService.Remove(id);

            return NoContent();
        }
    }
}
