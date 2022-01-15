using System.Collections.Generic;

namespace MyListLibrary
{
    interface IMyList<T> : IEnumerable<T>
    {
        void AddFirst(T value);
        void AddLast(T value);
        void AddByIndex(int index, T value);
        void AddElementsFirst(IEnumerable<T> list);
        void AddElementsLast(IEnumerable<T> list);
        void AddElementsByIndex(int index, IEnumerable<T> list);
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
        void SortDesc();
        void SortAsc();
    }
}
