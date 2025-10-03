using EmployeeProductAPI.Data;
using EmployeeProductAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core InMemory
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseInMemoryDatabase("EmployeeProductDb");
});

// Repositories & UoW (Dependency Injection)
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Using Swagger in Dev and Prod 
app.UseSwagger();
app.UseSwaggerUI();

// Seed environment-specific data at startup
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
    await SeedData.InitializeAsync(ctx, env.IsDevelopment());
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
