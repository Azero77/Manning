using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _repo;
        public int PageSize = 4;
        public HomeController(IStoreRepository repo) 
        {
            _repo = repo;
        }
        public ViewResult Index(string? category,int PageNumber = 1)
        {                
            return View(new ListViewProducts() 
            {
                Products = _repo.Products.Where(p => p.Category == category || category == null)
                        .Skip((PageNumber - 1) * PageSize)
                        .Take(4),
                pageModel = new PageModel {
                    TotalItems = category == null ? _repo.Products.Count()
                    : _repo.Products.Where(p => p.Category == category).Count(),
                    CurrentPage = PageNumber,
                    PageSize = PageSize,
                },
                Category = category
                
            });

            
        }
    }
}
