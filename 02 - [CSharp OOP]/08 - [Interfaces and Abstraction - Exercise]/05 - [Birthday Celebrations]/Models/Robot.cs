using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : Citizen, ICheckable
    {
        public Robot(string name, string id)
            : base(name, id)
        {
        }
    }
}
