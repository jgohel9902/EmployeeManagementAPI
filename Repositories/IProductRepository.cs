using EmployeeProductAPI.Models;

namespace EmployeeProductAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
