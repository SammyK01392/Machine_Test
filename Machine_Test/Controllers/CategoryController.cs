using Machine_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Machine_Test.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductDbContext context;

        public CategoryController(ProductDbContext context)
        {
            this.context = context;
        }

        // Index Action with Pagination
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var totalCategories = context.Categories.Count();
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCategories / (double)pageSize);

            return View(categories);
        }

        // View Details
        public IActionResult DetailsCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Create Category (GET)
        public IActionResult CreateCategory()
        {
            return View();
        }

        // Create Category (POST)
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (context.Categories.Any(c => c.Name == category.Name))
            {
                ModelState.AddModelError("Name", "Category with this name already exists.");
                return View(category);
            }

            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // Edit Category (GET)
        public IActionResult EditCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Edit Category (POST)
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (context.Categories.Any(c => c.Name == category.Name && c.CategoryId != category.CategoryId))
            {
                ModelState.AddModelError("Name", "Category with this name already exists.");
                return View(category);
            }

            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // Delete Category (GET)
        public IActionResult DeleteCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Delete Category (POST)
        [HttpPost, ActionName("DeleteCategory")]
        public IActionResult ConfirmDeleteCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
