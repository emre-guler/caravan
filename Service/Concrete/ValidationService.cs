using Caravan.Interfaces;
using Caravan.Model;

namespace Caravan.Service
{
    public class ValidationService<T> : IValidationService<T> where T : BaseModel
    {
        public bool IsValid(T model)
        {
            var props = model.GetType().GetProperties();
            foreach(var prop in props)
            {
                var propValue = prop.GetValue(model, null);
                var propAttributes = prop.GetCustomAttributesData();
                foreach (var propAttribute in propAttributes)
                {
                    var a = propAttribute;
                }
            }
            return true;
        }
    }
}