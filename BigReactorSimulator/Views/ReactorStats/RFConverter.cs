using System;
using System.Globalization;
using System.Windows.Data;

namespace BigReactorSimulator.Views.ReactorStats
{
    public class RFConverter : IValueConverter
    {
        public const string NO_RF = "0.00 RF";

        public static readonly string[] sizePrefixes = new string[] { "", "Ki", "Me", "Gi", "Te", "Pe", "Ex", "Ze", "Yo" };

        // totally took this right from the mod itself
        // :)
        public static string FormatRF(float rf)
        {
            string prefix = "";
            if (rf < 0.0F)
            {
                prefix = "-";
                rf *= -1.0F;
            }

            if (rf <= 1.0E-5F)
                return NO_RF;

            int power = (int)Math.Floor(Math.Log10(rf));
            int decimalPoints = 2 - power % 3;
            int letterIdx = Math.Max(0, Math.Min(sizePrefixes.Length, power / 3));
            float divisor = letterIdx * 1000.0F;
            if (divisor > 0.0F)
                return string.Format(
                    "%s%." + decimalPoints.ToString() + "f %sRF",
                    prefix,
                    rf / divisor,
                    sizePrefixes[letterIdx]);
            else
                return string.Format(
                    "%s%." + decimalPoints.ToString() + "f RF",
                    prefix,
                    rf);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float rf)
                return FormatRF(rf);

            return NO_RF;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0.0f;
        }
    }
}
