using FluentAssertions;
using Xunit;

namespace CompulsoryCow.AssemblyAbstractions.Unit.Tests
{
    public class AssemblyFullNameTests
    {
        [Fact]
        public void FullName_ShouldMimicSystem()
        {
            var expected = System.Reflection.Assembly.GetAssembly(typeof(int)).FullName;

            var factory = new AssemblyFactory();

            var sut = factory.GetAssembly(typeof(int));

            //  Act.
            var res = sut.FullName;

            //  Assert.
            res.Should().Be(expected);
        }

        [Fact]
        public void FullName_ShouldReturnMock()
        {
            var expected = "MyFullName";

            var factory = new AssemblyFactory();

            var sut = factory.GetAssembly(typeof(int));
            sut.FullName.Should().NotBe(expected, "Sanity check we know we don't start with the expected value.");

            //  Act.
            sut.SetFullName(expected);

            //  Assert.
            sut.FullName.Should().Be(expected);
        }

        [Fact]
        public void FullName_ShouldClearMock()
        {
            var OtherFullName = "MyFullName";

            var factory = new AssemblyFactory();

            var sut = factory.GetAssembly(typeof(int));
            var expected = sut.FullName;

            sut.SetFullName(OtherFullName);
            sut.FullName.Should().Be(OtherFullName, "Sanity check we know we overwrite the FullName.");

            //  Act.
            sut.ClearFullName();

            //  Assert.
            var res = sut.FullName;
            res.Should().Be(expected);
        }
    }
}
