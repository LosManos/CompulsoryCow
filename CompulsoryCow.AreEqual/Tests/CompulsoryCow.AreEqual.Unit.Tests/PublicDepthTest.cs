using System.Collections.Generic;
using CompulsoryCow.AreEqual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreEqualTest
{
    [TestClass]
    public partial class PublicDepthTest : TestBase
    {
        [TestMethod]
        public void PublicDepth_NoDepth_OnlyCompareImmediateObject()
        {
            //  #   Arrange.
            var equal = Dto.CreatePair(
                _pr, 
                new[] { Dto.Pair.Equal, Dto.Pair.Differs });
            var notEqual = Dto.CreatePair(
                _pr, 
                new[] { Dto.Pair.Differs, Dto.Pair.Equal });
            
            //  #   Act.
            var res1 = AreEqual.Public(AreEqual.Depth.None, equal.Item1, equal.Item2);
            var res2 = AreEqual.Public(AreEqual.Depth.None, notEqual.Item1, notEqual.Item2);

            //  #   Assert.
            Assert.IsTrue(res1);
            Assert.IsFalse(res2);
        }

        [TestMethod]
        public void PublicDepth_SetDepth_OnlyCompareToThatDepth()
        {
            //  #   Arrange.
            var equal = Dto.CreatePair(
                _pr,
                new[] { Dto.Pair.Equal, Dto.Pair.Equal, Dto.Pair.Differs });
            var notEqual = Dto.CreatePair(
                _pr,
                new[] { Dto.Pair.Equal, Dto.Pair.Differs, Dto.Pair.Equal });

            //  #   Act.
            var res1 = AreEqual.Public((AreEqual.Depth) 2, equal.Item1, equal.Item2);
            var res2 = AreEqual.Public((AreEqual.Depth) 2, notEqual.Item1, notEqual.Item2);

            //  #   Assert.
            Assert.IsTrue(res1);
            Assert.IsFalse(res2);
        }

        [TestMethod]
        public void PublicDepth_InfiniteDepth_StopForNothing()
        {
            //  #   Arrange.
            var equal = Dto.CreatePair(
                _pr,
                CreateInfiniteEqualsList(Dto.Pair.Equal));
            var notEqual = Dto.CreatePair(
                _pr,
                CreateInfiniteEqualsList(Dto.Pair.Differs));

            //  #   Act.
            var res1 = AreEqual.Public(AreEqual.Depth.Infinite, equal.Item1, equal.Item2);
            var res2 = AreEqual.Public(AreEqual.Depth.Infinite, notEqual.Item1, notEqual.Item2);

            //  #   Assert.
            Assert.IsTrue(res1);
            Assert.IsFalse(res2);
        }

        private static IEnumerable<Dto.Pair> CreateInfiniteEqualsList(Dto.Pair equal)
        {
            var res = new List<Dto.Pair>();
            for(int i = 0; i <= 30; ++i)    //  Thirty is close to infinity.
            {
                res.Add(Dto.Pair.Equal);
            }
            res.Add(equal);
            return res;
        }
    }
}
