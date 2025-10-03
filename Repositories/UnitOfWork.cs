using EmployeeProductAPI.Data;

namespace EmployeeProductAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;
        public IEmployeeRepository Employees { get; }
        public IProductRepository Products { get; }

        public UnitOfWork(AppDbContext ctx,
                          IEmployeeRepository employees,
                          IProductRepository products)
        {
            _ctx = ctx;
            Employees = employees;
            Products = products;
        }

        public Task<int> CompleteAsync() => _ctx.SaveChangesAsync();
    }
}

