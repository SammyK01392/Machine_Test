using Machine_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Machine_Test.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext context;

        public ProductController(ProductDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var totalCount = await context.Products.CountAsync();

            
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

         
            if (pageNumber > totalPages) pageNumber = totalPages;

     
            var products = await context.Products
                .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.CategoryId,
                    p.Category.CategoryName
                })
                .ToListAsync();

            
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.TotalPages = totalPages;

            return View(products);
        }


        public IActionResult Details(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if(product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList( context.Categories.ToList(), "CategoryId", "CategoryName");
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "CategoryId", "CategoryName");
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName");

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                context.Products.Attach(product);
                context.Entry(product).State = EntityState.Modified;

                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

          
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName");

            return View(product);
        }

        private bool ProductExists(int id)
        {
            return context.Products.Any(e => e.ProductId == id);
        }




        public async Task<IActionResult> Delete(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
