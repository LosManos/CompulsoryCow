using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace CompulsoryCow.AssemblyAbstractions.Unit.Tests
{
    /// <summary>This class contains tests of the (static) constructors
    /// in <see cref="System.Reflection.Assembly"/>
    /// which in AssemblyAbstractions is moved 
    /// from Assembly to AssemblyFactory
    /// as static constructors are impossible(?) to mock.
    /// </summary>
    public class AssemblyFactoryTests
    {
        [Fact]
        public void AllMethodsShouldBeMockable()
        {
            // These methods are out of our control.
            var objectMethods = new[]
            {
                    nameof(AssemblyFactory.Equals),
                    nameof(AssemblyFactory.GetHashCode),
                    nameof(AssemblyFactory.GetType),
                    nameof(AssemblyFactory.ToString),
            };

            var methods = typeof(AssemblyFactory)
                .GetMethods()
                .Where(m => m.IsConstructor == false)
                .Where(m => objectMethods.Contains(m.Name) == false
                );

            var res = methods
                .Select(m => m.IsVirtual);

            //  Act.
            res.Count().Should().Be(3, "Sanity check we know how many methods we have.");

            res.Should().AllBeEquivalentTo(
                true,
                $"all methods {string.Join(",", methods.Select(m => m.Name))} should be virtual"
            );
        }

        [Fact]
        public void GetAssembly_Type_ShouldMimicSystem()
        {
            var anyType = typeof(int);
            var sut = new AssemblyFactory();

            //  Act.
            var res = sut.GetAssembly(anyType);

            //  Assert.
            res.GetName().Name.Should().Be(
                System.Reflection.Assembly.GetAssembly(anyType).GetName().Name);
        }

        [Fact]
        public void GetExecutingAssembly_Void_ShouldMimicSystem()
        {
            var sut = new AssemblyFactory();

            //  Act.
            var res = sut.GetExecutingAssembly();

            //  Assert.
            res.FullName.Should().Be("CompulsoryCow.AssemblyAbstractions, Version=0.4.0.0, Culture=neutral, PublicKeyToken=null");
        }

        [Fact]
        public void LoadFile_String_ShouldMimicSystem()
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            var sut = new AssemblyFactory();

            //  Act.
            var res = sut.LoadFile(ass.Location);

            //  Assert.
            res.FullName.Should().Be(ass.FullName);
        }
    }
}
