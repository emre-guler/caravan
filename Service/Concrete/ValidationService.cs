using Caravan.Interfaces;
using Caravan.Model;

namespace Caravan.Service
{
    public class ValidationService<T> : IValidationService<T> where T : BaseModel
    {
        public bool IsValid(T model)
        {
            return true;
        }
    }
}