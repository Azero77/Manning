using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers 
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string Result = DateTime.Now.Hour < 12 ? "Good Morning" : "Good Evening";
            return View("MyView" , Result);
        }
    }
}