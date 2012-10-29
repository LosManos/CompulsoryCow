using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompulsoryCow.StringExtension
{
    public static class SplitAtExtension
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
    }
}
