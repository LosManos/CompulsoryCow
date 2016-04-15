using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CompulsoryCow.StringExtension;

namespace StringExtensionTest
{
	[TestClass]
    public class SplitAtIndexExtensionsTest
    {
        [TestMethod]
        public void SplitAtIndexNormalSucceed()
        {
            var res = "".SplitAt(0);
            Assert.AreEqual(new Tuple<string, string>("", ""), res);

            res = "abc".SplitAt(0);
            Assert.AreEqual(new Tuple<string, string>("", "abc"), res);

            res = "abc".SplitAt(1);
            Assert.AreEqual(new Tuple<string, string>("a", "bc"), res);

            res = "abc".SplitAt(2);
            Assert.AreEqual(new Tuple<string, string>("ab", "c"), res);

            res = "abc".SplitAt(3);
            Assert.AreEqual(new Tuple<string, string>("abc", ""), res);
        }

        [TestMethod, 
        ExpectedException( typeof (ArgumentOutOfRangeException))]
        public void IndexTooSmall(){
            "abc".SplitAt( -1 );
        }

        [TestMethod, 
        ExpectedException( typeof (ArgumentOutOfRangeException))]
        public void IndexTooBig(){
            "abc".SplitAt( 4 );
        }
    }
}
