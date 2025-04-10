# 🛠️ CQRS + MediatR Design Pattern with EF Core - ASP.NET Core Demo

This is a demo project that demonstrates how to implement the **CQRS (Command Query Responsibility Segregation)** design pattern using **MediatR**, **Entity Framework Core**, and **ASP.NET Core Web API**. It's structured to show best practices for clean, maintainable, and scalable backend development in .NET.

## 📌 Features

- ✅ CQRS implementation with MediatR
- ✅ Clean separation of command and query responsibilities
- ✅ CRUD operations on `Product` entity
- ✅ Pagination, sorting, and filtering support
- ✅ Entity Framework Core for data persistence
- ✅ Swagger UI for API testing and exploration

---

## 🚀 Tech Stack

- ASP.NET Core 7
- Entity Framework Core
- MediatR
- SQL Server (or compatible DB)
- Swagger (Swashbuckle)

---

## 📁 Project Structure

MediatRWithEFCoreDemo/ │ ├── Controllers/ │ └── ProductsController.cs # API Endpoints │ ├── Features/ │ └── Products/ │ ├── Commands/ # Create, Update, Delete Commands │ └── Queries/ # GetOne, GetAll Queries │ ├── Models/ │ └── Product.cs # Domain Model │ ├── Data/ │ └── AppDbContext.cs # EF Core DbContext │ └── Program.cs / appsettings.json # App setup and configuration

## 📡 API Endpoints

| Method | Route                     | Description                     |
|--------|---------------------------|---------------------------------|
| GET    | `/api/products`           | Get all products (with filters) |
| GET    | `/api/products/{id}`      | Get product by ID               |
| POST   | `/api/products`           | Create new product              |
| PUT    | `/api/products/{id}`      | Update product                  |
| DELETE | `/api/products/{id}`      | Delete product                  |

**GET /api/products** supports query parameters:

- `pageNumber` (int) — default: 1  
- `pageSize` (int) — default: 10  
- `sortBy` (string) — e.g., `name`, `price`  
- `ascending` (bool) — true/false  
- `filterName` (string)  
- `minPrice`, `maxPrice` (decimal)

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or SQL Server Express/localdb)

### Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/sandeeppaldotnet/CQRS-Mediatr-Design-Pattern-WithEFCoreDemo-Aspnetcore.git
   cd CQRS-Mediatr-Design-Pattern-WithEFCoreDemo-Aspnetcore

   Update Connection String
Modify appsettings.json to point to your SQL Server instance.

Apply Migrations & Create DB

bash
Copy
Edit
dotnet ef database update
Run the Project

bash
Copy
Edit
dotnet run
Open Swagger Visit https://localhost:{port}/swagger to test the API.

📦 Sample Payloads
Create Product (POST)
json
Copy
Edit
{
  "name": "Laptop",
  "price": 799.99,
  "description": "Powerful laptop for developers"
}
Update Product (PUT)
json
Copy
Edit
{
  "id": 1,
  "name": "Laptop Pro",
  "price": 999.99,
  "description": "Updated version with more features"
}
🤝 Contributing
Feel free to fork this repo, raise issues, and submit pull requests. Contributions are welcome!

📄 License
This project is licensed under the MIT License.

🙋‍♂️ Author
Sandeep Pal
GitHub: @sandeeppaldotnet
