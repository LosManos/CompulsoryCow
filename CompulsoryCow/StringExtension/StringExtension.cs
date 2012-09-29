using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompulsoryCow.StringExtension
{
    public static class StringExtension
    {
        public static string SFormat(this string format, params object[] parts)
        {
            try
            {
                return SafeFormat(format, parts);
            }
            catch (Exception exc)
            {
                return FormatFormatstringAndParameters(format, parts);
            }
        }

        private static string FormatFormatstringAndParameters(string format, object[] parts)
        {
            throw new NotImplementedException();
        }

        public static string SafeFormat(string format, params object[] parts)
        {
            try
            {
                return string.Format(format, parts);
            }
            catch (Exception exc)
            {
                return FormatFormatstringAndParameters(format, parts);
            }
        }
    }
}
