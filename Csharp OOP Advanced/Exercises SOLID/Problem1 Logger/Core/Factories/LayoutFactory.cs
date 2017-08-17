using System;
using System.Collections.Generic;

namespace Problem1_Logger.Core.Factories
{
    public class LayoutFactory<T> : IFactory<T>
    {
        private const string LayoutNameSpace = "Problem1_Logger.Models.Layouts.";

        public T Create(IList<string> data)
        {
            string layoutType = data[1];

            Type layoutClassType = Type.GetType(LayoutNameSpace + layoutType);

            T layout = (T)Activator.CreateInstance(layoutClassType);

            return layout;
        }
    }
}