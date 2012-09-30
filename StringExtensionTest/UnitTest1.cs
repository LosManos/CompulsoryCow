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
			Assert.AreEqual("a{0}c{1}e[Failed formatting. Parameter(s) missing. Parameter(s) is/are:{System.String:'b'}.]", res);
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
            Assert.AreEqual("abc[Failed formatting. Too many parameters. Parameter(s) was/were:{System.String:'b',System.String:'d'}.]", res);
        }

        [TestMethod]
        public void TwoTooManyArguments()
        {
            var res = "a{0}c".SFormat("b", "d", "e");
            Assert.AreEqual("abc[Failed formatting. Too many parameters. Parameter(s) was/were:{System.String:'b',System.String:'d',System.String:'e'}.]", res);
        }

        [TestMethod]
        public void NullFormatNoParameter()
        {
            var res = ((string)null).SFormat();
            Assert.AreEqual(string.Empty, res, "SafeFormat should alwas return a string.");

			res = ((string)null).SFormat(null);
			Assert.AreEqual(string.Empty, res, "SafeFormat should alwas return a string.");
		}

		[TestMethod]
		public void NullFormatHasParameters()
		{
            var res = ((string)null).SFormat("a");
            Assert.AreEqual("[Failed formatting. Format string was empty. Parameter(s) was/were:{System.String:'a'}.]", res);
            
            res = ((string)null).SFormat("a", "b");
            Assert.AreEqual("[Failed formatting. Format string was empty. Parameter(s) was/were:{System.String:'a',System.String:'b'}.]", res);
        }

        /// <summary>This method just makes sure there is a static method.
        /// </summary>
        [TestMethod]
        public void StaticMethod()
        {
            var res = CompulsoryCow.StringExtension.StringExtension.SafeFormat("a{0}c", "b");
            Assert.AreEqual("abc", res);
        }

		private class MyClass
		{
			//public string MyProperty { get; set; }
			public override string ToString()
			{
				throw new Exception("Exception created for unit testing use.");
			}
		}

		[TestMethod]
		public void ForceOuterExcpetion()
		{
			var res = "a{0}c".SFormat(new MyClass());
			Assert.AreEqual("Exception created for unit testing use.", res);
		}

		[TestMethod]
		public void ForceOuterExcpetionStatic()
		{
			var res = CompulsoryCow.StringExtension.StringExtension.SafeFormat( "a{0}c", new MyClass());
			Assert.AreEqual("Exception created for unit testing use.", res);
		}

		[TestMethod]
		[ExpectedException( typeof( NullReferenceException))]
		public void ExceptionThrown()
		{
			Tuple<int> myObject = null;
			var res = "a{0}c".SFormat(myObject.Item1) ;
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void ExceptionThrownStatic()
		{
			Tuple<int> myObject = null;
			var res = CompulsoryCow.StringExtension.StringExtension.SafeFormat( "a{0}c", myObject.Item1);
		}

		[TestMethod]
		public void FormatStringParser()
		{
			//	How do we get inside to internal functions without making teh method public. Protected?  Special method attribute?  Reflection?  Obsolete flag?
			Assert.Fail("Create a thorough test for how the format string is parsed and understood.");
		}

		[TestMethod]
		public void FormatFormatstringAndParametersFail()
		{
			var res = "{82CE0089-A9F1-489F-81B9-8271D0EFE26E}".SFormat();
			Assert.AreEqual( "Failed formatting. Format string '{82CE0089-A9F1-489F-81B9-8271D0EFE26E}' and its parameter(s){} was not formattable." , res );
		}
    }
}
