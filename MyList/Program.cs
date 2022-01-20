using System;
using ListLibrary;

namespace MyList
{
    class Program
    {
        static void Main()
        {
            LinkedList<int> myList = new();

            myList.AddElementsByIndex(0, new ArrayList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
            myList.Sort();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

            Console.WriteLine($"Capacity: {myList.Capacity}\t" + $"Count: {myList.Count}\t");
        }
    }
}
