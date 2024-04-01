using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository OrderRepository;
        private Cart Cart;
        public OrderController(IOrderRepository orderRepository , Cart cartService) 
        {
            OrderRepository = orderRepository;
            Cart = cartService;
        }
        public IActionResult Checkout() 
        {
            return View(new Order());
        }


        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (Cart.CartLines.Count() <= 0) 
            {
                ModelState.AddModelError("","Cart Is Empty");
            }

            if (ModelState.IsValid)
            {
                order.cartLines = Cart.CartLines.ToList();
                OrderRepository.SaveOrder(order);
                Cart.Clear();
                return RedirectToPage("/Completed", new { OrderId = order.OrderID });
            }
            else return View();
        }
    }
}
