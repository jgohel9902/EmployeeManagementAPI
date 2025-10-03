using EmployeeProductAPI.Data;
using EmployeeProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProductAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _ctx;
        public EmployeeRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Employee>> GetAllAsync() =>
            await _ctx.Employees.AsNoTracking().ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) =>
            await _ctx.Employees.FindAsync(id);

        public async Task AddAsync(Employee entity) =>
            await _ctx.Employees.AddAsync(entity);

        public void Update(Employee entity) =>
            _ctx.Employees.Update(entity);

        public void Delete(Employee entity) =>
            _ctx.Employees.Remove(entity);
    }
}