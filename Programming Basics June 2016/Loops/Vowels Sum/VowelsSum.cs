using System;
//Vowels Sum
class VowelsSum
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        int score = 0;
        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case 'a':
                    score += 1;
                    break;
                case 'e':
                    score += 2;
                    break;
                case 'i':
                    score += 3;
                    break;
                case 'o':
                    score += 4;
                    break;
                case 'u':
                    score += 5;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine(score);
    }
}
