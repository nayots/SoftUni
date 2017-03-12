using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographersDB
{
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string tagString = (string)value;

            if (!tagString.StartsWith("#"))
            {
                return false;
            }
            if (tagString.Contains(" ") || tagString.Contains("\t"))
            {
                return false;
            }
            if (tagString.Length > 20)
            {
                return false;
            }
            return true;
        }
    }
}
