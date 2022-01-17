﻿using System;
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

            myList.AddElementsByIndex(3, new MyList<int>(new int[] { 32, 34, 35 }));

          //  myList.Sort(false);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

            Console.WriteLine($"Capacity: {myList.Capacity}\t" + $"Count: {myList.Count}\t");
        }
    }
}
