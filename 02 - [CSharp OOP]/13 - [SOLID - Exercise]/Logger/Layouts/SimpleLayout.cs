using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        private const string DEFAULT_TEMPLATE = "{0} - {1} - {2}";

        public string Template => DEFAULT_TEMPLATE;
    }
}
