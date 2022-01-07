using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Caravan.Interfaces;
using Caravan.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Caravan.Controllers
{
    public class CustomerController : Controller
    {
        private IValidationService<Register> _registerValidationService;
        private IValidationService<Login> _loginValidationService;
        private ICustomerService _customerService;
        public CustomerController(
            IValidationService<Register> registerValidationService,
            IValidationService<Login> loginValidationService,
            ICustomerService customerService
        )
        {
            _registerValidationService = registerValidationService;
            _loginValidationService = loginValidationService;
            _customerService = customerService;
        }
        
        [HttpGet("/customer/login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("/customer/register")]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("/customer/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
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
            if(registerErrors.Count == 0)
            {
                return RedirectToAction("Login");
            }
            string errJson = JsonConvert.SerializeObject(registerErrors);
            return RedirectToAction("Register", new { error = "registererror", errorDetail = errJson });
        }

        [HttpPost("/customer/login")]
        public async Task<IActionResult> Login(Login login)
        {
            var modelErrors = _loginValidationService.IsValid(login);
            if(modelErrors.Count > 0)
            {
                string errorsJson = JsonConvert.SerializeObject(modelErrors);
                return RedirectToAction("Login", new { error = "validationerror", errorDetail = errorsJson });
            }
            var loginErrors = await _customerService.Login(login);
            if(loginErrors.Count == 0)
            {
                var userData = await _customerService.GetCustomerByMailAddress(login.MailAddress);
                string userDataJson = JsonConvert.SerializeObject(userData);
                var userIdentity = new ClaimsIdentity(
                    new List<Claim> {
                        new Claim(ClaimTypes.Name, userDataJson)
                    },
                    "Login"
                );
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Trendyol");
            }
            string errJson = JsonConvert.SerializeObject(loginErrors);
            return RedirectToAction("Login", new { error = "invalidcredentials", errorDetail = errJson });
        }      
    }
}
