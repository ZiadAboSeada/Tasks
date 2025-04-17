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
        public IActionResult Create()
        {
            return View("Create");
        }
        public IActionResult Save(Product newproduct)
        {
            _context.products.Add(newproduct);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var product = _context.products.FirstOrDefault(p => p.Id == id);
            _context.products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult UpdateForm(int id)
        {
            var Pr = _context.products.FirstOrDefault(c => c.Id == id);
            return View("update", Pr);
        }
        public ActionResult Edit(int id, Product PrReq)
        {
            var Prdb = _context.products.FirstOrDefault(c => c.Id == id);
            Prdb.Name = PrReq.Name;
            Prdb.Description = PrReq.Description;
            Prdb.price = PrReq.price;
            Prdb.Img = PrReq.Img;
            Prdb.CategoryId = PrReq.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
