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
        private ICustomerService _customerService;
        public CustomerController(
            IValidationService<Register> registerValidationService,
            ICustomerService customerService
        )
        {
            _registerValidationService = registerValidationService;
            _customerService = customerService;
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
            var registerErrors = await _customerService.Register(register);
            if(modelErrors.Count == 0)
            {
                return RedirectToAction("Login");
            }
            string errJson = JsonConvert.SerializeObject(modelErrors);
            return RedirectToAction("Register", new { error = "registererror", errorDetail = errJson });
        }
    }
}
