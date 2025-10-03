# Employee & Product Management API

An **ASP.NET Core 8.0 Web API** for managing Employees and Products.  
The project demonstrates clean architecture using **Entity Framework Core (InMemory)**, the **Repository Pattern**, and the **Unit of Work Pattern**.  
It also includes **environment-specific seed data** (different for Development and Production) and provides **RESTful CRUD endpoints** for integration with web or mobile front ends.

---

## 🚀 Features

- **Employees & Products CRUD**
  - `GET /api/employees` – List all employees  
  - `GET /api/employees/{id}` – Get an employee by ID  
  - `POST /api/employees` – Add a new employee  
  - `PUT /api/employees/{id}` – Update an employee  
  - `DELETE /api/employees/{id}` – Remove an employee  
  - (Similar endpoints for `/api/products`)
- **Repository Pattern** – Clean data access layer.
- **Unit of Work Pattern** – Single transaction to save changes across repositories.
- **Dependency Injection** – Repositories and UoW registered in the DI container.
- **Environment-Specific Seed Data** – Loads different Employees and Products in Development vs Production.
- **Swagger/OpenAPI** – Built-in API documentation & testing UI.

---

## 🏗️ Project Structure

EmployeeProductAPI/
├─ Controllers/
│ ├─ EmployeesController.cs
│ └─ ProductsController.cs
├─ Data/
│ ├─ AppDbContext.cs
│ └─ SeedData.cs
├─ Models/
│ ├─ Employee.cs
│ └─ Product.cs
├─ Repositories/
│ ├─ IEmployeeRepository.cs
│ ├─ EmployeeRepository.cs
│ ├─ IProductRepository.cs
│ ├─ ProductRepository.cs
│ ├─ IUnitOfWork.cs
│ └─ UnitOfWork.cs
├─ Program.cs
└─ README.md

## ⚙️ Technologies Used

- [.NET 8](https://dotnet.microsoft.com/)  
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core)  
- [Entity Framework Core (InMemory)](https://learn.microsoft.com/ef/core/)  
- [Swagger / OpenAPI](https://swagger.io/tools/open-source/open-source-integrations/)

---

## 🛠️ Getting Started

### Prerequisites
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or .NET 8 SDK
- .NET CLI (`dotnet --version` should be 8.x)

### Run the application

**Visual Studio:**  
Open the `.sln` file → Set **EmployeeProductAPI** as the startup project → Press **F5**.

**.NET CLI:**  
```bash
dotnet run
```

🧪 Testing the API

Open Swagger UI at https://localhost:xxxx/swagger to try endpoints.
You can also use Postman for testing if preferred.
