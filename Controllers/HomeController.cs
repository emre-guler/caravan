using Microsoft.AspNetCore.Mvc;

namespace Caravan.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
