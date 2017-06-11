using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10_UnicodeCharacters
{
    class UnicodeCharacters
    {
        private static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();

            foreach (char chara in chars)
            {
                Console.Write("\\u{0:x4}", Convert.ToUInt16(chara));
            }
        }
    }
}