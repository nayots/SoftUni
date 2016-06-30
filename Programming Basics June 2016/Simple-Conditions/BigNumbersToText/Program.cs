using System;
//I used a code i wrote for some other homework. So this code is not very good or clean. Keep that in mind while reading it.
class Program
{
    static void Main(string[] args)
    {
            int userNumber = int.Parse(Console.ReadLine());
            int a;
            int b;
            int c;
            int d;
            bool specialCase = false;
            string words = "";
            if (userNumber >= 0 && userNumber <= 100)//Can work until 999 normaly.
            {
                a = userNumber / 100;
                b = (userNumber / 10) % 10;
                c = userNumber % 10;
                d = userNumber % 100;
                if (userNumber == 0)
                {
                    Console.WriteLine("Zero");
                    return;
                }
                if (d >= 11 && d < 20)
                {
                    specialCase = true;
                }

                if (a != 0)
                {
                    switch (a)
                    {
                        case 1:
                            words += "One Hundred ";
                            break;
                        case 2:
                            words += "Two Hundred ";
                            break;
                        case 3:
                            words += "Three Hundred ";
                            break;
                        case 4:
                            words += "Four Hundred ";
                            break;
                        case 5:
                            words += "Five Hundred ";
                            break;
                        case 6:
                            words += "Six Hundred ";
                            break;
                        case 7:
                            words += "Seven Hundred ";
                            break;
                        case 8:
                            words += "Eight Hundred ";
                            break;
                        case 9:
                            words += "Nine Hundred ";
                            break;
                    }
                }
                if (a != 0 && d != 0)
                {
                    words += "And ";
                }
                if (b != 0 && specialCase == false)
                {
                    switch (b)
                    {
                        case 1:
                            words += "Ten ";
                            break;
                        case 2:
                            words += "Twenty ";
                            break;
                        case 3:
                            words += "Thirty ";
                            break;
                        case 4:
                            words += "Fourty ";
                            break;
                        case 5:
                            words += "Fifty ";
                            break;
                        case 6:
                            words += "Sixty ";
                            break;
                        case 7:
                            words += "Seventy ";
                            break;
                        case 8:
                            words += "Eighty ";
                            break;
                        case 9:
                            words += "Ninety ";
                            break;
                    }
                }
                if (c != 0 && specialCase == false)
                {
                    switch (c)
                    {
                        case 1:
                            words += "One ";
                            break;
                        case 2:
                            words += "Two ";
                            break;
                        case 3:
                            words += "Three ";
                            break;
                        case 4:
                            words += "Four ";
                            break;
                        case 5:
                            words += "Five ";
                            break;
                        case 6:
                            words += "Six ";
                            break;
                        case 7:
                            words += "Seven ";
                            break;
                        case 8:
                            words += "Eight ";
                            break;
                        case 9:
                            words += "Nine ";
                            break;
                    }
                }
                if (specialCase == true)
                {
                    switch (d)
                    {
                        case 11:
                            words += "Eleven ";
                            break;
                        case 12:
                            words += "Twelve ";
                            break;
                        case 13:
                            words += "Thirteen ";
                            break;
                        case 14:
                            words += "Fourteen ";
                            break;
                        case 15:
                            words += "Fifteen ";
                            break;
                        case 16:
                            words += "Sixteen ";
                            break;
                        case 17:
                            words += "Seventeen ";
                            break;
                        case 18:
                            words += "Eighteen ";
                            break;
                        case 19:
                            words += "Nineteen ";
                            break;
                    }
                }
                Console.WriteLine(words.ToLower().TrimEnd(' '));
            }
        else
        {
            Console.WriteLine("invalid number");
        }
    }
}
