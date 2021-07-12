using FluentAssertions;
using Xunit;

namespace CompulsoryCow.AssemblyAbstractions.Unit.Tests
{
    public partial class AssemblyConstructorTests
    {
        [Fact]
        public void GetAssembly_Type_ShouldMimicSystem()
        {
            var sut = new AssemblyFactory();

            //  Act.
            var res = sut.GetAssembly(typeof(int));

            //  Assert.
            res.GetAssembly().GetName().Name.Should().Be("System.Private.CoreLib");
        }

        [Fact]
        public void GetAssembly_Type_ShouldReturnMock()
        {
            var sut = new AssemblyFactory();

            //  Act.
            var res = sut.GetAssembly(typeof(int));

            //  Assert.
            res.Should().BeOfType<AssemblyAbstractions.Assembly>();
        }
    }
}
