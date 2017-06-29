using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DateModifier
{
    public int DateDifferenceDays { get; set; }

    public void FindDifference(string dateOne, string dateTwo)
    {
        try
        {
            DateTime date1 = DateTime.Parse(dateOne);
            DateTime date2 = DateTime.Parse(dateTwo);

            var result = Math.Abs((date1 - date2).TotalDays);
            this.DateDifferenceDays = (int)result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}