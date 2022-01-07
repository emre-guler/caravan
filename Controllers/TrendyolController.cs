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
        public TrendyolController(
            ICustomerService customerService
        )
        {
            _customerService = customerService;
        }

        [HttpGet("/trendyol/")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost("/trendyol/setApiData")]
        [Authorize]
        public async Task<IActionResult> SetApiData(ApiData apidata)
        {
            var modelErrors = await _customerService.SetApiData(apidata);
            if(modelErrors.Count == 0)
            {
                return RedirectToAction("SetApiData");
            }
            string errJson = JsonConvert.SerializeObject(modelErrors);
            return RedirectToAction("SetApiData", new { error = "error", errorDetail = errJson });
        }  
    }
}