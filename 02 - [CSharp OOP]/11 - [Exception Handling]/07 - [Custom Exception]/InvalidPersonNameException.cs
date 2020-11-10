using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException
{
    public class InvalidPersonNameException : ApplicationException
    {
        public InvalidPersonNameException(string msg)
            : base(msg)
        {
        }
    }
}
