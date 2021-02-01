using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LutrijaWpfEF.UI.Validation_Rules
{
       public class ComboboxValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
                if (value != null)
                {
                    var type = value.GetType();

                    if (type.FullName.Equals("System.String"))
                    {
                        if ((string)value == "")
                            return new ValidationResult(false, "Ne može biti prazno.");
                        else
                            return ValidationResult.ValidResult;
                    }
                    else
                    {

                        if (value == DBNull.Value)
                        {
                            return new ValidationResult(false, "Ne može biti prazno.");
                        }
                        else
                        {
                            return ValidationResult.ValidResult;
                        }
                    }
                }
                else
                {
                    return new ValidationResult(false, "Ne može biti prazno.");
                }
            }
        }
    }

