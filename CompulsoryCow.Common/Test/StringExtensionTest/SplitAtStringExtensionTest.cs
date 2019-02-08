using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CompulsoryCow.StringExtensions;

namespace StringExtensionTest
{
	[TestClass]
    public class SplitAtStringExtensionsTest
    {
        [TestMethod]
        public void SplitAtIndexNormalSucceed()
        {
            var res = "".SplitAt("");
            Assert.AreEqual(new Tuple<string, string>("", ""), res);

            res = "abc".SplitAt("a");
            Assert.AreEqual(new Tuple<string, string>("", "bc"), res);

            res = "abc".SplitAt("ab");
            Assert.AreEqual(new Tuple<string, string>("", "c"), res);

            res = "abc".SplitAt("abc");
            Assert.AreEqual(new Tuple<string, string>("", ""), res);

            res = "abc".SplitAt("b");
            Assert.AreEqual(new Tuple<string, string>("a", "c"), res);

            res = "abc".SplitAt("bc");
            Assert.AreEqual(new Tuple<string, string>("a", ""), res);

            res = "abc".SplitAt("c");
            Assert.AreEqual(new Tuple<string, string>("ab", ""), res);

            res = "abcd".SplitAt("ab");
            Assert.AreEqual(new Tuple<string, string>("", "cd"), res);

            res = "abcd".SplitAt("bc");
            Assert.AreEqual(new Tuple<string, string>("a", "d"), res);
            
            res = "abcd".SplitAt("cd");
            Assert.AreEqual(new Tuple<string, string>("ab", ""), res);
        }

        [TestMethod, 
        ExpectedException( typeof (ArgumentOutOfRangeException))]
        public void WrongSplitString(){
            "abc".SplitAt( "d" );
        }

    }
}
