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

        // Index with Pagination
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var totalCount = await context.Products.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (pageNumber > totalPages && totalPages > 0) pageNumber = totalPages;

            var products = await context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.TotalPages = totalPages;

            return View(products);
        }

        // Details
        public async Task<IActionResult> Details(int id)
        {
            var product = await context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "CategoryId", "CategoryName");
            return View(product);
        }

        // Create (GET)
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "CategoryId", "CategoryName");
            return View();
        }

        // Create (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (context.Products.Any(p => p.ProductName == product.ProductName))
            {
                ModelState.AddModelError("ProductName", "A product with this name already exists.");
            }

            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "CategoryId", "CategoryName");
            return View(product);
        }

        // Edit (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "CategoryId", "CategoryName");
            return View(product);
        }

        // Edit (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (context.Products.Any(p => p.ProductName == product.ProductName && p.ProductId != product.ProductId))
            {
                ModelState.AddModelError("ProductName", "A product with this name already exists.");
            }

            if (ModelState.IsValid)
            {
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(await context.Categories.ToListAsync(), "CategoryId", "CategoryName");
            return View(product);
        }

        // Delete
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

        // Check if a product exists
        private bool ProductExists(int id)
        {
            return context.Products.Any(e => e.ProductId == id);
        }
    }
}
