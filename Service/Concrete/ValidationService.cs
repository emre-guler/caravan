using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                var a = prop.GetCustomAttributesData();
                if(!this.ControlAttributes(a, prop.GetValue(model)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ControlAttributes(IList<CustomAttributeData> attributes, object propValue)
        {
            foreach (var attribute in attributes)
            {
                var methodInfo = this.GetType().GetMethod($"Control{attribute.AttributeType.Name}");
                var response = methodInfo.Invoke(this, new object[] { attribute, propValue});
            }
            return true;
        }

        public bool ControlRequiredArea(CustomAttributeData attributeData, object propValue)
        {
            if(!String.IsNullOrEmpty(propValue.ToString()))
            {
                return true;
            }
            return false;
        }
        
        public bool ControlCharacterLimit(CustomAttributeData attributeData, object propValue)
        {
            if(attributeData.NamedArguments.Count() == 2)
            {
                int minLength = int.Parse(attributeData.NamedArguments[0].TypedValue.ToString());
                int maxLength = int.Parse(attributeData.NamedArguments[1].TypedValue.ToString());

                if(minLength < (propValue.ToString().Length) && (propValue.ToString().Length) < maxLength)
                {
                    return true;
                }
                return false;
            }
            else if(attributeData.NamedArguments.Count() == 1)
            {
                if(attributeData.NamedArguments[0].MemberName == "Min")
                {
                    int minLength = int.Parse(attributeData.NamedArguments[0].TypedValue.ToString());
                    if(minLength < propValue.ToString().Length)
                    {
                        return true;   
                    }
                    return false;
                }
                else 
                {
                    int maxLength = int.Parse(attributeData.NamedArguments[0].TypedValue.ToString());
                    if(propValue.ToString().Length < maxLength)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}