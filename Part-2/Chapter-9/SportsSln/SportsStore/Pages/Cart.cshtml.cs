using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Models;
using SportsStore.Infrastructure;

namespace SportsStore.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository Repository;
        public CartModel(IStoreRepository repository , Cart cartService) 
        {
            Repository = repository;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string? UrlPath { get; set; } = string.Empty;
        public void OnGet(string urlPath)
        {
            UrlPath = urlPath ?? "/";
        }


        public IActionResult OnPostAdd(int ProductID , string urlPath) 
        {
            //getting the product
            var p = Repository.Products.Where(p => p.ProductID == ProductID).FirstOrDefault();
            
            if (p is not null) 
            {
                //add to the cart
                /*Cart cart_temp = HttpContext.Session.GetJson<Cart>("cart") ?? new();
                cart_temp.AddItem(p);
                HttpContext.Session.SetJson("cart", cart_temp);*/
                Cart.AddItem(p, 1);
            }

            return RedirectToPage(new { urlPath = urlPath});
        }

        public IActionResult OnPostRemove(int ProductID , string urlPath) 
        {
            Cart.RemoveItem(ProductID);
            return RedirectToPage(new { urlPath = urlPath});
        }
    }
}
