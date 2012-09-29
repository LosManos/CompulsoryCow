using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCow.StringExtension;

namespace StringExtensionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NormalSucceed()
        {
            var res = "a{0}c".SFormat("b");
            Assert.AreEqual("abc", res);
        }

        [TestMethod]
        public void TooFewArgumentsNoArgument()
        {
            var res = "a{0}c".SFormat();
            Assert.AreEqual("a{0}c[Failed formatting. Parameter(s) missing.]", res);
		}

		[TestMethod]
		public void TooFewArguments()
		{
			var res = "a{0}c{1}e".SFormat("b");
			Assert.AreEqual("a{b}c{1}e[Failed formatting. Parameter(s) missing. Parameter(s) is/are:{System.String,'b'}.]", res);
		}

        [TestMethod]
        public void NoNothing()
        {
            var res = ((string)null).SFormat();
            Assert.AreEqual(string.Empty, res, "It should always returns a string, empty is so.");
        }

        [TestMethod]
        public void OneTooManyArguments()
        {
            var res = "a{0}c".SFormat("b", "d");
            Assert.AreEqual("abc[Failed formatting parameter(s) ['d'] was/were not used in format string.]", res);
        }

        [TestMethod]
        public void TwoTooManyArguments()
        {
            var res = "a{0}c".SFormat("b", "d", "e");
            Assert.AreEqual("abc[Failed formatting parameter(s) ['d','e'] was/were not used in format string.]", res);
        }

        [TestMethod]
        public void NullFormatVariousParameters()
        {
            var res = ((string)null).SFormat();
            Assert.AreEqual(string.Empty, res, "SafeFormat should alwas return a string.");

            res = ((string)null).SFormat("a");
            Assert.AreEqual("[Failed formatting. Format string was empty. Parameter(s) ['a'] was/were not used in format string.]", res);
            
            res = ((string)null).SFormat("a", "b");
            Assert.AreEqual("[Failed formatting. Format string was empty. Parameter(s) ['a','b'] was/were not used in format string.]", res);
        }

        /// <summary>This method just makes sure there is a static method.
        /// </summary>
        [TestMethod]
        public void StaticMethod()
        {
            var res = CompulsoryCow.StringExtension.StringExtension.SafeFormat("a{0}c", "b");
            Assert.AreEqual("abc", res);
        }

        /// <summary>This method, in debug compile, throws an exception.
        /// Which gets swallowed and a string is returned.
        /// </summary>
        [TestMethod]
        public void ForcedException()
        {
            //  Using this exact combination will throw an internal exception but it is caught and nicer output is outputed.
            var res = "a{0}c".SFormat( Guid.Parse( "{E981C86F-C8D5-46AC-84FB-1AB281A2390B}"));
            Assert.AreEqual("a{0}c,[Failed formatting. Parameter(s) is/are ['System.Guid:{E981C86F-C8D5-46AC-84FB-1AB281A2390B}']  Exception message is: Internal exception with message ", res);

            //  Using this exact combination will throw and exception when handling the exception and the code outputs the exception message.
            res = "a{0}c".SFormat( Guid.Parse("{4543AF85-D1A4-4EA3-81AF-EEE2FE7C766F}"));
            Assert.AreEqual("The error should be visible here", res);
        }

        /// <summary>This method, in debug compile, throws an exception.
        /// Which gets swallowed and a string is returned.
        /// </summary>
        [TestMethod]
        public void StaticForcedException()
        {
            //  Using this exact combination will throw an internal exception but it is caught and nicer output is outputed.
            var res = CompulsoryCow.StringExtension.StringExtension.SafeFormat("a{0}c",Guid.Parse("{E981C86F-C8D5-46AC-84FB-1AB281A2390B}"));
            Assert.AreEqual("a{0}c,[Failed formatting. Parameter(s) is/are ['System.Guid:{E981C86F-C8D5-46AC-84FB-1AB281A2390B}']  Exception message is: Internal exception with message ", res);

            //  Using this exact combination will throw and exception when handling the exception and the code outputs the exception message.
            res = CompulsoryCow.StringExtension.StringExtension.SafeFormat("a{0}c",Guid.Parse("{4543AF85-D1A4-4EA3-81AF-EEE2FE7C766F}"));
            Assert.AreEqual("The error should be visible here", res);
        }

		[TestMethod]
		public void FormatStringParser()
		{
			//	How do we get inside to internal functions without making teh method public. Protected?  Special method attribute?  Reflection?  Obsolete flag?
			Assert.Fail("Create a thorough test for how the format string is parsed and understood.");
		}

		[TestMethod]
		public void UnhandledFormatFormatstringAndParameters()
		{
			Assert.Fail("How do we make test for this?");
		}
    }
}
