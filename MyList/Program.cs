using System;
using System.Collections.Generic;
using MyListLibrary;

namespace MyList
{
    class Program
    {
        static void Main()
        {
            //MyList<int> myList = new MyList<int>();
            //myList.AddByIndex(0, 1);
            //myList.AddByIndex(1, 2);
            //myList.AddByIndex(2, 3);
            //myList.AddByIndex(3, 44);
            //myList.AddByIndex(4, 5);
            //myList.AddByIndex(5, 33);
            //myList.AddByIndex(6, 7);
            //myList.AddByIndex(7, 8);
            //myList.AddByIndex(8, 9);
            //myList.AddByIndex(9, 17);
            //myList.AddByIndex(10, 11);
            //myList.AddByIndex(11, 12);
            //myList.AddByIndex(12, 122);

            MyList<int> myList = new MyList<int>(new int[6] { 1, 2, 3, 4, 5, 6 });

            Console.WriteLine($"Capacity: {myList.Capacity}\t" + $"Count: {myList.Count}\t");

            //  myList.AddElementsFirst(new MyList<int>(new int[]{45,46, 47,48}));

            //List<int> r = new List<int>();
            //r.Add(4);
            //r.Add(7);
            //r.Add(48);
            //r.Add(49);

            //r.Remove(7);

            //myList.SortDesc();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

            Console.WriteLine($"Capacity: {myList.Capacity}\t" + $"Count: {myList.Count}\t");
        }
    }
}
