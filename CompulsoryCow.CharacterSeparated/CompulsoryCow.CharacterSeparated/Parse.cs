using System;
using System.Collections.Generic;
using WordParseResult = System.Tuple<bool, object?>;
using System.Linq;
using System.Globalization;

namespace CompulsoryCow.CharacterSeparated;

using WordParser = Func<string, bool, WordParseResult>;

/// <summary>This class contains functionality for parsing a character separated string, 
/// often called a CSV.
/// </summary>
public class Parse : IParse
{
    #region Properties.

    #region Private properties and constants.

    private const string EscapeCharacter = "\\";
    private const string QuoteCharacter = "\"";
    private const string SeparatorCharacter = ",";

    public IList<WordParser> _wordParsers = new List<WordParser>();

    private static readonly WordParser _defaultAsIsParser = (word, implicitString) =>
        implicitString ?
            ParseResultParsed(word) :
            ParseResultNotParsed;

    /// <summary>This method returns a boolean if the word can be parsed as such.
    /// </summary>
    private static readonly WordParser _defaultBoolParser = (word, implicitString) =>
    {
        var w = implicitString ? word.Trim() : word;
        if (bool.TryParse(w, out bool boolResult))
        {
            return ParseResultParsed(boolResult);
        }
        return ParseResultNotParsed;
    };

    /// <summary>This method returns a double if the word can be parsed as  such.
    /// </summary>
    private static readonly WordParser _defaultDoubleParser = (word, implicitString) =>
    {
        var w = implicitString ? word.Trim(): word;
        if (double.TryParse(w, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double doubleResult))
        {
            return ParseResultParsed(doubleResult);
        }
        return ParseResultNotParsed;
    };

    /// <summary>This method returns an int if the word can be parsed as such.
    /// </summary>
    private static readonly WordParser _defaultIntParser = (word, implicitString) =>
    {
        if (int.TryParse(word, out int intResult))
        {
            return ParseResultParsed(intResult);
        }
        return ParseResultNotParsed;
    };

    /// <summary>This method is for returning a blank word as null if we have implicit string.
    /// </summary>
    private static readonly WordParser _defaultStringIfImplicitParser = (word, implicitString) =>
        implicitString == false && word.Length == 0 ?
            ParseResultParsed(null) :
            ParseResultNotParsed;

    /// <summary>This method is for returning a quoted string as a string when we do not have implicit string.
    /// <summary>
    private static readonly WordParser _defaultStringQuotedWhenNotImplicitParser = (word, implicitString) =>
        (implicitString == false && word.Left(1) == QuoteCharacter) ?
            ParseResultParsed(word.Middle()) :
            ParseResultNotParsed;

    #endregion

    #region Public properties.

    /// <summary>This method returns a boolean if the word can be parsed as such.
    /// </summary>
    public WordParser DefaultBoolParser = (word, implicitString) =>
        _defaultBoolParser(word, implicitString);

    /// <summary>This method returns a double if the string can be parsed as such.
    /// </summary>
    public WordParser DefaultDoubleParser = (word, implicitString) =>
        _defaultDoubleParser(word, implicitString);

    /// <summary>This method returns an int if the word can be parsed as such.
    /// </summary>
    public WordParser DefaultIntParser = (word, implicitString) =>
        _defaultIntParser(word, implicitString);

    /// <summary>This method is for returning a blank word as null if we have implicit string.
    /// </summary>
    public WordParser DefaultStringIfImplicitParser = (word, implicitString) =>
        _defaultStringIfImplicitParser(word, implicitString);

    /// <summary>This method is for returning a quoted string as a string when we do not have implicit string.
    /// </summary>
    public WordParser DefaultStringQuotedWhenNotImplicitParser = (word, implicitString) =>
        _defaultStringQuotedWhenNotImplicitParser(word, implicitString);

    /// <summary>This is the list of default word parsers that should suffice for most lines.
    /// </summary>
    public static IList<WordParser> DefaultWordParserList { get; } = new List<WordParser>
    {
        (word, implicitString) => _defaultStringIfImplicitParser(word, implicitString),
        (word, implicitString) => _defaultStringQuotedWhenNotImplicitParser(word, implicitString),
        (word, implicitString) => _defaultIntParser(word, implicitString),
        (word, implicitString) => _defaultBoolParser(word, implicitString),
        (word, implicitString) => _defaultDoubleParser(word, implicitString),
        (word, implicitString) => _defaultAsIsParser(word, implicitString)
    };

    /// <summary>This property contains the properties for the <see cref="IParse"/> class.
    /// </summary>
    public ParseOptions Options { get; set; } = new ParseOptions();

    #endregion

    #endregion

    #region Constructors.

    public Parse(ParseOptions options)
    {
        Options = options;
    }

    public Parse(ParseOptions options, IEnumerable<WordParser> wordParsers)
        : this(options)
    {
        _wordParsers = wordParsers.ToList();
    }

    #endregion

    #region Public methods.

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
    public IEnumerable<object?> Line(string line)
    {
        if (line == null) { throw new ArgumentNullException(nameof(line)); }

        if (line.Contains(SeparatorCharacter) == false)
        {
            return new object?[] { ParseWord(line, Options.ImplicitString, _wordParsers) };
        }
        return Traverse(line, Options.ImplicitString, _wordParsers);
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
        return StringTraverse(line, Options.ImplicitString);
    }

    #endregion

    #region Private methods.

    private static WordParseResult ParseResultNotParsed => new WordParseResult(false, null);

    private static WordParseResult ParseResultParsed(object? result) => new WordParseResult(true, result);

    private static object? ParseWord(string word, bool implicitString, IList<WordParser> wordParsers)
    {
        if (implicitString == false)
        {
            word = word.Trim();
        }

        foreach (var wordParser in wordParsers.Any() ? wordParsers : DefaultWordParserList)
        {
            var result = wordParser(word, implicitString);
            if (result.Item1)
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

    private static IEnumerable<object?> Traverse(string line, bool implicitString, IList<WordParser> wordParsers)
    {
        var res = new List<object?>();
        var word = string.Empty;
        var isInQuote = false;
        do
        {
            var c = Pop(ref line, ref isInQuote, implicitString);
            if (c == SeparatorCharacter && isInQuote == false)
            {
                res.Add(ParseWord(word, implicitString, wordParsers));
                word = string.Empty;
            }
            else
            {
                word += c;
            }
        } while (line.Length >= 1);

        res.Add(ParseWord(word, implicitString, wordParsers));
        return res;
    }

    #endregion
}
