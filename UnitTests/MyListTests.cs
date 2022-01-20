using NUnit.Framework;
using ListLibrary;
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
            new object[] { new ArrayList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 1000 } ), -9 },
            new object[] { new ArrayList<int>(new int[] { 10, 5, 9, 73, 16, 100, 10, 7 }), 5 },
            new object[] { new ArrayList<int>(new int[] { 10, 5, 9, 73, 0, 19, 1, 10 }), 0 },
        };

        [TestCaseSource(nameof(GetMinElementSource))]
        public static void GetMinElement_WhenArrayNotEmpty_ShouldGetMinElement(ArrayList<int> array, int expectedResult)
        {
            int actualResult = array.GetMinElement();

            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] GetMaxElementSource = new[]
        {
            new object[] { new ArrayList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 100 }), 100 },
            new object[] { new ArrayList<int>(new int[] { 101, 5, 9, 73, 16, 100, 10, 1 }), 101 },
            new object[] { new ArrayList<int>(new int[] { -5, -9, -73, 0, -19, -1, -10 }), 0 },
        };

        [TestCaseSource(nameof(GetMaxElementSource))]
        public static void GetMaxElement_WhenArrayNotEmpty_ShouldGetMinElement(ArrayList<int> array, int expectedResult)
        {
            int actualResult = array.GetMaxElement();

            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] GetIndexMinElementSource = new[]
        {
            new object[] { new ArrayList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 1000 }), 0 },
            new object[] { new ArrayList<int>(new int[] { 10, 5, 9, 73, 16, 100, 10, 1 }), 7 },
            new object[] { new ArrayList<int>(new int[] { 10, 5, 9, 73, 0, 19, 1, 10 }), 4 },
        };

        [TestCaseSource(nameof(GetIndexMinElementSource))]
        public static void GetIndexMinElement_WhenArrayNotEmpty_ShouldGetMinElement(ArrayList<int> array, int expectedResult)
        {
            int actualResult = array.GetIndexMinElement();

            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] GetIndexMaxElementSource = new[]
        {
            new object[] { new ArrayList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 100 }), 7 },
            new object[] { new ArrayList<int>(new int[] { 101, 5, 9, 73, 16, 100, 10, 1 }), 0 },
            new object[] { new ArrayList<int>(new int[] { -5, -9, -73, 0, -19, -1, -10 }), 3 },
        };

        [TestCaseSource(nameof(GetIndexMaxElementSource))]
        public static void GetIndexMaxElement_WhenArrayNotEmpty_ShouldGetMinElement(ArrayList<int> array, int expectedResult)
        {
            int actualResult = array.GetIndexMaxElement();

            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] ReverseSource = new[]
       {
            new object[] {  new ArrayList<int>(new int[] { -9, 5, -4, 73, 19, 0, -1, 100 }), new ArrayList<int>(new int[] { 100, -1, 0, 19, 73, -4, 5, -9 }) },
            new object[] {  new ArrayList<int>(new int[] { 101, 5, 9, 73, 16, 100, 10, -178 }), new ArrayList<int>(new int[] { -178, 10, 100, 16, 73, 9, 5, 101 }) },
            new object[] {  new ArrayList<int>(new int[]{ -5, -9, -73, 0, -19, -1, -10, 3, -7 }), new ArrayList<int>(new int[] { -7, 3, -10, -1, -19, 0, -73, -9, -5 })}
        };

        [TestCaseSource(nameof(ReverseSource))]
        public static void Reverse_WhenArrayNotEmpty_ShouldFindMinElement(IMyList<int> array, IMyList<int> expectedResult)
        {
            array.Reverse();

            Assert.AreEqual(expectedResult, array);
        }
    }
}