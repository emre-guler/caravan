using Microsoft.AspNetCore.Mvc;

namespace Caravan.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet("/customer/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("/customer/register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
