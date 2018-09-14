using CompulsoryCow.AreEqual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreEqualTest
{
    [TestClass]
    public partial class PublicTest : TestBase
    {
        [TestMethod]
        public void Public_FullCopy_ReturnTrue()
        {
            //	#	Arrange.
            var source = Dto.CreateRandomised(_pr);
            var destination = source.FullCopy();

            //	#	Act.
            var res = AreEqual.Public(source, destination);

            //	# Assert.
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Public_FullCopyWithDifferingNonPublic_ReturnTrue()
        {
            //	#	Arrange.
            var source = Dto.CreateRandomised(_pr);
            var destination = source.FullCopy()
                .WithRandomisedNonPublic(_pr);

            //	#	Act.
            var res = AreEqual.Public(source, destination);

            //	# Assert.
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Public_NotFullCopyOfPublic_ReturnFalse()
        {
            //	#	Arrange.
            var source = Dto.CreateRandomised(_pr);

            var destination = source.FullCopy()
                .With(d => d.MyPublicInt = _pr.Int());

            Assert.AreNotEqual(source.MyPublicInt, destination.MyPublicInt, "Sobriety check that what should be randomised to differ really does differ.");

            //	#	Act.
            var res = AreEqual.Public(source, destination);

            //	# Assert.
            Assert.IsFalse(res);
        }

    }
}
