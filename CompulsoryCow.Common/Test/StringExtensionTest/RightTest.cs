using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCow.StringExtensions;

namespace StringExtensionTest
{
	[TestClass]
	public class RightTest
	{
		[TestMethod]
		[ExpectedException(typeof( ArgumentNullException))]
		public void Right_given_Null_should_ThrowException()
		{
			//	#	Act and Assert.
			var res = ((string)null).Right(0);
		}

		[TestMethod]
		public void Right_given_ZeroLength_should_ReturnEmptyString()
		{
			//	#	Act and Assert.
			Assert.AreEqual(string.Empty, "".Right(0));
			Assert.AreEqual(string.Empty, "a".Right(0));
		}

		[TestMethod]
		public void Right_given_ShorterOrEqualLength_should_ReturnProperString()
		{
			//	#	Act and Assert.
			Assert.AreEqual("a", "a".Right(1));
			Assert.AreEqual("b", "ab".Right(1));
			Assert.AreEqual("bc", "abc".Right(2));
			Assert.AreEqual("ab", "ab".Right(2));
		}

		[TestMethod]
		public void Right_given_LongerLength_should_ReturnFullString()
		{
			//	#	Act and Assert.
			Assert.AreEqual("a", "a".Right(2));
			Assert.AreEqual("ab", "ab".Right(4));
		}
	}
}
