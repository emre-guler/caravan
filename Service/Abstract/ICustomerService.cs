using System.Collections.Generic;
using System.Threading.Tasks;
using Caravan.Models;

namespace Caravan.Interfaces
{
    public interface ICustomerService
    {
        Task<List<ErrorModel>> Register(Register registerData);
    }
}