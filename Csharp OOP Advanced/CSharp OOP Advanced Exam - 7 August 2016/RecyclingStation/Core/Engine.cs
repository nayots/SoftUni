using System;
using System.Linq;
using System.Reflection;

namespace RecyclingStation.Core
{
    public class Engine : IEngine
    {
        private const string TerminatingCommand = "TimeToRecycle";

        private IReader reader;
        private IWriter writer;
        private IGarbageManager garbageManager;
        private MethodInfo[] methodsInfo;

        public Engine(IReader reader, IWriter writer, IGarbageManager garbageManager)
        {
            this.reader = reader;
            this.writer = writer;
            this.garbageManager = garbageManager;
            methodsInfo = garbageManager.GetType().GetMethods();
        }

        public void Run()
        {
            string line = string.Empty;

            while ((line = reader.ReadLine()) != TerminatingCommand)
            {
                string[] commandArgs = this.SplitInput(line, " ");
                string methodName = commandArgs[0];
                string[] methodNonParsedParams = new string[0];
                if (commandArgs.Length > 1)
                {
                    methodNonParsedParams = SplitInput(commandArgs[1], "|");
                }

                MethodInfo methodToInvoke = this.methodsInfo.Where(x => x.Name == methodName).FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                ParameterInfo[] methodParams = methodToInvoke.GetParameters();
                object[] parsedParams = new object[methodParams.Length];

                for (int i = 0; i < methodParams.Length; i++)
                {
                    Type currentParam = methodParams[i].ParameterType;

                    parsedParams[i] = Convert.ChangeType(methodNonParsedParams[i], currentParam);
                }

                this.writer.WriteLine((string)methodToInvoke.Invoke(this.garbageManager, parsedParams));
            }
        }

        private string[] SplitInput(string input, string separator)
        {
            return input.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}