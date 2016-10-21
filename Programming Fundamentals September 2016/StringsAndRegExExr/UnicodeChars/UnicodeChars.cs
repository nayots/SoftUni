using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//03. Unicode Characters
namespace UnicodeChars
{
    class UnicodeChars
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();

            foreach (char chara in chars)
            {
                Console.Write("\\u{0:x4}",Convert.ToUInt16(chara));
            }
        }
    }
}
