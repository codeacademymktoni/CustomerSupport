using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerSupport.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
