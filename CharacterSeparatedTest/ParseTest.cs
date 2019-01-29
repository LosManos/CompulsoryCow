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
        public static IEnumerable<object[]> ParseStringLineData
        {
            get
            {
                yield return new object[] { "No split.", "", new[] { "" } };
                yield return new object[] { "Empty split.", ",", new[] { "", "" } };
                yield return new object[] { "Without split.", "a", new[] { "a" } };
                yield return new object[] { "Long value.", "abc", new[] { "abc" } };
                yield return new object[] { "Splitting longer.", "abc, def", new[] { "abc", " def" } };
                yield return new object[] { "Split without any special chars.", "a,b", new[] { "a", "b" } };
                yield return new object[] { "With quoted separator.", "\"a,b\",c", new[] { "\"a,b\"", "c" } };
                yield return new object[] { "No trimming.", " a ", new[] { " a " } };
                yield return new object[] { "No trimming with quotes.", " \"a\" ", new[] { " \"a\" " } };
            }
        }

        #region StringLine tests.

        [DataTestMethod]
        [DynamicData(nameof(ParseStringLineData))]
        public void StringLineSuccessful(string becauseMessage, string input, string[] expectedOutput)
        {
            var res = Parse.StringLine(input).ToList();

            //  #   Assert.
            res.Should().BeEquivalentTo(expectedOutput, becauseMessage);
        }

        [TestMethod]
        public void StringLine_NullArgument_ThrowNullArgumentException()
        {
            Action callingWithNull = () => Parse.StringLine(null);

            callingWithNull.Should().Throw<ArgumentNullException>("Null parameter is not supported.");
        }

        #endregion

        #region Line tests.

        public static IEnumerable<object[]> ParseLineData
        {
            get
            {
                yield return new object[] { "No split.", "", new object[] { null } };
                yield return new object[] { "Empty split.", ",", new object[] { null, null } };
                yield return new object[] { "Without split, int value.", "1", new object[] { 1 } };
                yield return new object[] { "Empty string.", "\"\"", new object[] { string.Empty } };
                yield return new object[] { "String value..", "\"a\"", new object[] { "a" } };
                yield return new object[] { "Longer string value.", "\"abc\", \"def\"", new object[] { "abc", "def" } };
                yield return new object[] { "Double value", "1.0", new object[] { 1.0 } };
                yield return new object[] { "All variants of bool.", "False, false, FALSE, True, true, TRUE", new object[] { false, false, false, true, true, true } };
                yield return new object[] { "With quoted separator in string.", "\"a,b\",\"c\"", new object[] { "a,b", "c" } };
                yield return new object[] { "Different types.", "\"abc\", 1, 1.0, false", new object[] { "abc", (int)1, (double)1.0, false } };
                yield return new object[] { "Trimming value.", " 1 ", new object[] { 1 } };
                yield return new object[] { "Trimming string.", " \"a\" ", new object[] { "a" } };
                yield return new object[] { "Space inside string.", " \" a \" ", new object[] { " a " } };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(ParseLineData))]
        public void LineSuccessful(string becauseMessage, string input, object[] expectedOutput)
        {
            var res = Parse.Line(input).ToList();

            //  #   Assert.
            res.Should().BeEquivalentTo(expectedOutput, becauseMessage);
            AssertExactType(res, expectedOutput);
        }

        [TestMethod]
        public void Line_NullArgument_ThrowNullArgumentException()
        {
            Action callingWithNull = () => Parse.Line(null);

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

    }
}
