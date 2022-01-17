using NUnit.Framework;
using MyListLibrary;
using System;

namespace UnitTests
{
    public class MyListTests
    {
        [SetUp]
        public static void SetUp()
        {
        }

        static object[] GetMinElementSource = new[]
         {
            new object[] { new MyList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 1000 } ), -9 },
            new object[] { new MyList<int>(new int[] { 10, 5, 9, 73, 16, 100, 10, 7 }), 5 },
            new object[] { new MyList<int>(new int[] { 10, 5, 9, 73, 0, 19, 1, 10 }), 0 },
        };

        [TestCaseSource(nameof(GetMinElementSource))]
        public static void GetMinElement_WhenArrayNotEmpty_ShouldGetMinElement(MyList<int> array, int expectedResult)
        {
            int actualResult = array.GetMinElement();

            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] GetMaxElementSource = new[]
        {
            new object[] { new MyList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 100 }), 100 },
            new object[] { new MyList<int>(new int[] { 101, 5, 9, 73, 16, 100, 10, 1 }), 101 },
            new object[] { new MyList<int>(new int[] { -5, -9, -73, 0, -19, -1, -10 }), 0 },
        };

        [TestCaseSource(nameof(GetMaxElementSource))]
        public static void GetMaxElement_WhenArrayNotEmpty_ShouldGetMinElement(MyList<int> array, int expectedResult)
        {
            int actualResult = array.GetMaxElement();

            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] GetIndexMinElementSource = new[]
        {
            new object[] { new MyList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 1000 }), 0 },
            new object[] { new MyList<int>(new int[] { 10, 5, 9, 73, 16, 100, 10, 1 }), 7 },
            new object[] { new MyList<int>(new int[] { 10, 5, 9, 73, 0, 19, 1, 10 }), 4 },
        };

        [TestCaseSource(nameof(GetIndexMinElementSource))]
        public static void GetIndexMinElement_WhenArrayNotEmpty_ShouldGetMinElement(MyList<int> array, int expectedResult)
        {
            int actualResult = array.GetIndexMinElement();

            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] GetIndexMaxElementSource = new[]
        {
            new object[] { new MyList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 100 }), 7 },
            new object[] { new MyList<int>(new int[] { 101, 5, 9, 73, 16, 100, 10, 1 }), 0 },
            new object[] { new MyList<int>(new int[] { -5, -9, -73, 0, -19, -1, -10 }), 3 },
        };

        [TestCaseSource(nameof(GetIndexMaxElementSource))]
        public static void GetIndexMaxElement_WhenArrayNotEmpty_ShouldGetMinElement(MyList<int> array, int expectedResult)
        {
            int actualResult = array.GetIndexMaxElement();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}