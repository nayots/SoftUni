using System;
//Operations
class Operations
{
    static void Main()
    {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        string ope = Console.ReadLine();

        if (n2 == 0)
        {
            Console.WriteLine("Cannot divide {0} by zero", n1);
            return;
        }
        double result = 0;
        if (ope == "+" || ope == "-" || ope == "*")
        {
            switch (ope)
            {
                case "+":
                    result = n1 + n2;
                    break;
                case "-":
                    result = n1 - n2;
                    break;
                case "*":
                    result = n1 * n2;
                    break;
            }

            string type = "odd";
            if (result % 2 == 0)
            {
                type = "even";
            }
            Console.WriteLine("{0} {1} {2} = {3} - {4}", n1, ope, n2, result, type);
        }
        else if (ope == "/")
        {
            result = (double)n1 / (double)n2;
            Console.WriteLine("{0} / {1} = {2:f2}", n1, n2, result);
        }
        else if (ope == "%")
        {
            result = n1 % n2;
            Console.WriteLine("{0} % {1} = {2}",n1, n2, result);
        }
    }
}
