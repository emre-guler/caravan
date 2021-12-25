using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Caravan.Interfaces;
using Caravan.Models;

namespace Caravan.Service
{
    public class ValidationService<T> : IValidationService<T> where T : BaseModel
    {
        List<ErrorModel> modelErrors = new List<ErrorModel>();
        public List<ErrorModel> IsValid(T model)
        {
            var props = model.GetType().GetProperties();
            foreach(var prop in props)
            {
                var attributes = prop.GetCustomAttributesData();
                this.ControlAttributes(prop, attributes, prop.GetValue(model));
            }
            return modelErrors;
        }

        public void ControlAttributes(PropertyInfo prop, IList<CustomAttributeData> attributes, object propValue)
        {
            foreach (var attribute in attributes)
            {
                if(attribute.AttributeType.Name == "ErrorMessage")
                {
                    continue;
                }
                var methodInfo = this.GetType().GetMethod($"Control{attribute.AttributeType.Name}");
                var response = methodInfo.Invoke(this, new object[] { attribute, propValue});
                if(!Convert.ToBoolean(response))
                {
                    modelErrors.Add(new ErrorModel 
                    {
                        Title = attributes.FirstOrDefault(x => x.AttributeType.Name == "ErrorMessage").NamedArguments[0].ToString(), // 0. index bize Title kısmını getirir.
                        Message = attributes.FirstOrDefault(x => x.AttributeType.Name == "ErrorMessage").NamedArguments[1].ToString() // 1. index bize Message kısmını getirir.
                    });
                }
            }
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
                int minLength = int.Parse(attributeData.NamedArguments[0].TypedValue.Value.ToString());
                int maxLength = int.Parse(attributeData.NamedArguments[1].TypedValue.Value.ToString());

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
                    int minLength = int.Parse(attributeData.NamedArguments[0].TypedValue.Value.ToString());
                    if(minLength < propValue.ToString().Length)
                    {
                        return true;   
                    }
                    return false;
                }
                else 
                {
                    int maxLength = int.Parse(attributeData.NamedArguments[0].TypedValue.Value.ToString());
                    if(propValue.ToString().Length < maxLength)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public bool ControlRegexControl(CustomAttributeData attributeData, object propValue)
        {
            string regexPattern = attributeData.NamedArguments[0].TypedValue.ToString();
            Regex regex = new Regex(regexPattern);
            if(regex.Match(propValue.ToString()).Success)
            {
                return true;
            }
            return false;
        }
    }
}