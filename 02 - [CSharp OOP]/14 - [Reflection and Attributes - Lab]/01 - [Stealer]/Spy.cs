using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            var classType = Type.GetType(className);

            FieldInfo[] classFields = classType
                .GetFields(BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Public);

            var classInstance = Activator.CreateInstance(classType, new object[] { });

            var sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var item in classFields
                .Where(f => fieldsNames.Contains(f.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
