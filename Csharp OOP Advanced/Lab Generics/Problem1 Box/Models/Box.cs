using System.Collections.Generic;

public class Box<T>
{
    private Stack<T> data;

    public int Count { get { return this.data.Count; } }

    public Box()
    {
        this.data = new Stack<T>();
    }

    public void Add(T element)
    {
        this.data.Push(element);
    }

    public T Remove()
    {
        return this.data.Pop();
    }
}