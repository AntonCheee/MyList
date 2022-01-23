using System;
using System.Collections;
using System.Collections.Generic;

namespace ListLibrary
{
    public class LinkedList<T> : IMyList<T>, IEnumerable<T> where T : IComparable<T>
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
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                GetNode(index).Value = value;
            }
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

            LinkedList<T> newList = new LinkedList<T>();

            if (!(list is LinkedList<T>))
            {
                foreach (var item in list)
                {
                    newList.AddLast(item);
                }
            }
            else
            {
                newList.root = root;
            }

            AddByIndex(index, newList.root.Value);

            Node<T> node = GetNode(index);

            newList.GetNode(newList.Count - 1).Next = GetNode(index + 1);
            node.Next = newList.root.Next;

            Count += list.Count - 1;
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

        public int IndexOf(T value)
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
            return GetMaxElementAndIndex().index;
        }

        public T GetMaxElement()
        {
            return GetMaxElementAndIndex().element;
        }

        private (T element, int index) GetMaxElementAndIndex()
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

            return (maxValue, index);

        }

        public int GetIndexMinElement()
        {
            return GetMinElementAndIndex().index;
        }

        public T GetMinElement()
        {
            return GetMinElementAndIndex().element;
        }

        private (T element, int index) GetMinElementAndIndex()
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

            return (minValue, index);
        }

        public int RemoveAllElementsByValue(T value)
        {
            Node<T> curr = root;
            Node<T> prev = null;
            int count = 0;

            for (int i = 0; i < Count; i++)
            {
                if (curr.Value.CompareTo(value) == 0)
                {
                    if (curr == root)
                    {
                        root = curr.Next;
                        curr = root;
                    }
                    else
                    {
                        prev.Next = curr.Next;
                        curr = curr.Next;
                    }

                    ++count;
                    continue;
                }

                prev = curr;
                curr = curr.Next;
            }

            Count -= count;

            return count;
        }

        public void RemoveAt(int indexFirstElement, int numberElements)
        {
            if (numberElements < 0)
            {
                throw new ArgumentException();
            }

            if (indexFirstElement < 0 || indexFirstElement + numberElements > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (indexFirstElement == 0)
            {
                RemoveFromHead(numberElements);
            }
            else
            {
                RemoveFromBody(indexFirstElement, numberElements);
            }
        }

        public void RemoveElementByIndex(int index)
        {
            RemoveAt(index, 1);
        }

        public int RemoveElementByValue(T value)
        {
            int index = IndexOf(value);
            RemoveAt(index, 1);

            return index;
        }

        public void RemoveFirstElement()
        {
            RemoveFromHead(1);
        }

        public void RemoveFirstElements(int numberElements)
        {
            RemoveFromHead(numberElements);
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
            LinkedList<T> list = new LinkedList<T>();
            Node<T> curr = root;

            while (curr.Next != null)
            {
                list.AddFirst(curr.Value);
                root = root.Next;
            }

            root = list.root;
        }

        public void Sort(bool ascending = false)
        {
            Node<T> left = GetNode(0);

            for (int i = 0; i < Count - 1; i++)
            {
                Node<T> right = GetNode(i + 1);

                for (int j = i + 1; j < Count; j++)
                {
                    if (ascending ? right.Value.CompareTo(left.Value) == -1 : right.Value.CompareTo(left.Value) == 1)
                    {
                        Swap(ref left, ref right);
                    }

                    right = right.Next;
                }

                left = left.Next;
            }
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        private Node<T> GetNode(int index)
        {
            Node<T> temp = root;

            for (int i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            return temp;
        }

        private void RemoveFromHead(int numberElements)
        {
            if (numberElements == Count)
            {
                Clear();
            }
            else
            {
                root = GetNode(numberElements);
                Count -= numberElements;
            }
        }

        private void RemoveFromBody(int indexFirstElement, int numberElements)
        {
            if (indexFirstElement + numberElements == Count)
            {
                GetNode(indexFirstElement + numberElements - 1).Next = null;
            }
            else
            {
                GetNode(indexFirstElement - 1).Next = GetNode(indexFirstElement + numberElements);
            }

            Count -= numberElements;
        }

        private void Swap(ref Node<T> element1, ref Node<T> element2)
        {
            T temp = element1.Value;
            element1.Value = element2.Value;
            element2.Value = temp;
        }

        private IEnumerator<T> GetEnumerator()
        {
            Node<T> curr = root;

            while(curr.Next != null)
            {
                yield return curr.Value;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
