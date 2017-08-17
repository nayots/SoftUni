using Problem1_Logger.Models.Appenders.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Problem1_Logger.Core.Factories
{
    public class AppenderFactory<T> : IFactory<T>
    {
        private const string AppenderNameSpace = "Problem1_Logger.Models.Appenders.";

        public T Create(IList<string> data)
        {
            string appenderType = data[0];
            ReportLevel reportLevel = 0;
            if (data.Count > 2)
            {
                string rLevel = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data[2].ToLower());

                reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), rLevel);
            }

            Type appenderClassType = Type.GetType(AppenderNameSpace + appenderType);

            T appender = (T)Activator.CreateInstance(appenderClassType, new object[] { null, reportLevel });

            return appender;
        }
    }
}