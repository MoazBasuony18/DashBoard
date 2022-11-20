using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
