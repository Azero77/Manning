using Microsoft.AspNetCore.Mvc;
using PartInvite.Models;

namespace PartInvite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RsvpForm(GuestResponse response) 
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(response);
                return View("Answer", response);
            }
            return View();
        }

        public IActionResult Coming()
        {
            return View(Repository.GetResponses.Where(a => a.WillAttend == true));
        }
    }
}