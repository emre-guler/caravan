using System.Collections.Generic;
using Caravan.Models;

namespace Caravan.Interfaces
{
    public interface IValidationService<T> where T : BaseModel
    {
        List<ErrorModel> IsValid(T model);
    }
}