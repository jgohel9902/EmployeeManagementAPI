using EmployeeProductAPI.Models;
using EmployeeProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public EmployeesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET /api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var list = await _uow.Employees.GetAllAsync();
            return Ok(list);
        }

        // GET /api/employees/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var item = await _uow.Employees.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST /api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> Create([FromBody] Employee employee)
        {
            await _uow.Employees.AddAsync(employee);
            await _uow.CompleteAsync();

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        // PUT /api/employees/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee updated)
        {
            var existing = await _uow.Employees.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Name = updated.Name;
            existing.Department = updated.Department;

            _uow.Employees.Update(existing);
            await _uow.CompleteAsync();
            return NoContent();
        }

        // DELETE /api/employees/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _uow.Employees.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _uow.Employees.Delete(existing);
            await _uow.CompleteAsync();
            return NoContent();
        }
    }
}
