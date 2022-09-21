using System;
using System.Windows.Data;

namespace SF52_2015.View.Converters
{
	public class MyTextValidationConverterSalon : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string text1 = values[0] as string;
			if (string.IsNullOrEmpty(text1)) return false;

			string text2 = values[1] as string;
			if (string.IsNullOrEmpty(text2)) return false;

			string text3 = values[2] as string;
			if (string.IsNullOrEmpty(text3)) return false;

			return true;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}