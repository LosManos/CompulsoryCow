using FluentAssertions;
using System.Linq;
using Xunit;

namespace CompulsoryCow.AssemblyAbstractions.Unit.Tests
{
    public class AssemblyMethodsTests
    {
        [Fact]
        public void GetName_void_ShouldMimicSystem()
        {
            var expected = System.Reflection.Assembly.GetAssembly(typeof(int));

            var sut = new AssemblyFactory().GetAssembly(typeof(int));

            //  Act.
            var res = sut.GetName();

            //  Assert.
            res.Name.Should().Be(expected.GetName().Name);
        }

        [Fact]
        public void AllMethodsShouldBeMockable()
        {
            // These methods are out of our control.
            var objectMethods = new[]
            {
                    nameof(Assembly.Equals),
                    nameof(Assembly.GetHashCode),
                    nameof(Assembly.GetType),
                    nameof(Assembly.ToString)
            };

            // These methods are used for setting up tests.
            var testingMethods = new[]
            {
                nameof(Assembly.ClearAssembly),
                nameof(Assembly.GetAssembly),
                nameof(Assembly.SetAssembly)
            };

            var methods = typeof(Assembly)
                .GetMethods()
                .Where(m => m.IsConstructor == false)
                .Where(m =>
                    m.IsConstructor == false &&
                    m.Name.StartsWith("get_") == false &&
                    objectMethods.Contains(m.Name) == false &&
                    testingMethods.Contains(m.Name) == false
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

    }
}
