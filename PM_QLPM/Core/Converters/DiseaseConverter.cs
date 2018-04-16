using PM_QLPM.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PM_QLPM.Core.Converters
{
    public class DiseaseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
                return values[0].ToString() + " - " + values[1].ToString();
            else
                return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] s = new string[] {   value.ToString().Substring(0, 4),
                                          value.ToString().Substring(7)  };
            return s;
        }
    }

    public class DiseaseIdToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                return dc.BENHs.Single(x => x.Ma_Benh == value.ToString()).TenBenh;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
