using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomList : ArrayList
{
    public string RandomString()
    {
        Random rnd = new Random();

        int index = rnd.Next(0, this.Count - 1);

        return (string)this[index];
    }
}