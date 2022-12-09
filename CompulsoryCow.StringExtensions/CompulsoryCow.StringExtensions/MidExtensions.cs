using System;

namespace CompulsoryCow.StringExtensions;

public static class MidExtensions
{
    /// <summary>This method returns the Mid of a string in the BASIC fashion like so:
    /// "MyString".Mid(1,2) -- "yS"
    /// If one tries to grab for a longer string the result is properly truncated like so:
    /// "MyString".Mid(2, 100) -- "String"
    /// On can also take a negative length to get the string before StartIndex like so:
    /// "MyString".Mid(4, -2) -- "St"
    /// </summary>
    /// <param name="me">Cannot be null.</param>
    /// <param name="startIndex">Must be positive.</param>
    /// <param name="length">Can be negative.</param>
    /// <returns></returns>
    public static string Mid( this string me, int startIndex, int length)
    {
        if( null == me)
        {
            throw new ArgumentNullException("me", "One cannot retrieve a string out of nothing.");
        }
        if( startIndex <= -1)
        {
            throw new ArgumentOutOfRangeException("startIndex", "One cannot get a string to the left of the string.");
        }
        if( string.Empty == me)
        {
            return string.Empty;
        }

        if (length >= 0)
        {
                //return me.Substring(startIndex, Math.Min(me.Length - startIndex, length));
            if (startIndex < me.Length)
            {
                return me.Substring(startIndex, Math.Min(me.Length - startIndex, length));
            }
            else
            {
                return string.Empty;
            }
        }
        else
        {
            var reverseMe = ReverseString(me);
            var newStartIndex = me.Length - startIndex;
            var newLength = -length;
            var res = Mid(reverseMe, newStartIndex, newLength);
            return ReverseString(res);
        }
    }

    private static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
