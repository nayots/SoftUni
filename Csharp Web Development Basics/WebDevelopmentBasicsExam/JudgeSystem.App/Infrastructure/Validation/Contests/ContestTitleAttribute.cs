using SimpleMvc.Framework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Infrastructure.Validation.Contests
{
    public class ContestTitleAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var input = value as string;

            if (!char.IsUpper(input[0]) || (input.Length < 3 || input.Length > 100))
            {
                return false;
            }

            return true;
        }
    }
}