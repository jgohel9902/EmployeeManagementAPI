using EmployeeProductAPI.Models;
using EmployeeProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ProductsController(IUnitOfWork uow) => _uow = uow;

        // GET /api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var list = await _uow.Products.GetAllAsync();
            return Ok(list);
        }

        // GET /api/products/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var item = await _uow.Products.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST /api/products
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            await _uow.Products.AddAsync(product);
            await _uow.CompleteAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT /api/products/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product updated)
        {
            var existing = await _uow.Products.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Name = updated.Name;
            existing.Price = updated.Price;

            _uow.Products.Update(existing);
            await _uow.CompleteAsync();
            return NoContent();
        }

        // DELETE /api/products/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _uow.Products.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _uow.Products.Delete(existing);
            await _uow.CompleteAsync();
            return NoContent();
        }
    }
}
