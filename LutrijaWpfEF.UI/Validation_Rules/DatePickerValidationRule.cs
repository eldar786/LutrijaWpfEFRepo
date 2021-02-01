using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LutrijaWpfEF.UI.Validation_Rules
{
        public class DatePickerValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                if (value == null || value.ToString() == "01.01.0001.")
                {
                    return new ValidationResult(false, "Polje ne može biti prazno");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
        }
}


