using Caravan.Models;

namespace Caravan.Interfaces
{
    public interface IValidationService<T> where T : BaseModel
    {
        bool IsValid(T model);
    }
}