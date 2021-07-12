using FluentAssertions;
using Xunit;

namespace CompulsoryCow.AssemblyAbstractions.Unit.Tests
{
    public class AssemblyFactoryLoadFileTests
    {
        [Fact]
        public void LoadFile_String_ShouldMimicSystem()
        {
            var myAssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            var sut = new AssemblyFactory();

            //  Act.
            // This call is not a unit test. Should we keep it, and move it to "integration" or let it fail `sut.LoadFile("")`, verify the exception, and call it quits?
            // or we could load from a well know assembly, like string
            // or if there is a way to load an assembly from an in-memory binary.
            var res = sut.LoadFile(myAssemblyName + ".dll");

            //  Assert.
            res.FullName.Should().Contain(myAssemblyName);
        }

        [Fact]
        public void LoadFile_String_ShouldMimicSystemAndThrow()
        {
            var sut = new AssemblyFactory();

            //  Act.
            var res = Assert.Throws<System.ArgumentException>(() =>
            {
                sut.LoadFile("");
            });

            //  Assert.
            res.Should().BeOfType<System.ArgumentException>();
        }

        [Fact]
        public void LoadFile_String_ShouldReturnIAssembly()
        {
            var myFile = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            var sut = new AssemblyFactory();

            //  Act.
            // This call is not a unit test. Should we keep it, and move it to "integration" or let it fail `sut.LoadFile("")`, verify the exception, and call it quits?
            // or we could load from a well know assembly, like string
            // or if there is a way to load an assembly from an in-memory binary.
            var res = sut.LoadFile(myFile + ".dll");

            //  Assert.
            res.Should().BeAssignableTo<IAssembly>();
        }
    }
}
