using System.Collections.Generic;

namespace CompulsoryCow.CharacterSeparated;

public interface IParse
{
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
    IEnumerable<object?> Line(string line);

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
    IEnumerable<string> StringLine(string line);

    /// <summary>This property contains the properties for the <see cref="IParse"/> class.
    /// </summary>
    ParseOptions Options { get; }
}