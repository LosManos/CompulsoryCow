using System;

namespace CompulsoryCow.StringExtensions
{
    public static class RightExtensions
    {
        /// <summary>This method takes the Right of a string like so:
        /// "MyString".Right(6) -- "String"
        /// If one tries to grab for a longer string than there is the string is returned like so:
        /// "MyString".Right(100) -- "MyString"
        /// If null is passed an ArgumentNullException is thrown  like so:
        /// ((string)null).Right(1) -- exception thrown.
        /// </summary>
        /// <param name="me"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string me, int length)
        {
            if (null == me)
            {
                throw new ArgumentNullException("me", "Taking the Right of null is not doable.");
            }
            return length <= me.Length ?
                me.Substring(me.Length - length, length) :
                me;
        }
    }
}
