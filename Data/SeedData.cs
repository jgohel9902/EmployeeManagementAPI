using EmployeeProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProductAPI.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(AppDbContext ctx, bool isDevelopment)
        {
            await ctx.Database.EnsureCreatedAsync();

            if (!await ctx.Employees.AnyAsync() && !await ctx.Products.AnyAsync())
            {
                if (isDevelopment)
                {
                    ctx.Employees.AddRange(
                        new Employee { Id = 1, Name = "Dev Alice", Department = "DevOps" },
                        new Employee { Id = 2, Name = "Dev Bob", Department = "QA" }
                    );
                    ctx.Products.AddRange(
                        new Product { Id = 1, Name = "Dev Product A", Price = 9.99m },
                        new Product { Id = 2, Name = "Dev Product B", Price = 19.99m }
                    );
                }
                else
                {
                    ctx.Employees.AddRange(
                        new Employee { Id = 1, Name = "Production Alice", Department = "Sales" },
                        new Employee { Id = 2, Name = "Production Bob", Department = "Support" }
                    );
                    ctx.Products.AddRange(
                        new Product { Id = 1, Name = "Laptop", Price = 1299.00m },
                        new Product { Id = 2, Name = "Monitor", Price = 249.00m }
                    );
                }

                await ctx.SaveChangesAsync();
            }
        }
    }
}
