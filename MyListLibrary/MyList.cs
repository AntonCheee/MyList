using System;
using System.Collections;
using System.Collections.Generic;

namespace MyListLibrary
{
    public class MyList<T> : IEnumerable<T>, IMyList<T> where T : IComparable<T>
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
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[index];
            }
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
            if (index < 0 || index > Count)
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

        public void AddElementsFirst(IEnumerable<T> list)
        {
            AddElementsByIndex(0, list);
        }

        public void AddElementsLast(IEnumerable<T> list)
        {
            AddElementsByIndex(Count, list);
        }

        public void AddElementsByIndex(int index, IEnumerable<T> list)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            MyList<T> arr = (MyList<T>)list;

            if (IsFull(arr.Count))
            {
                Resize(arr.Count);
            }

            for (int i = Count - 1; i >= index; i--)
            {
                array[i + arr.Count] = array[i];
            }

            for (int i = index, j = 0; i < index + arr.Count; i++, j++)
            {
                array[i] = arr[j];
            }

            Count += arr.Count;
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
            --Count;

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
            Count -= qty;

            return qty;
        }

        public void RemoveAt(int indexFirstElement, int numberElements)
        {
            if (numberElements < 0)
            {
                throw new ArgumentException();
            }

            if (indexFirstElement < 0 || indexFirstElement + numberElements - 1 > Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = indexFirstElement + numberElements; i < Count; i++)
            {
                array[i - numberElements] = array[i];
            }

            Count -= numberElements;
        }

        public void RemoveFirstElements(int numberElements)
        {
            RemoveAt(0, numberElements);
        }

        public void RemoveLastElements(int numberElements)
        {
            RemoveAt(Count - numberElements, numberElements);
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

            for (int i = 0; i < Count; i++)
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
                Swap(ref array[i], ref array[Count - 1 - i]);
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

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}