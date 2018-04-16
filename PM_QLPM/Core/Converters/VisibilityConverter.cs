using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PM_QLPM.Core.Converters
{
    // Using this converter for adding button
    public class AddingVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var numberOfPatientsToday = (int)values[0];
            var datePicked = (DateTime)values[1];
            if (numberOfPatientsToday > Helper.GetMaximumPatientToday() || datePicked != DateTime.Today)
                return false;
            else
                return true;
        }
        
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    // Using this converter for removing/printing button
    public class RemovingVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var numberOfPatientsToday = (int)values[0];
            var datePicked = (DateTime)values[1];
            if (numberOfPatientsToday == 0 || datePicked != DateTime.Today)
                return false;
            else
                return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class PrintingVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var numberOfPatientsToday = (int)values[0];
            if (numberOfPatientsToday == 0)
                return false;
            else
                return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class RemovingPillConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(values[0].ToString(), out int numberOfSelectedPills);
            int.TryParse(values[1].ToString(), out int numberOfPillInScript);
            if (numberOfSelectedPills > 0 && numberOfPillInScript > 0)
                return true;
            else
                return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class EditingPillConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(values[0].ToString(), out int numberOfSelectedPills);
            int.TryParse(values[1].ToString(), out int numberOfPillInScript);
            if (numberOfSelectedPills == 1 && numberOfPillInScript > 0)
                return true;
            else
                return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class EditingPatientProfileConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(values[0].ToString(), out int numberOfSelectedPatient);
            int.TryParse(values[1].ToString(), out int numberOfPatientInList);
            if (numberOfSelectedPatient == 1 && numberOfPatientInList > 0)
                return true;
            else
                return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SavingVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class DeleteUserVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
