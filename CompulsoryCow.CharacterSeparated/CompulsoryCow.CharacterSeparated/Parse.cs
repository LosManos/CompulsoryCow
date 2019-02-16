﻿using System;
using System.Collections.Generic;
using WordParseResult = System.Tuple<bool, object>;
using WordParser = System.Func<string, bool, /*WordParseResult*/ System.Tuple<bool, object>>;

namespace CompulsoryCow.CharacterSeparated
{
    public class Parse
    {
        private const string EscapeCharacter = "\\";
        private const string QuoteCharacter = "\"";
        private const string SeparatorCharacter = ",";

        private readonly bool _implicitString = false;

        private readonly IList<WordParser> _wordParsers = new List<WordParser>();

        private static readonly IList<WordParser> _defaultWordParserList = new List<WordParser>
        {
            (word, implicitString) =>{
                if (word.Length == 0)
                {
                    if (implicitString == false)
                    {
                        return ParseResultParsed(null);
                        }
                    }
                return ParseResultNotParsed;
            },
            (word, implicitString) => {
                if ((implicitString == false) && word.Left(1) == QuoteCharacter)
                {
                    return ParseResultParsed(word.Middle());
                }
                return ParseResultNotParsed;
            },
            (word, implicitString) =>
            {
                if (int.TryParse(word, out int intResult))
                {
                    return ParseResultParsed(intResult);
                }
                return ParseResultNotParsed;
            },
            (word, implicitString) =>
            {
                if (implicitString == false)
                {
                    if (bool.TryParse(word, out bool boolResult))
                    {
                        return ParseResultParsed( boolResult);
                    }
                }
                return ParseResultNotParsed;
            },
            (word, implicitString) =>
            {
                if (double.TryParse(word, out double doubleResult))
                {
                    return ParseResultParsed(doubleResult);
                }
                return ParseResultNotParsed;
            },
            (word, implicitString) =>
            {
                if (double.TryParse(word, out double doubleResult))
                {
                    return ParseResultParsed(doubleResult);
                }
                return ParseResultNotParsed;
            },
            (word, implicitString) =>
            {
                if (implicitString)
                {
                    return ParseResultParsed(word);
                }
                return ParseResultNotParsed;
            },
        };

        private static WordParseResult ParseResultNotParsed => new WordParseResult(false, null);

        private static WordParseResult ParseResultParsed(object result)=> new WordParseResult(true, result);

        public Parse(bool implicitString)
        {
            _implicitString = implicitString;
        }

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
        public IEnumerable<string> StringLine(string line)
        {
            if (line == null) { throw new ArgumentNullException(nameof(line)); }

            if (line.Contains(SeparatorCharacter) == false)
            {
                return line.Split(new[] { SeparatorCharacter }, StringSplitOptions.None);
            }
            return StringTraverse(line, _implicitString);
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
        public IEnumerable<object> Line(string line)
        {
            if (line == null) { throw new ArgumentNullException(nameof(line)); }

            if (line.Contains(SeparatorCharacter) == false)
            {
                return new object[] { ParseWord(line, _implicitString) };
            }
            return Traverse(line, _implicitString);
        }

        private static IEnumerable<string> StringTraverse(string line, bool implicitString)
        {
            var res = new List<string>();
            var word = string.Empty;
            var isInQuote = false;
            do
            {
                var c = Pop(ref line, ref isInQuote, implicitString);
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

        private static IEnumerable<object> Traverse(string line, bool implicitString)
        {
            var res = new List<object>();
            var word = string.Empty;
            var isInQuote = false;
            do
            {
                var c = Pop(ref line, ref isInQuote, implicitString);
                if (c == SeparatorCharacter && isInQuote == false)
                {
                    res.Add(ParseWord(word, implicitString));
                    word = string.Empty;
                }
                else
                {
                    word += c;
                }
            } while (line.Length >= 1);

            res.Add(ParseWord(word, implicitString));
            return res;
        }

        private static object ParseWord(string word, bool implicitString)
        {
            if (implicitString == false)
            {
                word = word.Trim();
            }
            foreach( var wordParser in _defaultWordParserList)
            {
                var result = wordParser(word, implicitString);
                if(result.Item1)
                {
                    return result.Item2;
                }
            }
            throw new ArgumentException($"The string [{word}] was not a recognised format.");
        }

        private static string Pop(ref string line, ref bool isInQuote, bool implicitString)
        {
            var character = line.Left(1);
            line = line.Tail();
            var isEscaped = character == EscapeCharacter;
            if (isEscaped) // && implicitString)
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
