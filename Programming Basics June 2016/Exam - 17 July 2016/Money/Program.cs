using System;
//Money
class Money
{
    static void Main()
    {
        double bitcoin = double.Parse(Console.ReadLine());
        double yuan = double.Parse(Console.ReadLine());
        double commission = double.Parse(Console.ReadLine());
        commission = commission / 100;

        double euroBGNValue = 1.95;
        double dollarBGNValue = 1.76;
        bitcoin = bitcoin * 1168;
        yuan = (yuan * 0.15) * dollarBGNValue;

        double sum = (bitcoin + yuan) / euroBGNValue;
        sum = sum - (sum * commission);
        Console.WriteLine(sum);
    }
}
