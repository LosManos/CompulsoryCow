using CompulsoryCow.CharacterSeparated;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterSeparatedTest
{
    [TestClass]
    public class ParseTest
    {
        #region StringLine tests.

        public static IEnumerable<object[]> ParseStringLineData
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
                var sut = new Parse(implicitString);

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
            var sut = new Parse(implicitString);

            //  #   Act.
            Action callingWithNull = () => sut.StringLine(null);

            //  #   Assert.
            ; callingWithNull.Should().Throw<ArgumentNullException>("Null parameter is not supported.");
        }

        #endregion

        #region Line tests.

        public static IEnumerable<object[]> ParseLineData
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
                yield return new object[] { "Trimming string.", " \"a\" ", false, new object[] { "a" } };
                yield return new object[] { "Trimming string.", " \"a\" ", true, new object[] { " \"a\" " } };
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
                var sut = new Parse(implicitString);

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
            var sut = new Parse(implicitString);

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
