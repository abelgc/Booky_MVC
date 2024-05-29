using BookyWeb.Data;
using BookyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //Get
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category newCategory)
        {
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

        [HttpGet]
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = await _dbContext.Categories.FirstOrDefaultAsync(u=>u.Id == id.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
       
        [HttpPost]
        public IActionResult EditCategory(Category newCategory)
        {
            if (newCategory!.Name == newCategory.DisplayOrder.ToString())
            {
                ModelState.TryAddModelError("name", "Category Name cannot be a number");
            }

            if (ModelState.IsValid) // according to the tags of Model Class
            {
                _dbContext.Categories.Update(newCategory);//we ask to add a new row in table
                _dbContext.SaveChanges(); //Commit changes
                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = await _dbContext.Categories.FirstOrDefaultAsync(u => u.Id == id.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryPost(int? id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(u => u.Id == id!.Value);

            if (category == null)
            {
                return NotFound(); 
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges(); //Commit changes
            return RedirectToAction("Index");
           
        }
    }
}
