using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AssetManagement.DesktopUI.ValidationRules
{
    internal class ClasificationCodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex(@"^(\d+\.)?(\d+\.)?(\*|\d+\.)*$"); // example 1.2.2.  or  2.11.4.5.
                    var parsingOk = regex.IsMatch(value.ToString());
                    if (parsingOk == false)
                    {
                        validationResult = new ValidationResult(false, "Cod de clasificare invalid");
                    }
                }
            }

            return validationResult;
        }
    }
}
