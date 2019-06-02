using System;

namespace CompulsoryCow.StringExtensions
{
	public static class LeftExtensions
	{
		/// <summary>This method takes the Left of a string in the BASIC fashion like so:
		/// "MyString".Left(2) -- "My"
		/// If one tries to grab for a longer string than there is the string is returned like so:
		/// "MyString".Left(100) -- "MyString"
		/// If null is passed an ArgumentNullException is thrown  like so:
		/// ((string)null).Left(1) -- exception thrown.
		/// </summary>
		/// <param name="me"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string Left( this string me, int length)
		{
			if( null== me)
			{
				throw new ArgumentNullException("me", "Taking the Left of null is not doable.");
			}
			return length <= me.Length ?
				me.Substring(0, length) :
				me;
		}
	}
}
