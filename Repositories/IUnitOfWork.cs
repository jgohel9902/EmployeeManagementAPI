namespace EmployeeProductAPI.Repositories
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IProductRepository Products { get; }
        Task<int> CompleteAsync();  
    }
}
