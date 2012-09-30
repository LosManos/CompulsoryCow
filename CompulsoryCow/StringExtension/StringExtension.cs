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

						//	TODO:	Convert this to linq or something more easy to read.
						//var partsNotUsedList = PartsNotUsed(formatString, partList);
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

		//private static object PartsNotUsed(string formatString, List<object> partList)
		//{
		//	//	TODO:	Can we use yield?
		//	//	TODO:	Or linq or something else more readable.
		//	var ret = new List<object>();
		//	for (var i = 0; i < partList.Count(); ++i)
		//	{
		//		if (i >= FormatElementCount(formatString))
		//		{
		//			ret.Add(partList[i]);
		//		}
		//	}
		//	return ret;
		//}

		private static string FormatFormatstringAndParameters(string formatString, List<object> partList, Exception exc)
		{
			//  We've got an error.  Find out which type of error and format accordingly.

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

			//	TODO:	Test this exception.
			//	TODO:	Inherit to create a unique exception.
			throw new Exception(FailedFormatting + " Format [" + formatString + "] and its " + partList.Count().ToString() + " was not formattable.");
		}

		private static bool IsThereTooManyParameters(string formatString, List<object> partList)
		{
			return partList.Count() > FormatElementCount(formatString);
		}

		//private static bool IsPartsMissing(object[] parts)
		//{
		//	return null == parts || parts.Length == 0;
		//}

		//private static bool IsFormatMissing(string format)
		//{
		//	return null == format;
		//}

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

		//private static int PartsLength(object[] parts)
		//{
		//	if (null == parts)
		//	{
		//		return 0;
		//	}
		//	else
		//	{
		//		return parts.Length;
		//	}
		//}

	}
}
