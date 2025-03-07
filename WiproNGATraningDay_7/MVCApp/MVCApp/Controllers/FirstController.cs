using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index1()
        {
            ViewData["Message"] = "Welcome to ASP.NET Core MVC!";
            return View();

        }

        public IActionResult Index2()
        {
            ViewBag.Message = "Hello from ViewBag!";
            return View();
        }

        public IActionResult Index3()
        {
            return Content("This is First Controller - Index3");
        }
    }
}
