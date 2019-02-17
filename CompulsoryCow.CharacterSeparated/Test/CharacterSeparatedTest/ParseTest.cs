using CompulsoryCow.CharacterSeparated;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WordParseResult = System.Tuple<bool, object>;

namespace CharacterSeparatedTest
{
    using WordParser = Func<string, bool, WordParseResult>;

    [TestClass]
    public class ParseTest
    {
        [TestMethod]
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

        [TestMethod]
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

        private static IEnumerable<object[]> CanSetOptionsData
        {
            get
            {
                yield return new object[] { false };
                yield return new object[] { true };
            }                                                      
        }

        [DataTestMethod]
        [DynamicData(nameof(CanSetOptionsData))]
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

        [TestMethod]
        public void CanUseDefaultWordParsers()
        {
            //  #   Arrange.
            var sut1 = new Parse(new ParseOptions{ImplicitString = true}, Parse.DefaultWordParserList);
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

        private static IEnumerable<object[]> ParseStringLineData
        {
            get
            {
                yield return new object[] { "No split.", "", null, new[] { "" } };
                yield return new object[] { "Empty split.", ",", null, new[] { "", "" } };
                yield return new object[] { "Without split.", "a", null, new[] { "a" } };
                yield return new object[] { "Long string.", "abc", null, new[] { "abc" } };
                yield return new object[] { "Splitting longer.", "abc, def", null, new[] { "abc", " def" } };
                yield return new object[] { "Split without any special chars.", "a,b", null, new[] { "a", "b" } };
                yield return new object[] { "With quoted separator.", "\"a,b\",c", null, new[] { "\"a,b\"", "c" } };
                yield return new object[] { "With escaped escape character.", "\\\\", null, new[] { "\\\\" } };
                yield return new object[] { "With escaped characters.", "\"\\\"\\", null, new[] { "\"\\\"\\" } };
                yield return new object[] { "With trimming.", " a ", null, new[] { " a " } };
                yield return new object[] { "No trimming with quotes.", " \"a\" ", true, new[] { " \"a\" " } };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(ParseStringLineData))]
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

        [TestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void StringLine_NullArgument_ThrowNullArgumentException(bool implicitString)
        {
            //  #   Arrange.
            var sut = new Parse(new ParseOptions { ImplicitString = implicitString });

            //  #   Act.
            Action callingWithNull = () => sut.StringLine(null);

            //  #   Assert.
            ; callingWithNull.Should().Throw<ArgumentNullException>("Null parameter is not supported.");
        }

        #endregion

        #region Line tests.

        private static IEnumerable<object[]> ParseLineData
        {
            get
            {
                yield return new object[] { "No split.", "", false, new object[] { null } };
                yield return new object[] { "No split.", "", true, new object[] { string.Empty } };
                yield return new object[] { "Empty split.", ",", false, new object[] { null, null } };
                yield return new object[] { "Empty split.", ",", true, new object[] { string.Empty, string.Empty } };
                yield return new object[] { "Without split, int value.", "1", null, new object[] { 1 } };
                yield return new object[] { "Empty quoted string.", "\"\"", false, new object[] { string.Empty } };
                yield return new object[] { "Empty quoted string.", "\"\"", true, new object[] { "\"\"" } };
                yield return new object[] { "String value..", "\"a\"", false, new object[] { "a" } };
                yield return new object[] { "String value..", "\"a\"", true, new object[] { "\"a\"" } };
                yield return new object[] { "Longer string value.", "\"abc\",\"def\"", false, new object[] { "abc", "def" } };
                yield return new object[] { "Longer string value.", "\"abc\",\"def\"", true, new object[] { "\"abc\"", "\"def\"" } };
                yield return new object[] { "Double value", "1.0", null, new object[] { 1.0 } };
                yield return new object[] { "All variants of bool.", "False,false,FALSE,True,true,TRUE", false, new object[] { false, false, false, true, true, true } };
                yield return new object[] { "All variants of bool.", "False,false,FALSE,True,true,TRUE", true, new object[] { "False", "false", "FALSE", "True", "true", "TRUE" } };
                yield return new object[] { "With quoted separator in string.", "\"a,b\",\"c\"", false, new object[] { "a,b", "c" } };
                yield return new object[] { "With quoted separator in string.", "\"a,b\",\"c\"", true, new object[] { "\"a,b\"","\"c\"" } };
                yield return new object[] { "Different types.", "\"abc\", 1, 1.0, false", false, new object[] { "abc", (int)1, (double)1.0, false } };
                yield return new object[] { "Different types.", "\"abc\", 1, 1.0,false", true, new object[] { "\"abc\"", (int)1, (double)1.0, "false" } };
                yield return new object[] { "Trimming value.", " 1 ", null, new object[] { 1 } };
                yield return new object[] { "Only trim implicit string.", " \"a\" ", false, new object[] { "a" } };
                yield return new object[] { "Only trim implicit string.", " \"a\" ", true, new object[] { " \"a\" " } };
                yield return new object[] { "Space inside string.", " \" a \" ", false, new object[] { " a " } };
                yield return new object[] { "Space inside string.", " \" a \" ", true, new object[] { " \" a \" " } };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(ParseLineData))]
        public void LineSuccessful(string becauseMessage, string input, bool? implicitStringOrBoth, object[] expectedOutput)
        {
            foreach (var implicitString in ImplicitStringVariants(implicitStringOrBoth))
            {
                //  #   Arrange.
                var sut = new Parse(new ParseOptions { ImplicitString = implicitString });

                //  #   Act.
                var res = sut.Line(input).ToList();

                //  #   Assert.
                res.Should().BeEquivalentTo(expectedOutput, $"{becauseMessage}, [implicitStringOrBoth:{implicitStringOrBoth}].");
                AssertExactType(res, expectedOutput);
            }
        }

        [TestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void Line_NullArgument_ThrowNullArgumentException(bool implicitString)
        {
            //  #   Arrange.
            var sut = new Parse(new ParseOptions { ImplicitString = implicitString });

            //  #   Act.
            Action callingWithNull = () => sut.Line(null);

            //  #   Assert.
            callingWithNull.Should().Throw<ArgumentNullException>("Null parameter is not supported.");
        }

        #endregion

        private static void AssertExactType(List<object> res, object[] expectedOutput)
        {
            for (var i = 0; i < res.Count; ++i)
            {
                if (res[i] != null)
                {
                    res[i].GetType().Should().Be(expectedOutput[i].GetType(),
                        $"The types should be exactly equal. Expected {expectedOutput[i].GetType()}.");
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
}
