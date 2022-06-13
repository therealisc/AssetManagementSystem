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
    internal class NumericTextBoxValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
                    var parsingOk = !regex.IsMatch(value.ToString());
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Completeaza un numar intreg");
                    }
                }
            }

#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (value == "")
            {
                validationResult = new ValidationResult(false, "Completeaza un numar intreg");
            }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast

            return validationResult;
        }
    }
}
