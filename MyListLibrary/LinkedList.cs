using System;
using System.Collections;
using System.Collections.Generic;

namespace ListLibrary
{
    public class LinkedList<T> : IMyList<T> where T : IComparable<T>
    {
        public int Count { get; set; }
        public int Capacity { get => Count; }
        private Node<T> root;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return GetNode(index).Value;
            }
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }

                GetNode(index).Value = value;
            }
        }

        private Node<T> GetNode(int index)
        {
            Node<T> temp = root;
            for (int i = 0; i < index; i++)
            {
                if (temp.Next == null)
                {
                    throw new IndexOutOfRangeException();
                }

                temp = temp.Next;
            }

            return temp;
        }

        public void AddByIndex(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> newNode = new(value);

            if (index != Count)
            {
                newNode.Next = GetNode(index);
            }

            if (index != 0)
            {
                GetNode(index - 1).Next = newNode;
            }
            else
            {
                root = newNode;
            }

            ++Count;
        }

        public void AddElementsByIndex(int index, IMyList<T> list)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            LinkedList<T> newList;

            if (!(list is LinkedList<T>))
            {
                newList = ToLinkedList(list);
            }
            else
            {
                newList = (LinkedList<T>)list;
            }

            if (root == null)
            {
                root = newList.root;
            }

            Node<T> curr = GetNode(index);

            if (index != 0)
            {
                GetNode(index - 1).Next = newList.GetNode(0);
            }

            if (index != Count)
            {
                newList.GetNode(newList.Count - 1).Next = curr;
            }

            Count += list.Count;
        }

        public void AddElementsFirst(IMyList<T> list)
        {
            AddElementsByIndex(0, list);
        }

        public void AddElementsLast(IMyList<T> list)
        {
            AddElementsByIndex(Count, list);
        }

        public void AddFirst(T value)
        {
            AddByIndex(0, value);
        }

        public void AddLast(T value)
        {
            AddByIndex(Count, value);
        }

        public int GetIndexFirstElementByValue(T value)
        {
            Node<T> current = root;
            int index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(value))
                {
                    index = i;
                }

                current = current.Next;
            }

            return index;
        }

        public int GetIndexMaxElement()
        {
            Node<T> current = root;
            int index = 0;
            T maxValue = current.Value;

            for (int i = 0; i < Count - 1; i++)
            {
                if (maxValue.CompareTo(current.Next.Value) == -1)
                {
                    maxValue = current.Next.Value;
                    index = i + 1;
                }

                current = current.Next;
            }

            return index;
        }

        public int GetIndexMinElement()
        {
            Node<T> current = root;
            int index = 0;
            T minValue = current.Value;

            for (int i = 0; i < Count - 1; i++)
            {
                if (minValue.CompareTo(current.Next.Value) == 1)
                {
                    minValue = current.Next.Value;
                    index = i + 1;
                }

                current = current.Next;
            }

            return index;
        }

        public T GetMaxElement()
        {
            Node<T> current = root;
            T maxValue = current.Value;

            for (int i = 0; i < Count - 1; i++)
            {
                if (maxValue.CompareTo(current.Next.Value) == -1)
                {
                    maxValue = current.Next.Value;
                }

                current = current.Next;
            }

            return maxValue;
        }

        public T GetMinElement()
        {
            Node<T> current = root;
            T minValue = current.Value;

            for (int i = 0; i < Count - 1; i++)
            {
                if (minValue.CompareTo(current.Next.Value) == 1)
                {
                    minValue = current.Next.Value;
                }

                current = current.Next;
            }

            return minValue;
        }

        public int RemoveAllElementsByValue(T value)
        {
            Node<T> curr = root;
            Node<T> prev = null;
            int count = 0;

            for (int i = 0; i < Count; i++)
            {
                if (curr.Value.CompareTo(value) == 1)
                {
                    if (i == 0)
                    {
                        root = curr.Next;
                    }
                    else if (i == Count - 1)
                    {
                        curr.Next = null;
                    }
                    else
                    {
                        prev.Next = curr.Next;
                    }

                    prev = curr;
                    curr = curr.Next;
                    ++count;
                    --Count;
                }
            }

            return count;
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

            if (indexFirstElement == 0)
            {
                if (indexFirstElement + numberElements == Count)
                {
                    Clear();
                }
                else
                {
                    root = GetNode(indexFirstElement + numberElements);
                }
            }
            else
            {
                if (indexFirstElement + numberElements == Count)
                {
                    GetNode(indexFirstElement + numberElements - 1).Next = null;
                }
                else
                {
                    GetNode(indexFirstElement - 1).Next = GetNode(indexFirstElement + numberElements);
                }
            }
        }

        public void RemoveElementByIndex(int index)
        {
            RemoveAt(index, 1);
        }

        public int RemoveElementByValue(T value)
        {
            int index = GetIndexFirstElementByValue(value);
            RemoveAt(index, 1);

            return index;
        }

        public void RemoveFirstElement()
        {
            RemoveAt(0, 1);
        }

        public void RemoveFirstElements(int numberElements)
        {
            RemoveAt(0, numberElements);
        }

        public void RemoveLastElement()
        {
            RemoveAt(Count - 1, 1);
        }

        public void RemoveLastElements(int numberElements)
        {
            RemoveAt(Count - 1, numberElements);
        }

        public void Reverse()
        {
            Node<T> prev = null;
            Node<T> curr = root;
            Node<T> currNext = null;

            for (int i = 0; i < Count; i++)
            {
                if (i != Count - 1)
                {
                    currNext = curr.Next;
                }

                if (i == 0)
                {
                    curr.Next = null;
                }
                else
                {
                    curr.Next = prev;
                }

                if (i != Count - 1)
                {
                    prev = curr;
                    curr = currNext;
                }
                else
                {
                    root = curr;
                }
            }
        }

        public void Sort(bool ascending = false)
        {
            IMyList<T> newList = new ArrayList<T>();
            Node<T> temp = root;

            for (int i = 0; i < Count; i++)
            {
                newList.AddByIndex(i, temp.Value);
                temp = temp.Next;
            }

            for (int j = 1; j < newList.Count; j++)
            {
                for (int i = j - 1; i >= 0; i--)
                {
                    if (ascending ? newList[j].CompareTo(newList[i]) == -1 : newList[j].CompareTo(newList[i]) == 1)
                    {
                        //TODO
                        //ListLibrary.ArrayList<T>.Swap(ref newList[j--], ref newList[i]);
                    }
                }
            }
        }

        public void Clear()
        {
            root = null;
        }

        private static LinkedList<T> ToLinkedList(IMyList<T> arr)
        {
            LinkedList<T> linkedList = new LinkedList<T>();

            for (int i = 0; i < arr.Count; i++)
            {
                linkedList.AddLast(arr[i]);
            }

            return linkedList;
        }
    }
}
