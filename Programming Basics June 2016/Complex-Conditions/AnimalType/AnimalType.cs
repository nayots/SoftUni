using System;
//AnimalType
class AnimalType
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine().ToLower();
        string result = "";

        switch (input)
        {
            case "dog":
                result = "mammal";
                break;
            case "crocodile":
                result = "reptile";
                break;
            case "tortoise":
                result = "reptile";
                break;
            case "snake":
                result = "reptile";
                break;
            default:
                result = "unknown";
                break;
        }
        Console.WriteLine(result);
    }
}
