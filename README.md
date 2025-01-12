# Machine_Test



### Features
 ## Category Management:
Create, Read, Update, Delete (CRUD) operations.


##  Product Management:
CRUD operations.
Each product belongs to a category.
Server-side pagination for the product list.


 ## Product List:
Displays the following details:
ProductId
ProductName
CategoryId
CategoryName

## Pagination:
Server-side implementation to fetch records as per the current page and page size.
Efficient database queries for performance optimization.

 ###   PROJECT STRUCTURE 

 
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

