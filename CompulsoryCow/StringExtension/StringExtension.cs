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
		private const string ParametersAre = "Parameters are:";
		private const string ParametersMissing = "Parameter(s) missing.";

		public static string SFormat(this string format, params object[] parts)
		{
			//  Since we know that the SafeFormat handles _all_ exceptions we don't have to try-catch here.
			return SafeFormat(format, parts);
		}

		public static string SafeFormat(string format, params object[] parts)
		{
			try
			{
				try
				{
					return string.Format(format, parts);
				}
				catch (FormatException exc)
				{
					return FormatFormatstringAndParameters(format, parts, exc);
				}
				catch (ArgumentNullException exc)
				{
					return FormatFormatstringAndParameters(format, parts, exc);
				}
			}
			catch (Exception innerExc)
			{
				return innerExc.Message;
			}
		}

		private static string FormatFormatstringAndParameters(string format, object[] parts, Exception exc)
		{
			//  We've got an error.  Find out which type of error and format accordingly.

			if (IsArgumentElementMissing(format, parts))
			{
				return StringOrEmpty(format) + "[" + FailedFormatting + " " + ParametersMissing +
					(IsPartsMissing(parts) ? string.Empty : " " + FormatParameters(parts)) +
					"]";
			}

			if (IsFormatMissing(format) && IsPartsMissing( parts ))
			{
				//	Ok.
				return string.Empty;
			}

			throw new NotImplementedException("This method does still not handle...");
		}

		private static bool IsPartsMissing(object[] parts)
		{
			return null == parts || parts.Length == 0;
		}

		private static bool IsFormatMissing(string format)
		{
			return null == format;
		}

		private static string FormatParameters(object[] parts)
		{
			var lst = new List<string>();
			if (null != parts)
			{
				foreach (var part in parts)
				{
					lst.Add(part.GetType().ToString() + "," +
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

		private static bool IsArgumentElementMissing(string format, object[] parts)
		{
			return FormatElementCount(format) > PartsLength(parts);
		}

		private static int FormatElementCount(string format)
		{
			return Regex.Matches(StringOrEmpty(format), @"\{[0-9]+\}").Count;
		}

		private static int PartsLength(object[] parts)
		{
			if (null == parts)
			{
				return 0;
			}
			else
			{
				return parts.Length;
			}
		}

	}
}
