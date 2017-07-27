namespace Problem9_LinkedList_Traversal.Models.Generics
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            this.Value = value;
        }

        public LinkedListNode<T> Next { get; set; }
        public T Value { get; private set; }
    }
}