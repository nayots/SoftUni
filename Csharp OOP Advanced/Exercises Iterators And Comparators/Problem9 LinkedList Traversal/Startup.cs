using Problem9_LinkedList_Traversal.Models.Generics;
using System;

namespace Problem9_LinkedList_Traversal
{
    class Startup
    {
        private static void Main(string[] args)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Add":
                        linkedList.Add(int.Parse(tokens[1]));
                        break;

                    case "Remove":
                        int number = int.Parse(tokens[1]);
                        int removeIndex = linkedList.FirstIndexOf(number);
                        if (removeIndex > -1)
                        {
                            linkedList.Remove(linkedList.FirstIndexOf(number));
                        }
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}