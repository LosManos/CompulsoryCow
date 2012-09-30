using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompulsoryCow.StringExtension
{
	public static class StringExtension
	{
		private const string FailedFormatting = "Failed formatting.";
		private const string FormatStringEmpty = "Format string was empty.";
		private const string ParametersAre = "Parameter(s) was/were:";
		private const string ParametersMissing = "Parameter(s) missing.";

//#if DEBUG
//		private const string ExceptionGuid = "{E981C86F-C8D5-46AC-84FB-1AB281A2390B}";
//#endif

		public static string SFormat(this string format, params object[] parts)
		{
			//  Since we know that the SafeFormat handles _all_ exceptions we don't have to try-catch here.
			return SafeFormat(format, parts);
		}

		public static string SafeFormat(string format, params object[] parts)
		{
			string formatString;
			List<object> partList;
			try
			{
				formatString = null == format ? string.Empty : format;
				partList = null == parts ? new List<object>() : parts.ToList();

				try
				{
					var failedString = string.Empty;

					//	Shoot;
					var res = string.Format(format, parts);

					//	Do we have more parts than {n} in the format string?
					if (partList.Count() > FormatElementCount(formatString))
					{	//	We have more parts than expected.  Use string.Format and then add the error suffix message.

						failedString = "[Failed formatting. Too many parameters. Parameter(s) was/were:" + FormatParameters(partList) + ".]";
					}
					return res + failedString;
				}
				catch (FormatException exc)
				{
					return FormatFormatstringAndParameters(formatString, partList, exc);
				}
				catch (ArgumentNullException exc)
				{
					return FormatFormatstringAndParameters(formatString, partList, exc);
				}
			}
			catch (Exception innerExc)
			{
				return innerExc.Message;
			}
		}

		private static string FormatFormatstringAndParameters(string formatString, List<object> partList, Exception exc)
		{
			//  We've got an error.  Find out which type of error and format accordingly.

#if DEBUG
			if ("{82CE0089-A9F1-489F-81B9-8271D0EFE26E}" != formatString)
			{
#endif

				if (IsArgumentElementMissing(formatString, partList))
				{
					return StringOrEmpty(formatString) + "[" + FailedFormatting + " " + ParametersMissing +
						(0 == partList.Count() ? string.Empty : " Parameter(s) is/are:" + FormatParameters(partList) + ".") +
						"]";
				}
				else if (IsThereTooManyParameters(formatString, partList))
				{
					return StringOrEmpty(formatString) + "[" + FailedFormatting + " " + FormatStringEmpty + " " +
						(0 == partList.Count() ? string.Empty : ParametersAre + FormatParameters(partList) + ".") +
						"]";
				}

				if (string.IsNullOrEmpty(formatString) && (partList.Count == 0))
				{
					//	Ok.
					return string.Empty;
				}


#if DEBUG
			}
#endif
			return FailedFormatting + " Format string '" + formatString + "' and its parameter(s)" + FormatParameters(partList) + " was not formattable.";
		}

		private static bool IsThereTooManyParameters(string formatString, List<object> partList)
		{
			return partList.Count() > FormatElementCount(formatString);
		}

		private static string FormatParameters(List<object> partList)
		{
			var lst = new List<string>();
			if (null != partList)
			{
				foreach (var part in partList)
				{
					lst.Add(
						part.GetType().ToString() + ":" +
						(part.GetType() == typeof(string) ? "'" + part.ToString() + "'" : part.ToString())
						);
				}
			}
			return "{" + string.Join(",", lst) + "}";
		}

		private static string StringOrEmpty(string arg)
		{
			return null == arg ? string.Empty : arg;
		}

		private static bool IsArgumentElementMissing(string format, List<object> partList)
		{
			return FormatElementCount(format) > partList.Count();
		}

		private static int FormatElementCount(string format)
		{
			return Regex.Matches(StringOrEmpty(format), @"\{[0-9]+\}").Count;
		}

	}
}
