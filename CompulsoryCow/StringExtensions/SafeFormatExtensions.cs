using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CompulsoryCow.StringExtensions
{
	/// <summary>This class contains methods for the non-exceptions-throwing string.Format behave-alike method.
	/// </summary>
	public static class SafeFormatExtensions
	{
		private const string FailedFormatting = "Failed formatting.";
		private const string FormatStringEmpty = "Format string was empty.";
		private const string ParametersAre = "Parameter(s) was/were:";
		private const string ParametersMissing = "Parameter(s) missing.";

		/// <summary>This method is the regular string.Format(...) but without the exception throwing.
		/// Call it like:
		///		var message = "my format string {0} does rock!".SFormat( "really" );
		/// </summary>
		/// <param name="format">The format string.</param>
		/// <param name="parts">The arguments to insert.</param>
		/// <returns></returns>
		/// <seealso cref="CompulsoryCow.StringExtensionSafeFormat">This is the extension method version of SafeFormat.</seealso>
		public static string SFormat(this string format, params object[] parts)
		{
			//  Since we know that the SafeFormat handles _all_ exceptions we don't have to try-catch here.
			return SafeFormat(format, parts);
		}

		/// <summary>This method is the regular string.Format(...) but without the exception throwing.
		/// </summary>
		/// <param name="format">The format string.</param>
		/// <param name="parts">The arguments to insert.</param>
		/// <returns></returns>
		/// <seealso cref="CompulsoryCow.StringExtension.SFormat">This is the static method version of SafeFormat.</seealso>
		public static string SafeFormat(string format, params object[] parts)
		{
			try
			{
				//	Make safer variables to use - ones that cannot be null.
				//	We have to create these outside of the inner try/catch so we can use it in the catches.
				string formatString = null == format ? string.Empty : format;
				List<object> partList = null == parts ? new List<object>() : parts.ToList();

				try
				{
					//	Shoot.  This is the regular string.Format we use.
					var res = string.Format(format, parts);

					//	Even though the regular string.Format works we can have a hidden problem.
					//	I.e. do we have more parts than {n} in the format string?
					var failedString = string.Empty;
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

		/// <summary>This method counts the number of insertion points e.g.: {0} in the format string.
		/// By the time of writing it does not handle escaped {s.  See https://github.com/LosManos/CompulsoryCow/issues/1
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		private static int FormatElementCount(string format)
		{
			//	Search for {nn}, {nn,ss} and {nn,ss:ff}
			return Regex.Matches(StringOrEmpty(format), @"\{[0-9]+(,[0-9]+)?(:\w+)?\}").Count;	// http://msdn.microsoft.com/en-us/library/txafckwd.aspx
		}

		/// <summary>This method formats the format string and the parameters
		/// to a format somewhat like:
		///     The formatted string[Failed formatting. ....
		/// </summary>
		/// <param name="formatString"></param>
		/// <param name="partList"></param>
		/// <param name="exc">Not used but kept for now.  I can't say exactly why but my spine says it will come in handy
		/// and until then to keep it.  Hmm.  Got to talk to my chiropractor.</param>
		/// <returns></returns>
		private static string FormatFormatstringAndParameters(string formatString, List<object> partList, Exception exc)
		{
			//  We've got an error.  Find out which type of error and format accordingly.

#if DEBUG
			//	Whoa!  This is used for the unit test to make it to the last row "return FailedFormatting...
			if ("{82CE0089-A9F1-489F-81B9-8271D0EFE26E}" != formatString)
			{
#endif

				if (IsArgumentElementMissing(formatString, partList))
				{	//	We have to few {n} in the format string.
					return StringOrEmpty(formatString) + "[" + FailedFormatting + " " + ParametersMissing +
						(0 == partList.Count() ? string.Empty : " Parameter(s) is/are:" + FormatParameters(partList) + ".") +
						"]";
				}
				else if (IsThereTooManyParameters(formatString, partList))
				{	//	We have too many {n} in the format string.
					return StringOrEmpty(formatString) + "[" + FailedFormatting + " " + FormatStringEmpty + " " +
						(0 == partList.Count() ? string.Empty : ParametersAre + FormatParameters(partList) + ".") +
						"]";
				}else if (string.IsNullOrEmpty(formatString) && (partList.Count == 0))
				{	//	We have nothing.  Return nothing.
					//	Ok.
					return string.Empty;
				}


#if DEBUG
			}
#endif
			return FailedFormatting + " Format string '" + formatString + "' and its parameter(s)" + FormatParameters(partList) + " was not formattable.";
		}

		/// <summary>This method returns a list of parameters as a string like
		/// {System.String:'asdf',SystemInt32:42}
		/// </summary>
		/// <param name="partList"></param>
		/// <returns></returns>
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

		/// <summary>This method returns true if there are more {..} in the format string than parts supplied.
		/// </summary>
		/// <param name="format"></param>
		/// <param name="partList"></param>
		/// <returns></returns>
		private static bool IsArgumentElementMissing(string format, List<object> partList)
		{
			return FormatElementCount(format) > partList.Count();
		}

		/// <summary>This method returns true if there are more parts than {...} in the format string.
		/// </summary>
		/// <param name="formatString"></param>
		/// <param name="partList"></param>
		/// <returns></returns>
		private static bool IsThereTooManyParameters(string formatString, List<object> partList)
		{
			return partList.Count() > FormatElementCount(formatString);
		}

		/// <summary>This methdo returns a string as a string and null as an empty string.
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		private static string StringOrEmpty(string arg)
		{
			return null == arg ? string.Empty : arg;
		}

	}
}
