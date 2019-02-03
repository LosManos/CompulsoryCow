using System;
using System.Collections.Generic;

namespace CompulsoryCow.CharacterSeparated
{
    public class Parse
    {
        private const string EscapeCharacter = "\\";
        private const string QuoteCharacter = "\"";
        private const string SeparatorCharacter = ",";

        /// <summary>This method splits a string into words per comma (,).
        /// If you have a word with a comma in it, quote the string with quotes ("). The quotes are a part of the word.
        /// Everything returned is a string.
        /// Nothing at all or nothing between commas is returned as an empty string.
        /// Null throws an exception.
        /// If you are looking for a method that converts to types, look at <see cref="Line(string)"/>.
        /// 
        /// StringLine.Parse( "a,b" ) == [ "a", "b" ];
        /// StringLine.Parse( "\"a,b\"" ) == [ "\"a,b\"" ];
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static IEnumerable<string> StringLine(string line)
        {
            if (line == null) { throw new ArgumentNullException(nameof(line)); }

            if (line.Contains(SeparatorCharacter) == false)
            {
                return line.Split(new[] { SeparatorCharacter }, StringSplitOptions.None);
            }
            return StringTraverse(line);
        }

        /// <summary>This method splits a string into words per comma (,).
        /// Each word is returns as a value of its type.
        /// Strings are recognised by quoting (")
        /// All words are trimmed.
        /// Unknown types throws an exception.
        /// Null input throws an exception.
        /// 
        /// Parse.Line( "\"a\", 2, 3.14" ) == [ "a", (int)2, (double)3.14 ];
        /// Parse.Line( "a" ) throws exception.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static IEnumerable<object> Line(string line)
        {
            if (line == null) { throw new ArgumentNullException(nameof(line)); }

            if (line.Contains(SeparatorCharacter) == false)
            {
                return new object[] { ParseWord(line) };
            }
            return Traverse(line);
        }


        private static IEnumerable<string> StringTraverse(string line)
        {
            var res = new List<string>();
            var word = string.Empty;
            var isInQuote = false;
            do
            {
                var c = Pop(ref line, ref isInQuote);
                if (c == SeparatorCharacter && isInQuote == false)
                {
                    res.Add(word);
                    word = string.Empty;
                }
                else
                {
                    word += c;
                }
            } while (line.Length >= 1);
            res.Add(word);
            return res;
        }

        private static IEnumerable<object> Traverse(string line)
        {
            var res = new List<object>();
            var word = string.Empty;
            var isInQuote = false;
            do
            {
                var c = Pop(ref line, ref isInQuote);
                if (c == SeparatorCharacter && isInQuote == false)
                {
                    res.Add(ParseWord(word));
                    word = string.Empty;
                }
                else
                {
                    word += c;
                }
            } while (line.Length >= 1);

            res.Add(ParseWord(word));
            return res;
        }

        private static object ParseWord(string word)
        {
            word = word.Trim();
            if (word.Length == 0)
            {
                return null;
            }
            if (word.Left(1) == QuoteCharacter)
            {
                return word.Middle();
            }
            if (int.TryParse(word, out int intResult))
            {
                return intResult;
            }
            if (bool.TryParse(word, out bool boolResult))
            {
                return boolResult;
            }
            if (double.TryParse(word, out double doubleResult))
            {
                return doubleResult;
            }
            throw new ArgumentException($"The string [{word}] was not a recognised format.");
        }

        private static string Pop(ref string line, ref bool isInQuote)
        {
            var character = line.Left(1);
            line = line.Tail();
            var isEscaped = character == EscapeCharacter;
            if (isEscaped)
            {
                character = line.Left(1);
                line = line.Tail();
            }
            if (isEscaped == false && character == QuoteCharacter)
            {
                isInQuote = !isInQuote;
            }
            return character;
        }
    }

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
}
