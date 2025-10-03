using EmployeeProductAPI.Models;

namespace EmployeeProductAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddAsync(Employee entity);
        void Update(Employee entity);
        void Delete(Employee entity);
    }
}
