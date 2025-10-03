using EmployeeProductAPI.Data;
using EmployeeProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _ctx;
        public ProductRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _ctx.Products.AsNoTracking().ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await _ctx.Products.FindAsync(id);

        public async Task AddAsync(Product entity) =>
            await _ctx.Products.AddAsync(entity);

        public void Update(Product entity) =>
            _ctx.Products.Update(entity);

        public void Delete(Product entity) =>
            _ctx.Products.Remove(entity);
    }
}
