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


![Screenshot (20)](https://github.com/user-attachments/assets/26a0e9ab-7fbb-4f13-8aca-c430e277131f)






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

