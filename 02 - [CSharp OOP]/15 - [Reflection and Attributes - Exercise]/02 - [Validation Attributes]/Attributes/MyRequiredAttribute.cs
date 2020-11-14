using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            var result = false;

            if (obj != null)
            {
                result = true;
            }

            return result;
        }
    }
}
