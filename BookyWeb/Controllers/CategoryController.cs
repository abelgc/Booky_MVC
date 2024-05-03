using Microsoft.AspNetCore.Mvc;

namespace BookyWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
