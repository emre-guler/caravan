using System.Threading.Tasks;
using Caravan.Interfaces;
using Caravan.Models;

namespace Caravan.Service
{
    public class CustomerService : ICustomerService
    {
        public CustomerService()
        {
            
        }

        public async Task<bool> Register(Register registerData)
        {
            throw new System.NotImplementedException();
        }
    }
}