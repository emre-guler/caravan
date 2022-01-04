using System.Threading.Tasks;
using Caravan.Models;

namespace Caravan.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> Register(Register registerData);
    }
}