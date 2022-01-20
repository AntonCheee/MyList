
namespace ListLibrary
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> next) : this(value)
        {
            Next = next;
        }

        public Node()
        {
        }
    }
}
