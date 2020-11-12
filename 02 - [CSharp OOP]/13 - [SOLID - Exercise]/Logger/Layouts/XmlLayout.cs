using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        private const string DEFAULT_TEMPLATE =
@"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";

        public string Template => DEFAULT_TEMPLATE;
    }
}
