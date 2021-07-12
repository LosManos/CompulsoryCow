using FluentAssertions;
using Xunit;

namespace CompulsoryCow.AssemblyAbstractions.Unit.Tests
{
    public class AssemblyFactoryGetAssemblyTests
    {
        [Fact]
        public void GetAssembly_String_ShouldMimicSystem()
        {
            var expected = System.Reflection.Assembly.GetAssembly(typeof(int));

            var sut = new AssemblyFactory();

            //  Act.
            var res = sut.GetAssembly(typeof(int));

            //  Assert.
            res.FullName.Should().Be(expected.FullName);
        }

        [Fact]
        public void GetAssembly_String_ShouldMimicSystemAndThrow()
        {
            var sut = new AssemblyFactory();

            //  Act.
            var res = Assert.Throws<System.ArgumentNullException>(() =>
            {
                sut.GetAssembly(null);
            });

            //  Assert.
            res.Should().BeOfType<System.ArgumentNullException>();
        }

        [Fact]
        public void GetFile_String_ShouldReturnIAssembly()
        {
            var myFile = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            var sut = new AssemblyFactory();

            //  Act.
            var res = sut.GetAssembly(typeof(int));

            //  Assert.
            res.Should().BeAssignableTo<IAssembly>();
        }
    }
}
