using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDBContext _context = new ApplicationDBContext();

        public IActionResult Index()
        {

            var products = _context.products.ToList();
            ViewData["prod"] = products;
            return View("Index");

        }


        public IActionResult Details(int id)
        {
            Product products = _context.products.FirstOrDefault(c => c.Id == id);
            ViewBag.Product = products;
            return View();
        }

    }
}
