using Problem2_BlackBoxInt.Models;
using System;
using System.Reflection;

namespace Problem2_BlackBoxInt
{
    class Startup
    {
        private static void Main(string[] args)
        {
            Type classType = typeof(BlackBoxInt);

            ConstructorInfo ctorInfo = classType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(int) }, null);

            BlackBoxInt blackBox = (BlackBoxInt)ctorInfo.Invoke(new object[] { 0 });

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            string input = string.Empty;
            MethodInfo currentMethod = null;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                string methodName = tokens[0];
                int inputValue = int.Parse(tokens[1]);

                currentMethod = classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                currentMethod.Invoke(blackBox, new object[] { inputValue });

                FieldInfo innerValue = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(innerValue.GetValue(blackBox));
            }
        }
    }
}