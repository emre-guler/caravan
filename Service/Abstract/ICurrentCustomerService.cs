using Caravan.Entities;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Caravan.Interfaces
{
    public interface ICurrentCustomerService
    {
        Task<Customer> GetCurrentCustomer(IIdentity identity);
    }
}