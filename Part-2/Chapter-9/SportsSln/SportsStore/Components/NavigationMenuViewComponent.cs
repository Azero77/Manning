using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository Repo;
        public NavigationMenuViewComponent(IStoreRepository repository) 
        {
            Repo = repository;
        }
        public IViewComponentResult Invoke() 
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(Repo.Products.Select(p=>p.Category).Distinct().OrderBy(p=>p));
        }
    }
}
