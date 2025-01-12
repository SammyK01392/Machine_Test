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
  
        public ActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult DetailsCaterory(int id)
        {
            var categories = context.Categories.FirstOrDefault(x=>x.CategoryId== id);
            if (categories == null)
            {
                return NotFound();  
            }
            return View(categories);
        }
        public IActionResult CreateCategory()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {

                context.Categories.Add(category);
                context.SaveChanges();
               return RedirectToAction("Index");
            }

            return  View(category);

        }
        public IActionResult EditCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(x=>x.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);

        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                context.Categories.Update(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult DeleteCategory(int id)
        {
            var category=context.Categories.FirstOrDefault(x=>x.CategoryId==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost ,ActionName("DeleteCategory")]
        public IActionResult ConfirmDeleteCategory(Category category)
        {
            if (!ModelState.IsValid)
            {

                context.Categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
