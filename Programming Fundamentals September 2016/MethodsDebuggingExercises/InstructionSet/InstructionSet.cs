using System;
//16. Be Positive
namespace InstructionSet
{
    class InstructionSet
    {
        static void Main()
        {
            string instruction = Console.ReadLine().ToUpper();

            while (instruction != "END")
            {
                string[] codeArgs = instruction.Split(' ');

                long result = 0;
                switch (codeArgs[0])
                {
                    case "INC":
                        {
                            long operandOne = long.Parse(codeArgs[1]);
                            result = ++operandOne;
                            break;
                        }
                    case "DEC":
                        {
                            long operandOne = long.Parse(codeArgs[1]);
                            result = --operandOne;
                            break;
                        }
                    case "ADD":
                        {
                            long operandOne = long.Parse(codeArgs[1]);
                            long operandTwo = long.Parse(codeArgs[2]);
                            result = operandOne + operandTwo;
                            break;
                        }
                    case "MLA":
                        {
                            long operandOne = long.Parse(codeArgs[1]);
                            long operandTwo = long.Parse(codeArgs[2]);
                            result = ((long)operandOne * operandTwo);
                            break;
                        }
                }

                Console.WriteLine(result);
                instruction = Console.ReadLine();
            }
        }
    }
}
