using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StackOfStrings : List<string>
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        var item = this.data.Last();
        this.data.Remove(item);
        return item;
    }

    public string Peek()
    {
        var item = this.data.Last();
        return item;
    }

    public bool IsEmpty()
    {
        return this.data.Count <= 0;
    }
}