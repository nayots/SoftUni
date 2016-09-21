using System;
using System.Globalization;
//Program 15: 1k DAB
class OneKAfterBirth
{
    static void Main(string[] args)
    {
            string userInput = Console.ReadLine();
            string format = "dd-MM-yyyy";
            DateTime userDate = DateTime.ParseExact(userInput, format, CultureInfo.InvariantCulture);
            userDate = userDate.AddDays(999);
            Console.WriteLine(userDate.ToString(format));
    }
}