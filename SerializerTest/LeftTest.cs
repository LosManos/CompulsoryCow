using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCow.StringExtensions;

namespace SerializerTest
{
	[TestClass]
	public class LeftTest
	{
		[TestMethod]
		[ExpectedException(typeof( ArgumentNullException))]
		public void Left_given_Null_should_ThrowException()
		{
			//	#	Act and Assert.
			var res = ((string)null).Left(0);
		}

		[TestMethod]
		public void Left_given_ZeroLength_should_ReturnEmptyString()
		{
			//	#	Act and Assert.
			Assert.AreEqual(string.Empty, "".Left(0));
			Assert.AreEqual(string.Empty, "a".Left(0));
		}

		[TestMethod]
		public void Left_given_ShorterOrEqualLength_should_ReturnProperString()
		{
			//	#	Act and Assert.
			Assert.AreEqual("a", "a".Left(1));
			Assert.AreEqual("a", "ab".Left(1));
			Assert.AreEqual("ab", "ab".Left(2));
		}

		[TestMethod]
		public void Left_given_LongerLength_should_ReturnFullString()
		{
			//	#	Act and Assert.
			Assert.AreEqual("a", "a".Left(2));
			Assert.AreEqual("ab", "ab".Left(4));
		}
	}
}
