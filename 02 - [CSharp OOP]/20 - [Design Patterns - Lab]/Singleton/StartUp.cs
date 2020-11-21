using System;
using Singleton.Models;

namespace Singleton
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db1 = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;
            var db4 = SingletonDataContainer.Instance;
        }
    }
}
