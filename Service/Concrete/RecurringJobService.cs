using System;
using System.Threading.Tasks;
using Caravan.Interfaces;

namespace Caravan.Service
{
    public class RecurringJobService : IRecurringJobService
    {
        private readonly IRedisService _redisService;
        private readonly ICustomerService _customerService;
        public RecurringJobService(
            IRedisService redisService,
            ICustomerService customerService
        )
        {
            _redisService = redisService;
            _customerService = customerService;
        }
        public async Task GetSuppliersAddresses()
        {   
            await _redisService.Add($"logs-info-{DateTime.UtcNow}-GetSuppliersAddresses", $"-GetSuppliersAddresses started.");
            try {
                var userData = await _customerService.GetAllCustomers();
                foreach (var user in userData)
                {
                    await _redisService.Add($"logs-info-{DateTime.UtcNow}-GetSuppliersAddressesForUser", $"-GetSuppliersAddresses started for. UserId: {user.Id}");
                    
                }

            }
            catch (Exception e) {
                await _redisService.Add($"logs-fail-{DateTime.UtcNow}-GetSuppliersAddresses", $"GetSuppliersAddresses failed. {e.ToString()}");
            }
        }
    }
}