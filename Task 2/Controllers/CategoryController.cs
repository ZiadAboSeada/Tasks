using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDBContext _context = new ApplicationDBContext();

        public IActionResult Index()
        {

            var categories = _context.categories.ToList();
            ViewData["cat"] = categories;
            return View("Index");

        }


        public IActionResult Details(int id)
        {
            var categories = _context.categories.FirstOrDefault(c => c.Id == id);
            ViewBag.Category = categories;
            return View();
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        public IActionResult save(Category newcat) {
            _context.categories.Add(newcat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult delete(int id)
        { var cat = _context.categories.FirstOrDefault(cat => cat.Id == id);
            _context.categories.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateForm(int id) {
            var categ = _context.categories.FirstOrDefault(c => c.Id == id);
            return View("update", categ);
                }
        public ActionResult Edit(int id, Category catReq) 
            { 
            var categdb = _context.categories.FirstOrDefault(c=>c.Id == id); 
            categdb.Name= catReq.Name;
            categdb.Description= catReq.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
    }
}