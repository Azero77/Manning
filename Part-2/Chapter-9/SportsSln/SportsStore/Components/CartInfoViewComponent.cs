using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class CartInfoViewComponent : ViewComponent
    {
        public Cart Cart;
        public CartInfoViewComponent(Cart cartService) 
        {
            Cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(Cart);
        }
    }
}
