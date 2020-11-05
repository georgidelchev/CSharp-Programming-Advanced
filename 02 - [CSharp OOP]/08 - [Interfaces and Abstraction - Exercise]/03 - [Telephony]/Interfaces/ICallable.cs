using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models
{
    public interface ICallable
    {
        void Call(string number);
    }
}
