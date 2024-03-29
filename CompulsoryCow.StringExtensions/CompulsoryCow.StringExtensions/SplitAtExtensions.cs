﻿using System;

namespace CompulsoryCow.StringExtensions;

	public static class SplitAtExtensions
{
    /// <summary>This extension method allows the caller to split a string at a certain index.
    /// E.g.: "abc".SplitAt(1) returns a string Tuple "a", "bc".
    /// </summary>
    /// <param name="me"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Tuple<string,string> SplitAt(this string me, int index)
    {
        var item1 = me.Substring(0, index);
        var item2 = me.Substring(index, me.Length - index);

        return new Tuple<string, string>(item1??"", item2??"");
    }

    /// <summary>This method allows the caller to split a string by another string.
    /// The prefix and suffix are returned.
    /// </summary>
    /// <param name="me"></param>
    /// <param name="splitter"></param>
    /// <returns></returns>
    public static Tuple<string, string> SplitAt(this string me, string splitter)
    {
        var index = me.IndexOf(splitter);
        var item1 = me.Substring(0, index);
        var item2 = me.Substring(index + splitter.Length, me.Length - index - splitter.Length);

        return new Tuple<string, string>(item1 ?? "", item2 ?? "");
    }
}
