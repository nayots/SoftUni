using System;
//MetricConverter
class MetricConverter
{
    static void Main(string[] args)
    {
        double inputNumber = double.Parse(Console.ReadLine());
        string inUnit = Console.ReadLine();
        string outUnit = Console.ReadLine();
        double convertion = 0;
        switch (inUnit)
        {
            case "m":
                convertion = inputNumber;
                break;
            case "mm":
                convertion = inputNumber / 1000;
                break;
            case "cm":
                convertion = inputNumber / 100;
                break;
            case "mi":
                convertion = inputNumber * 1609.344;
                break;
            case "in":
                convertion = inputNumber * 0.0254;
                break;
            case "km":
                convertion = inputNumber * 1000;
                break;
            case "ft":
                convertion = inputNumber * 0.3048;
                break;
            case "yd":
                convertion = inputNumber * 0.9144;
                break;
        }
        switch (outUnit)
        {
            case "m":
                convertion = convertion * 1;
                break;
            case "mm":
                convertion = convertion * 1000;
                break;
            case "cm":
                convertion = convertion * 100;
                break;
            case "mi":
                convertion = convertion * 0.000621371192;
                break;
            case "in":
                convertion = convertion * 39.3700787;
                break;
            case "km":
                convertion = convertion * 0.001;
                break;
            case "ft":
                convertion = convertion * 3.2808399;
                break;
            case "yd":
                convertion = convertion * 1.0936133;
                break;
            default:
                break;
        }
        Console.WriteLine(convertion);
    }
}
