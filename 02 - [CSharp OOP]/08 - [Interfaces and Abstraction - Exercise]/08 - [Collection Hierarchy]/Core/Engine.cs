using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        public void Proceed()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();
            List<string> elements = Reading();

            AddItem(addCollection, addRemoveCollection, myList, elements);

            var removesCount = int.Parse(Console.ReadLine());

            RemoveItem(addRemoveCollection, myList, removesCount);

            Print(addCollection, addRemoveCollection, myList);
        }

        private static List<string> Reading()
                => Console
                   .ReadLine()
                   .Split()
                   .ToList();

        private static void AddItem(AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList, List<string> elements)
        {
            foreach (var item in elements)
            {
                addCollection.Add(item);
                addRemoveCollection.Add(item);
                myList.Add(item);
            }
        }

        private static void RemoveItem(AddRemoveCollection addRemoveCollection, MyList myList, int removesCount)
        {
            for (int i = 0; i < removesCount; i++)
            {
                addRemoveCollection.Remove();
                myList.Remove();
            }
        }

        private static void Print(AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList)
        {
            Console.WriteLine(string.Join(" ", addCollection.AddOperations));
            Console.WriteLine(string.Join(" ", addRemoveCollection.AddOperations));
            Console.WriteLine(string.Join(" ", myList.AddOperations));
            Console.WriteLine(string.Join(" ", addRemoveCollection.RemoveOperations));
            Console.WriteLine(string.Join(" ", myList.RemoveOperations));
        }
    }
}
