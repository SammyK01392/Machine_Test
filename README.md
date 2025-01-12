# Machine_Test


 # ASP.NET MVC Product Management System
This is a simple ASP.NET MVC application demonstrating CRUD operations using the Entity Framework Code First approach. The system includes two modules: Category Management and Product Management, with server-side pagination implemented for the Product List.

Features
# Category Management:

Create, Read, Update, Delete (CRUD) operations.
Product Management:

# CRUD operations.
Each product belongs to a category.
Server-side pagination for the product list.
Product List:

Displays the following details:
ProductId
ProductName
CategoryId
CategoryName
Pagination:

Server-side implementation to fetch records as per the current page and page size.
Efficient database queries for performance optimization.
Technologies Used
Backend: ASP.NET MVC, C#
Database: SQL Server
ORM: Entity Framework (Code First approach)
Frontend: Razor Views, HTML, CSS, Bootstrap
IDE: Visual Studio 2022



## PROJECT STRUCTURE 
├── Controllers
│   ├── CategoryController.cs
│   └── ProductController.cs
├── Models
│   ├── Category.cs
│   └── Product.cs
├── Views
│   ├── Category
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Delete.cshtml
│   ├── Product
│       ├── Index.cshtml
│       ├── Create.cshtml
│       ├── Edit.cshtml
│       └── Delete.cshtml
├── App_Start
│   └── RouteConfig.cs
├── AppDbContext.cs
├── Web.config
└── README.md

