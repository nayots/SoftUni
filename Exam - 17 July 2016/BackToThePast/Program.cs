using System;
//BackToThePast
class BackToThePast
{
    static void Main()
    {
        double inheritance = double.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        double budget = 0;

        for (int i = 1800; i <= year; i++)
        {
            if (i % 2 == 0)
            {
                budget += 12000;
            }
            else
            {
                int age = 18 + (i - 1800);
                budget += 12000 + (50 * age);
            }
        }
        if (budget <= inheritance)
        {
            Console.WriteLine("Yes! He will live a carefree life and will have {0:f2} dollars left.", inheritance - budget);
        }
        else
        {
            Console.WriteLine("He will need {0:f2} dollars to survive.", (inheritance - budget) * -1);
        }
    }
}
