using System;
//13. Vowel or Digit
namespace VowelOrDigit
{
    public class VowelOrDigit
    {
        public static void Main(string[] args)
        {
            string userInput = Console.ReadLine().ToLower() ;
            int num = 0;
            if (int.TryParse(userInput,out num))
            {
                Console.WriteLine("digit");
            }
            else
            {
                switch (userInput)
                {
                    case "a":
                        Console.WriteLine("vowel");
                        break;
                    case "e":
                        Console.WriteLine("vowel");
                        break;
                    case "i":
                        Console.WriteLine("vowel");
                        break;
                    case "o":
                        Console.WriteLine("vowel");
                        break;
                    case "u":
                        Console.WriteLine("vowel");
                        break;
                    case "y":
                        Console.WriteLine("vowel");
                        break;
                    default:
                        Console.WriteLine("other");
                        break;
                }
            }
        }
    }
}
