using Problem9_CollectionHierarchy.Interfaces;
using Problem9_CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace Problem9_CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            var input = Console.ReadLine();
            var addTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in addTokens)
            {
                addCollection.Add(str);
                addRemoveCollection.Add(str);
                myList.Add(str);
            }

            Console.WriteLine(addCollection.ToString());
            Console.WriteLine(addRemoveCollection.ToString());
            Console.WriteLine(myList.ToString());

            int n = int.Parse(Console.ReadLine());

            var resultsARC = new List<string>();
            var resultsML = new List<string>();

            for (int i = 0; i < n; i++)
            {
                resultsARC.Add(addRemoveCollection.Remove());
                resultsML.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", resultsARC));
            Console.WriteLine(string.Join(" ", resultsML));
        }
    }
}