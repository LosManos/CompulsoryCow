using System;

namespace CompulsoryCow.CharacterSeparated;

internal static class StringExtensions
{
    internal static string Middle(this string value)
    {
        return value.Substring(1, value.Length - 2);
    }

    // https://stackoverflow.com/questions/1722334/extract-only-right-most-n-letters-from-a-string
    public static string Left(this string str, int length)
    {
        str = (str ?? string.Empty);
        return str.Substring(0, Math.Min(length, str.Length));
    }

    internal static string Tail(this string line)
    {
        return line.Length >= 1 ? line.Substring(1) : string.Empty;
    }
}
