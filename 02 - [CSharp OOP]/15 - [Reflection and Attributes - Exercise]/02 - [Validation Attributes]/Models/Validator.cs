using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();

            PropertyInfo[] propertyInfos = objType.GetProperties();

            foreach (var item in propertyInfos)
            {
                List<MyValidationAttribute> myAttribures = item
                    .GetCustomAttributes<MyValidationAttribute>()
                    .ToList();

                var propValue = item.GetValue(obj);

                foreach (var item1 in myAttribures)
                {
                    var isValid = item1.IsValid(propValue);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
