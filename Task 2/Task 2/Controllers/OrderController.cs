using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_2.Models;
using Task_2.ViewModel;
using static NuGet.Packaging.PackagingConstants;

namespace Task_2.Controllers
{
    public class OrderController : Controller
    {
        ApplicationDBContext _context = new ApplicationDBContext();
        public IActionResult Index()
        {
            var order = _context.orders.Include(e => e.Customer).ToList();
            List<OrderwithCustomer> OrderVM = new List<OrderwithCustomer>();

            foreach (var item in order)
            {
                OrderVM.Add(new OrderwithCustomer
                {
                    OrderId = item.Id,
                    CustomerName = item.Customer.Name,
                    CustomerPhone = item.Customer.Phone,
                    CustomerEmail = item.Customer.Email
                });
            }
            return View(OrderVM);

        }
        public IActionResult Details(int id)
        {
            var order2 = _context.orders
                        .Include(o => o.orderItems)
                        .ThenInclude(oi => oi.product)
                        .FirstOrDefault(o => o.Id == id);

            OrderWithItemsProducts OrdersVM = new OrderWithItemsProducts();
            OrdersVM.OrderId = order2.Id;
            OrdersVM.OrderCustomerId = order2.CustomerId;
            OrdersVM.OrderDate = order2.OrderDat;
            OrdersVM.OrderTotalAmount = order2.TotalAmount;
            OrdersVM.ItemId =  order2.orderItems.First().Id;
            OrdersVM.ItemQuantity = order2.orderItems.First().Quantity;
            OrdersVM.ItemPrice = order2.orderItems.First().price;
            OrdersVM.ProductId = order2.orderItems.First().product.Id;
            OrdersVM.ProductName = order2.orderItems.First().product.Name;
            OrdersVM.ProductDescription = order2.orderItems.First().product.Description;
            OrdersVM.ProductCategoryId = order2.orderItems.First().product.CategoryId;
            OrdersVM.ProductPrice = order2.orderItems.First().product.price;
          
          
            return View(OrdersVM);
        }


    }
}
