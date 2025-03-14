using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDBContext _context= new ApplicationDBContext();
        
        public IActionResult Index()
        {

          var categories = _context.categories.ToList();
            ViewData["cat"] = categories;
            return View("Index");

        }

        
        public IActionResult Details(int id)
        {
            var categories = _context.categories.FirstOrDefault(c=>c.Id ==id);
            ViewBag.Category = categories;
            return View();
        }

    }
}