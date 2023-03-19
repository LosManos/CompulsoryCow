using CompulsoryCow.CharacterSeparated;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using WordParseResult = System.Tuple<bool, object?>;

namespace CharacterSeparatedTest;

using WordParser = Func<string, bool, WordParseResult>;

public class ParseTest
{
    [Fact]
    public void CanChangeWordParsers()
    {
        //  #   Arrange.
        var sut = new Parse(new ParseOptions { ImplicitString = false });
        WordParser wordParser = (word, implicitString) => new WordParseResult(word == "a", word == "a" ? "match" : "fail");

        //  #   Act.
        sut._wordParsers = new List<WordParser>
        {
            (word, implicitString) => wordParser(word, implicitString)
        };
        var res = sut.Line("a").ToList();

        //  #   Assert.
        res.Single().Should().Be("match", "We parse as simple as can be, just a constant.");
    }

    [Fact]
    public void CanSetWordParsers()
    {
        //  #   Arrange.
        var sut = new Parse(
            new ParseOptions { ImplicitString = false },
            new WordParser[] { (word, implicitString) =>
                new WordParseResult(true, "whatever") });

        //  #   Act.
        var res = sut.Line("a").ToList();

        //  #   Assert.
        res.Single().Should().Be("whatever", "We parse as simple as can be, just a constant.");
    }

    public static IEnumerable<object[]> CanSetOptionsData
    {
        get
        {
            yield return new object[] { false };
            yield return new object[] { true };
        }
    }

    [Theory]
    [MemberData(nameof(CanSetOptionsData))]
    public void CanSetOptions(bool implicitString)
    {
        //  #   Arrange.
        var options = new ParseOptions { ImplicitString = true };
        var sut = new Parse(options);

        //  #   Act.
        var res = sut.Options;

        //  #   Assert.
        options.Should().Be(res);
    }

    [Fact]
    public void CanUseDefaultWordParsers()
    {
        //  #   Arrange.
        var sut1 = new Parse(new ParseOptions { ImplicitString = true }, Parse.DefaultWordParserList);
        var sut2 = new Parse(new ParseOptions { ImplicitString = true });

        //  #   Act.
        var res1 = sut1.Line("a,1");
        var res2 = sut2.Line("a,1");

        //  #   Assert.
        // The assertion lib has functions for comparing lists but this is written on an aircraft, at 11000m.
        res1.First().Should().Be(res2.First(), "Setting to default word parsers should be the same as ... default.");
        res1.Skip(1).Single().Should().Be(res2.Skip(1).Single(), "Setting to default word parsers should be the same as ... default.");
    }

    #region StringLine tests.

    public static IEnumerable<object?[]> ParseStringLineData
    {
        get
        {
            yield return new object?[] { "No split.", "", null, new[] { "" } };
            yield return new object?[] { "Empty split.", ",", null, new[] { "", "" } };
            yield return new object?[] { "Without split.", "a", null, new[] { "a" } };
            yield return new object?[] { "Long string.", "abc", null, new[] { "abc" } };
            yield return new object?[] { "Splitting longer.", "abc, def", null, new[] { "abc", " def" } };
            yield return new object?[] { "Split without any special chars.", "a,b", null, new[] { "a", "b" } };
            yield return new object?[] { "With quoted separator.", "\"a,b\",c", null, new[] { "\"a,b\"", "c" } };
            yield return new object?[] { "With escaped escape character.", "\\\\", null, new[] { "\\\\" } };
            yield return new object?[] { "With escaped characters.", "\"\\\"\\", null, new[] { "\"\\\"\\" } };
            yield return new object?[] { "With trimming.", " a ", null, new[] { " a " } };
            yield return new object?[] { "No trimming with quotes.", " \"a\" ", true, new[] { " \"a\" " } };
        }
    }

    [Theory]
    [MemberData(nameof(ParseStringLineData))]
    public void StringLine(string becauseMessage, string inputString, bool? implicitStringOrBoth, string[] expectedOutput)
    {
        var implicitStrings = ImplicitStringVariants(implicitStringOrBoth);

        foreach (var implicitString in implicitStrings)
        {
            //  #   Arrange.
            var sut = new Parse(new ParseOptions { ImplicitString = implicitString });

            if (expectedOutput == null)
            {
                //  #   Act.
                Action aCall = () => sut.StringLine(inputString);

                //  #   Assert.
                aCall.Should().Throw<Exception>($"Whatever exception should be thrown [{becauseMessage}]");
            }
            else
            {
                Func<string, IEnumerable<string>> aCall = (s) => sut.StringLine(s);

                //  #   Act.
                var res = aCall(inputString);

                //  #   Assert.
                res.Should().BeEquivalentTo(expectedOutput, becauseMessage);
            }
        }
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void StringLine_NullArgument_ThrowNullArgumentException(bool implicitString)
    {
        //  #   Arrange.
        var sut = new Parse(new ParseOptions { ImplicitString = implicitString });

        //  #   Act.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Action callingWithNull = () => sut.StringLine(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        //  #   Assert.
        ; callingWithNull.Should().Throw<ArgumentNullException>("Null parameter is not supported.");
    }

    #endregion

    #region Line tests.

    public static IEnumerable<object?[]> ParseLineData
    {
        get
        {
            yield return new object[] { "No split.", "", false,
               new (Type?, object?)[] { (null, null) } };
            yield return new object[] { "No split.", "", true,
                new (Type, object)[] { (typeof(string), string.Empty )} };
            yield return new object[] { "Empty split.", ",", false,
                new (Type?, object?)[] { (null,null), (null,null )} };
            yield return new object[] { "Empty split.", ",", true,
                new (Type, object)[] { (typeof(string), string.Empty), (typeof(string), string.Empty) } };
            yield return new object?[] { "Without split, int value.", "1", null,
                new (Type, object)[] {(typeof(int), 1) } };
            yield return new object[] { "Empty quoted string.", "\"\"", false,
                new (Type, object)[] { (typeof(string),string.Empty) } };
            yield return new object[] { "Empty quoted string.", "\"\"", true,
                new (Type, object)[] {(typeof(string), "\"\"" )} };
            yield return new object[] { "String value..", "\"a\"", false,
                new (Type,object)[] {(typeof(string), "a") } };
            yield return new object[] { "String value..", "\"a\"", true,
                new (Type,object)[] { (typeof(string),"\"a\"") } };
            yield return new object[] { "Longer string value.", "\"abc\",\"def\"", false,
                new (Type, object)[] { (typeof(string),"abc"), (typeof(string),"def") } };
            yield return new object[] { "Longer string value.", "\"abc\",\"def\"", true,
                new (Type, object)[] { (typeof(string),"\"abc\""),(typeof(string), "\"def\"" )} };
            yield return new object?[] { "Double value", "1.0", null,
                new (Type, object)[] {  (typeof(double),(double)1.0 )} };
            yield return new object[] { "All variants of bool.", "False,false,FALSE,True,true,TRUE", false,
                new (Type, object)[] {(typeof(bool), false),(typeof(bool), false),(typeof(bool), false),(typeof(bool), true),(typeof(bool), true),(typeof(bool), true )} };
            yield return new object[] { "All variants of bool.", "False,false,FALSE,True,true,TRUE", true,
                new (Type,object)[] {(typeof(bool), false),(typeof(bool), false),(typeof(bool), false),(typeof(bool), true), (typeof(bool), true),(typeof(bool), true) } };
            yield return new object[] { "With quoted separator in string.", "\"a,b\",\"c\"", false,
                new (Type,object)[] { (typeof(string), "a,b"), (typeof(string), "c") } };
            yield return new object[] { "With quoted separator in string.", "\"a,b\",\"c\"", true,
                new (Type, object)[] {(typeof(string), "\"a,b\""),(typeof(string),"\"c\"" )} };
            yield return new object[] { "Different types.", "\"abc\", 1, 1.0, false", false,
                new (Type, object)[] { (typeof(string), "abc"), (typeof(int),1), (typeof(double),1.0),(typeof(bool), false )} };
            yield return new object[] { "Different types.", "\"abc\", 1, 1.0, false", true,
                new (Type, object)[] { (typeof(string), "\"abc\""),( typeof(int), 1), (typeof(double),1.0),(typeof(bool), false )} };
            yield return new object?[] { "Trimming value.", " 1 ", null,
                new (Type,object)[] {(typeof(int), 1 )} };
            yield return new object[] { "Only trim implicit string.", " \"a\" ", false,
                new (Type,object)[] { (typeof(string), "a") } };
            yield return new object[] { "Only trim implicit string.", " \"a\" ", true,
                new (Type,object)[] {(typeof(string), " \"a\" ") } };
            yield return new object[] { "Space inside string.", " \" a \" ", false,
                new (Type,object)[] {(typeof(string), " a ") } };
            yield return new object[] { "Space inside string.", " \" a \" ", true,
                new (Type,object)[] { (typeof(string)," \" a \" " )} };
        }
    }

    [Theory]
    [MemberData(nameof(ParseLineData))]
    public void LineSuccessful(string becauseMessage, string input, bool? implicitStringOrBoth, (Type? expType, object? expValue)[] expectedOutput)
    {
        foreach (var implicitString in ImplicitStringVariants(implicitStringOrBoth))
        {
            //  #   Arrange.
            var sut = new Parse(new ParseOptions { ImplicitString = implicitString });

            //  #   Act.
            var res = sut.Line(input).ToList();

            //  #   Assert.
            var expectedValues = expectedOutput.Select(eo => eo.expValue);
            res.Should().BeEquivalentTo(expectedValues, $"{becauseMessage}, [implicitStringOrBoth:{implicitStringOrBoth}].");
            AssertExactType(res, expectedOutput);
        }
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void Line_NullArgument_ThrowNullArgumentException(bool implicitString)
    {
        //  #   Arrange.
        var sut = new Parse(new ParseOptions { ImplicitString = implicitString });

        //  #   Act.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Action callingWithNull = () => sut.Line(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        //  #   Assert.
        callingWithNull.Should().Throw<ArgumentNullException>("Null parameter is not supported.");
    }

    #endregion

    private static void AssertExactType(List<object?> actualResult, (Type? expType, object? expValue)[] expectedOutput)
    {
        for (var i = 0; i < actualResult.Count; ++i)
        {
            if (actualResult[i] != null)
            {
                object actualRes = actualResult[i]!;
                var actualType = actualRes.GetType();

                var expectedType = expectedOutput[i].expType;

                actualType.Should().Be(expectedType,
                    $"The types should be exactly equal. Expected {expectedType}.");
            }
        }
    }

    private static bool[] ImplicitStringVariants(bool? implicitStringOrBoth)
    {
        return implicitStringOrBoth == null ?
            new[] { false, true } :
            new[] { implicitStringOrBoth.Value };
    }
}
