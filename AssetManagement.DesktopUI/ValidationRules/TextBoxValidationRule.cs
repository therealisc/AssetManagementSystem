using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AssetManagement.DesktopUI.ValidationRules 
{
    public class TextBoxValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) == false)
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Campul trebuie completat.");
        }
    }
}
