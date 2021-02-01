using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace LutrijaWpfEF.UI.Converters
{   
        public class DatumKonverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                CultureInfo ci = new CultureInfo("bs-Latn-BA");
                DateTimeFormatInfo dtfi = ci.DateTimeFormat;

                DateTime datum = (DateTime)value;

                if (value != DBNull.Value && (datum.Year != 1 && datum.Month != 1 && datum.Day != 1))
                {
                    DateTime date = (DateTime)value;
                    return date.ToString("dd/MM/yyyy\nH:mm:ss", ci);
                }
                else if (value != DBNull.Value && datum.Year != 1)
                {
                    DateTime date = (DateTime)value;
                    return date.ToString("dd/MM/yyyy\nH:mm:ss", ci);
                }
                else
                {
                    return "";
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                DateTime datum = DateTime.MinValue;

                if (value != null)
                {
                    datum = (DateTime)value;
                }

                return datum;
            }
        }
    }


