using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index1()
        {
            return Content("This is Second Controller - Index1");
        }

        public IActionResult Index2()
        {
            return Content("This is Second Controller - Index2");
        }

        public IActionResult Index3()
        {
            return Content("This is Second Controller - Index3");
        }
    }
}
