using System;
using System.Collections.Generic;

namespace MyListLibrary
{
    public interface IMyList<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Count { get; }
        T this[int index] { get; set; }
        void AddFirst(T value);
        void AddLast(T value);
        void AddByIndex(int index, T value);
        void AddElementsFirst(IMyList<T> list);
        void AddElementsLast(IMyList<T> list);
        void AddElementsByIndex(int index, IMyList<T> arr);
        void RemoveFirstElement();
        void RemoveLastElement();
        void RemoveElementByIndex(int index);
        int RemoveElementByValue(T value);
        int RemoveAllElementsByValue(T value);
        void RemoveAt(int indexFirstElement, int numberElements);
        void RemoveFirstElements(int numberElements);
        void RemoveLastElements(int numberElements);
        T GetMinElement();
        T GetMaxElement();
        int GetIndexMaxElement();
        int GetIndexMinElement();
        int GetIndexFirstElementByValue(T value);
        void EditElementByIndex(int index, T value);
        void Reverse();
        void Sort(bool ascending);
    }
}
