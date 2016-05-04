using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCow.StringExtensions;
using System;

namespace StringExtensionTest
{
    [TestClass]
    public class MidTest
    {
        [TestMethod]
        [ExpectedException(typeof( ArgumentNullException))]
        public void Mid_given_Null_should_ThrowException()
        {
            ((string)null).Mid(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mid_given_NegativeStartIndex_should_ThrowException()
        {
            "".Mid(-1, 0);
        }

        [TestMethod]
        public void Mid_given_ZeroStart_should_ReturnStringFromBeginning()
        {
            Assert.AreEqual("", "".Mid(0, 0));
            Assert.AreEqual("a", "a".Mid(0, 1));
            Assert.AreEqual("a", "ab".Mid(0, 1));
            Assert.AreEqual("a", "a".Mid(0, 2));
            Assert.AreEqual("ab", "ab".Mid(0, 3));
        }

        [TestMethod]
        public void Mid_given_StartInsideString_should_ReturnStringFromThere()
        {
            Assert.AreEqual("", "".Mid(1, 0));
            Assert.AreEqual("", "a".Mid(1, 1));
            Assert.AreEqual("b", "ab".Mid(1, 1));
            Assert.AreEqual("", "a".Mid(1, 2));
            Assert.AreEqual("bc", "abc".Mid(1, 2));
            Assert.AreEqual("bc", "abc".Mid(1, 3));
        }

        [TestMethod]
        public void Mid_given_StartAfterString_should_ReturnEmpty()
        {
            Assert.AreEqual("", "".Mid(1, 0));
            Assert.AreEqual("", "".Mid(1, 1));
            Assert.AreEqual("", "".Mid(2, 2));
            Assert.AreEqual("", "a".Mid(1, 0));
            Assert.AreEqual("", "a".Mid(1, 1));
            Assert.AreEqual("", "a".Mid(2, 2));
            Assert.AreEqual("", "abc".Mid(3, 42));
        }

        [TestMethod]
        public void Mid_given_NegativeLength_should_ReturnLeftOfStart()
        {
            Assert.AreEqual("", "".Mid(0, -1));
            Assert.AreEqual("", "".Mid(0, -2));
            Assert.AreEqual("", "".Mid(1, -1));
            Assert.AreEqual("", "".Mid(2, -2));
            Assert.AreEqual("a", "a".Mid(1, -1));
            Assert.AreEqual("b", "abc".Mid(2, -1));
            Assert.AreEqual("ab", "abc".Mid(2, -4));
            Assert.AreEqual("abc", "abc".Mid(3, -4));
        }
    }
}
