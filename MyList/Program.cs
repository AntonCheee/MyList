using System;
using ListLibrary;

namespace MyList
{
    class Program
    {
        static void Main()
        {
            LinkedList<int> myList = new();

        //    myList.AddElementsByIndex(0, new ArrayList<int>( ));

            myList.AddElementsByIndex(0, new ArrayList<int>(new int[] { 67,67,68}));

            //    myList.Sort();
            //var tt = myList.GetNode(10);


            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

            Console.WriteLine($"Capacity: {myList.Capacity}\t" + $"Count: {myList.Count}\t");
        }
    }
}
