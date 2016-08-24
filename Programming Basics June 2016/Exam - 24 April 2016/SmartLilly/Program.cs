using System;
//SmartLilly
class SmartLilly
{
    static void Main()
    {
        int age = int.Parse(Console.ReadLine());
        double wmPrice = double.Parse(Console.ReadLine());
        int toyPrice = int.Parse(Console.ReadLine());
        double money = 0;
        int giftMoney = 0;
        int broMoney = 0;
        for (int i = 1; i <= age; i++)
        {
            if (i % 2 == 0)
            {
                giftMoney += 10;
                broMoney++;
                money += giftMoney;
            }
            else
            {
                money += toyPrice;
            }
        }
        money -= broMoney;
        if (money >= wmPrice)
        {
            Console.WriteLine("Yes! {0:f2}", money - wmPrice);
        }
        else
        {
            Console.WriteLine("No! {0:f2}", wmPrice - money);
        }
    }
}
