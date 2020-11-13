using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            var methods = type
                .GetMethods(BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static);

            foreach (var item in methods)
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = item.GetCustomAttributes(false);

                    foreach (AuthorAttribute item1 in attributes)
                    {
                        Console.WriteLine($"{item.Name} is written by {item1.Name}");
                    }
                }
            }
        }
    }
}
