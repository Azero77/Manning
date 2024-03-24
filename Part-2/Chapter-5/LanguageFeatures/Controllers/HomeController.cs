using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        /*public async  Task<IActionResult> Index()
        {
            *//*//Product?[] MyProducts = Product.GetProducts();
            //ShoppingCart shoppingCart = new() { ShoppingList = Product.GetProducts() };
            *//*Product?[] products =
            {
                new Product{Name = "Kayak" , Price = 275M },
                new Product{Name = "Lifejacket" , Price = 48.95M },
                new Product{Name = "Soccer ball" , Price = 19.50M },
                new Product{Name = "Corner flag" , Price = 34.95M }
            };*//*

            IProductSelection products = new ShoppingCart(
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
                );

            //return View(new string[] {$"Total : {products.Filter(p => (p?.Price ?? 0) > 20).GetTotal()}"});
            //return View(new string[] { $"Total : {products.Filter(p => (p?.Name[0] ?? ' ') == 's' ).GetTotal()}" });
            return View(products.Names);*//*

            string? result = (await AsyncMethods.GetPageLength()).ToString();
            return View(new string[] { result ?? "" });

        }*/

        public async Task<IActionResult> Index() 
        {
            List<string> Output = new();
            await foreach (long? item in 
                AsyncMethods.GetPageLengths(
                Output,
                "manning.com", "microsoft.com"))
            {
                Output.Add($"Page Length : {item}");
            }

            return View(Output);
        }
    }
}
