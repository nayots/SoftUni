using InfernoInfinity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoInfinity.Core
{
    public class InputHandler : IInputHandler
    {
        public List<string> SplitInput(string input, string splitValue)
        {
            return input.Split(new string[] { $"{splitValue}" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}