using System;
//Stop
class Stop
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int lines = 2 * n - 1;
        for (int i = 0; i < 2 * n + 2; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', n + 1), new string('_', (2 * n) + 1));
            }
            else if (i <= n)
            {
                Console.WriteLine("{0}//{1}\\\\{0}", new string('.', n + 1 - i), new string('_', lines));
                lines += 2;
            }
            else if (i == n + 1)
            {
                Console.WriteLine("//{0}STOP!{0}\\\\", new string('_', (lines - 5) / 2));
            }
            else if (i == n + 2)
            {
                Console.WriteLine("\\\\{0}//", new string('_', lines));
                lines -= 2;
            }
            else
            {
                Console.WriteLine("{0}\\\\{1}//{0}", new string ('.',i - (n + 2)), new string('_', lines));
                lines -= 2;
            }
        }
    }
}
