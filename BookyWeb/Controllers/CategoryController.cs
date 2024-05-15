using BookyWeb.Data;
using BookyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var categoryList = _dbContext.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult CreateCategory(Category newCategory)
        {
            if(newCategory == null)
            {
                ModelState.TryAddModelError("name", "Category cannot be null");
            }

            if (newCategory!.Name == newCategory.DisplayOrder.ToString())
            {
                ModelState.TryAddModelError("name", "Category Name cannot be a number");
            }

            if (ModelState.IsValid) // according to the tags of Model Class
            {
                _dbContext.Categories.Add(newCategory);//we ask to add a new row in table
                _dbContext.SaveChanges(); //Commit changes
                return RedirectToAction("Index");
            } 
            
            return View();
           
        }
    }
}
