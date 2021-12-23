using System;
using System.Threading.Tasks;
using Caravan.Interfaces;
using Caravan.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var modelErrors = _registerValidationService.IsValid(register);
            if(modelErrors.Count > 0)
            {
                string errorsJson = JsonConvert.SerializeObject(modelErrors);
                return RedirectToAction("Register", new { error = "validationerror", errorDetail = errorsJson });
            }
            
            return RedirectToAction("Home");

        }
    }
}
