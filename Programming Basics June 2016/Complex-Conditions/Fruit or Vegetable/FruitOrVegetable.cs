using System;
//Fruit or Vegetable
class FruitOrVegetable
{
    static void Main(string[] args)
    {
        string plant = Console.ReadLine();

        if (plant == "banana" || plant == "apple" || plant == "kiwi" || plant == "cherry" || plant == "lemon" || plant == "grapes")
        {
            Console.WriteLine("fruit");
        }
        else if (plant == "tomato" || plant == "cucumber" || plant == "pepper" || plant == "carrot")
        {
            Console.WriteLine("vegetable");
        }
        else
        {
            Console.WriteLine("unknown");
        }
    }
}
