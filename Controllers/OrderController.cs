using System.Linq;
using Indo_Burma.Models;
using Microsoft.AspNetCore.Mvc;

namespace Indo_Burma.Controllers
{
    public class OrderController : Controller
    {
        // GET: /<controller>/
        private IOrderRepository repo;
        private Cart cart;
        public OrderController(IOrderRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            //
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }
            if (ModelState.IsValid)
            {   // we package everything up all nice and save it to the DB
                order.Lines = cart.Items.ToArray();
                repo.SaveOrder(order);
                cart.ClearCart();

                return View("OrderConfirmation",order);
            }
            else
            {
                View(order);
            }
            return View();
        }
    }
}

