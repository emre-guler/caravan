using System;
using System.Threading.Tasks;
using Caravan.Interfaces;

namespace Caravan.Service
{
    public class RecurringJobService : IRecurringJobService
    {
        private readonly IRedisService _redisService;
        public RecurringJobService(
            IRedisService redisService
        )
        {
            _redisService = redisService;
        }
        public async Task GetSuppliersAddresses()
        {
            try {

            }
            catch (Exception e) {
                
            }
        }
    }
}