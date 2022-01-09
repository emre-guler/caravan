using System.Threading.Tasks;
using Caravan.Interfaces;
using Caravan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Caravan.Controllers
{
    public class TrendyolController : Controller
    {
        private ICustomerService _customerService;
        private ICurrentCustomerService _currentCustomerService;
        public TrendyolController(
            ICustomerService customerService,
            ICurrentCustomerService currentCustomerService
        )
        {
            _customerService = customerService;
            _currentCustomerService = currentCustomerService;
        }

        [HttpGet("/trendyol/")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/trendyol/apidata")]
        [Authorize]
        public async Task<IActionResult> ApiData()
        {
            var currentUser = await _currentCustomerService.GetCurrentCustomer(User.Identity);
            var apiData = await _customerService.GetApiData(currentUser);
            return View(apiData);
        }

        [HttpPost("/trendyol/apidata")]
        [Authorize]
        public async Task<IActionResult> ApiData(ApiData apidata)
        {
            var currentUser = await _currentCustomerService.GetCurrentCustomer(User.Identity);
            var modelErrors = await _customerService.SetApiData(apidata, currentUser);
            if(modelErrors.Count == 0)
            {
                return RedirectToAction("ApiData");
            }
            string errJson = JsonConvert.SerializeObject(modelErrors);
            return RedirectToAction("SetApiData", new { error = "error", errorDetail = errJson });
        }  
    }
}