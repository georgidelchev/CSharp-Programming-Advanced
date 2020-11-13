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

        public string AnalyzeAcessModifiers(string className)
        {
            var classType = Type.GetType(className);

            FieldInfo[] classFields = classType
                .GetFields(BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public);

            MethodInfo[] publicMethodInfos = classType
                .GetMethods(BindingFlags.Instance |
                BindingFlags.Public);

            MethodInfo[] privateMethodInfos = classType
                .GetMethods(BindingFlags.Instance |
                BindingFlags.NonPublic);

            var sb = new StringBuilder();

            foreach (var item in classFields)
            {
                sb.AppendLine($"{item.Name} must be private");
            }

            foreach (var item in privateMethodInfos
                .Where(x => x.Name.Contains("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }

            foreach (var item in publicMethodInfos
                .Where(x => x.Name.Contains("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var classType = Type.GetType(className);

            MethodInfo[] privateMethodInfos = classType
               .GetMethods(BindingFlags.Instance |
               BindingFlags.NonPublic);

            var sb = new StringBuilder();
            
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            
            foreach (var item in privateMethodInfos)
            {
                sb.AppendLine($"{item.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
