using System;
using System.Threading.Tasks;
using Caravan.Interfaces;
using Caravan.Model;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Controllers
{
    public class CustomerController : Controller
    {
        private IValidationService<Register> _registerValidationService;
        
        public CustomerController(IValidationService<Register> registerValidationService)
        {
            _registerValidationService = registerValidationService;
        }
        
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

        [HttpPost("/customer/register")]
        public async Task<IActionResult> Register(Register register)
        {
            if(_registerValidationService.IsValid(register))
            {
                return RedirectToAction("Home");
            }
            return RedirectToAction("Login", new { error = "validationerror" });
        }
    }
}
