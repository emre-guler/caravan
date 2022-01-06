using Caravan.Entities;
using Caravan.Interfaces;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Caravan.Service
{
    public class CurrentCustomerService : ICurrentCustomerService
    {
        private ICustomerService _customerService;
        public CurrentCustomerService(
            ICustomerService customerService
        )
        {
            _customerService = customerService;
        }
        public async Task<Customer> GetCurrentCustomer(IIdentity identity)
        {
            return await _customerService.GetCustomerById(
                JsonConvert.DeserializeObject<Customer>(identity.Name).Id
            );
        }
    }
}