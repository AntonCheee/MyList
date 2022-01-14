using System;
using System.Collections;
using System.Collections.Generic;

namespace MyListLibrary
{
    public class MyList<T> : IMyList<T> where T : IComparable<T>
    {
        private const int DEFAULT_SIZE = 4;
        private const double INCREAMENTOR = 1.33;

        private T[] array;
        public int Count { get; set; }
        public int Capacity { get => array.Length; }

        public MyList()
        {
            this.array = new T[DEFAULT_SIZE];
        }

        public MyList(T value)
        {
            this.array = new T[DEFAULT_SIZE];
            array[0] = value;
            ++Count;
        }

        public MyList(T[] array)
        {
            this.array = array;
            Count += array.Length;
        }

        public T this[int index]
        {
            get { return array[index]; }
        }

        public void AddFirst(T value)
        {
            AddByIndex(0, value);
        }

        public void AddLast(T value)
        {
            AddByIndex(Count, value);
        }

        public void AddByIndex(int index, T value)
        {
            if (index < 0 || index > array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (IsFull())
            {
                Resize();
            }

            for (int i = Count - 1; i > index; i--)
            {
                array[i + 1] = array[i];
            }

            array[index] = value;

            ++Count;
        }

        public void AddElementsFirst(MyList<T> list)
        {
            AddElementsByIndex(0, list);
        }

        public void AddElementsLast(MyList<T> list)
        {
            AddElementsByIndex(Count, list);
        }

        public void AddElementsByIndex(int index, MyList<T> list)
        {
            if (index < 0 || index > array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (IsFull(list.Count))
            {
                Resize(list.Count);
            }

            for (int i = Count - 1; i >= index; i--)
            {
                array[i + list.Count] = array[i];
            }

            for (int i = index, j = 0; i < index + list.Count; i++, j++)
            {
                array[i] = list[j];
            }

            Count += list.Count;
        }

        public void RemoveFirstElement()
        {
            RemoveElementByIndex(0);
        }

        public void RemoveLastElement()
        {
            RemoveElementByIndex(Count - 1);
        }

        public void RemoveElementByIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < Count; i++)
            {
                array[i] = array[i + 1];
            }

            --Count;
        }

        public int RemoveElementByValue(T value)
        {
            int index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(value))
                {
                    RemoveElementByIndex(i);
                    index = i;
                }
            }

            return index;
        }

        public int RemoveAllElementsByValue(T value)
        {
            int qty = 0;

            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(value))
                {
                    RemoveElementByIndex(i);
                    ++qty;
                    --i;
                }
            }

            return qty;
        }

        public void RemoveAt(int indexFirstElement, int numberElements)
        {
            if (numberElements < 0)
            {
                throw new ArgumentException();
            }

            if (indexFirstElement < 0 || indexFirstElement >= array.Length || indexFirstElement + numberElements > array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            T[] newArr = new T[array.Length - numberElements];

            for (int i = 0; i < indexFirstElement; i++)
            {
                newArr[i] = array[i];
            }

            for (int i = indexFirstElement; i < newArr.Length; i++)
            {
                newArr[i] = array[i + numberElements];
            }
        }

        public void RemoveFirstElements(int numberElements)
        {
            if (numberElements < 0)
            {
                throw new ArgumentException();
            }

            if (numberElements > array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            T[] newArr = new T[array.Length - numberElements];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = array[i + numberElements];
            }
        }

        public void RemoveLastElements(int numberElements)
        {
            if (numberElements < 0)
            {
                throw new ArgumentException();
            }

            if (numberElements > array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            T[] newArr = new T[array.Length - numberElements];

            for (int i = 0; i < array.Length - numberElements; i++)
            {
                newArr[i] = array[i];
            }
        }

        public T GetMinElement()
        {
            return array[GetIndexMinElement()];
        }

        public T GetMaxElement()
        {
            return array[GetIndexMaxElement()];
        }

        public int GetIndexMaxElement()
        {
            int indexMaxElement = 0;

            for (int i = 1; i < Count; i++)
            {
                if (array[i].CompareTo(array[indexMaxElement]) == 1)
                {
                    indexMaxElement = i;
                }
            }

            return indexMaxElement;
        }

        public int GetIndexMinElement()
        {
            int indexMinElement = 0;

            for (int i = 1; i < Count; i++)
            {
                if (array[i].CompareTo(array[indexMinElement]) == -1)
                {
                    indexMinElement = i;
                }
            }

            return indexMinElement;
        }

        public int GetIndexFirstElementByValue(T value)
        {
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    index = i;
                }
            }

            return index;
        }

        public void EditElementByIndex(int index, T value)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            array[index] = value;
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                Swap(ref array[i], ref array[array.Length - 1 - i]);
            }
        }

        public void SortDesc()
        {
            for (int j = 1; j < Count; j++)
            {
                for (int i = j - 1; i >= 0; i--)
                {
                    if (array[j].CompareTo(array[i]) == 1)
                    {
                        Swap(ref array[j--], ref array[i]);
                    }
                }
            }
        }

        public void SortAsc()
        {
            for (int j = 1; j < Count; j++)
            {
                for (int i = j - 1; i >= 0; i--)
                {
                    if (array[j].CompareTo(array[i]) == -1)
                    {
                        Swap(ref array[j--], ref array[i]);
                    }
                }
            }
        }

        private bool IsFull(int extraLength = 0)
        {
            return Capacity <= Count + extraLength ? true : false;
        }

        private void Resize(int? extraLength = null)
        {
            T[] newArray = extraLength == null ? new T[(int)(Capacity * INCREAMENTOR)] : new T[(int)(Count + extraLength)];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        private static void Swap(ref T number1, ref T number2)
        {
            T temp = number1;
            number1 = number2;
            number2 = temp;
        }
    }
}