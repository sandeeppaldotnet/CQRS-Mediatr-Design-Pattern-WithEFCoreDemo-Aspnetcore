🛠️ CQRS + MediatR Design Pattern with EF Core - ASP.NET Core Demo
This is a demo project showcasing the CQRS (Command Query Responsibility Segregation) design pattern implemented using MediatR, Entity Framework Core, and ASP.NET Core Web API. The project demonstrates how to cleanly separate command and query responsibilities, improve scalability, and maintain clean architecture in your .NET applications.

📂 Project Structure
bash
Copy
Edit
MediatRWithEFCoreDemo/
│
├── Controllers/
│   └── ProductsController.cs       # API endpoints for product management
│
├── Features/
│   └── Products/
│       ├── Commands/
│       │   ├── CreateProductCommand.cs
│       │   ├── UpdateProductCommand.cs
│       │   └── DeleteProductCommand.cs
│       └── Queries/
│           ├── GetProductByIdQuery.cs
│           └── GetAllProductsQuery.cs
│
├── Models/
│   └── Product.cs                  # Entity model
│
├── Data/
│   └── AppDbContext.cs            # EF Core DB Context
│
└── Program.cs / Startup.cs        # Application setup
🚀 Features
Implements CQRS with MediatR

Uses EF Core for data persistence

RESTful CRUD API for Product entity

Supports pagination, sorting, and filtering

Clean separation of concerns

Scalable architecture for enterprise apps

🔧 Technologies Used
ASP.NET Core Web API

Entity Framework Core

MediatR

SQL Server (or any EF Core supported database)

Swagger (for API documentation)

🧪 API Endpoints
Verb	Endpoint	Description
GET	/api/products	Get paginated list of products
GET	/api/products/{id}	Get product by ID
POST	/api/products	Create a new product
PUT	/api/products/{id}	Update an existing product
DELETE	/api/products/{id}	Delete a product
Query Parameters for GET /api/products:

pageNumber (int)

pageSize (int)

sortBy (string) – e.g., name, price

ascending (bool)

filterName (string)

minPrice / maxPrice (decimal)

⚙️ Getting Started
Prerequisites
.NET 7 SDK or later

SQL Server (local or remote)

Setup Instructions
Clone the Repository

bash
Copy
Edit
git clone https://github.com/sandeeppaldotnet/CQRS-Mediatr-Design-Pattern-WithEFCoreDemo-Aspnetcore.git
cd CQRS-Mediatr-Design-Pattern-WithEFCoreDemo-Aspnetcore
Update the DB Connection String
In appsettings.json, set your connection string under DefaultConnection.

Apply Migrations

bash
Copy
Edit
dotnet ef database update
Run the Application

bash
Copy
Edit
dotnet run
Explore Swagger UI Navigate to https://localhost:{port}/swagger in your browser.

🧱 Example Payloads
Create Product (POST):

json
Copy
Edit
{
  "name": "Sample Product",
  "price": 99.99,
  "description": "A sample product for demo purposes"
}
Update Product (PUT):

json
Copy
Edit
{
  "id": 1,
  "name": "Updated Product",
  "price": 149.99,
  "description": "Updated description"
}
🙌 Contributions
Contributions, issues, and feature requests are welcome! Feel free to fork and submit PRs.
