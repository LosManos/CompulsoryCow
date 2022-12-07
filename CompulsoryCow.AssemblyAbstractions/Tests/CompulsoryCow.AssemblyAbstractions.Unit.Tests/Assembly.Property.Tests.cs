using FluentAssertions;
using System.Linq;
using Xunit;

namespace CompulsoryCow.AssemblyAbstractions.Unit.Tests;

public class AssemblyPropertyTests
{
    [Fact]
    public void AllPropertiesShouldBeMockable()
    {
        var properties = typeof(Assembly)
            .GetProperties();

        var res = properties
            .Select(p => p.GetMethod.IsVirtual);

        //  Act.
        res.Count().Should().Be(2, "Sanity check we know how many methods we have.");

        //  Assert.
        res.Should().AllBeEquivalentTo(
            true,
            $"all properties {string.Join(",", properties.Select(m => m.Name))} should be virtual"
        );
    }

    [Fact]
    public void FullName_ShouldMimicSystem()
    {
        var anyType = typeof(int);
        var expected = System.Reflection.Assembly.GetAssembly(anyType).FullName;

        var factory = new AssemblyFactory();

        var sut = factory.GetAssembly(anyType);

        //  Act.
        var res = sut.FullName;

        //  Assert.
        res.Should().Be(expected);
    }

    [Fact]
    public void Location_ShouldMimicSystem()
    {
        var anyType = typeof(int);
        var expected = System.Reflection.Assembly.GetAssembly(anyType).Location;

        var factory = new AssemblyFactory();

        var sut = factory.GetAssembly(anyType);

        //  Act.
        var res = sut.Location;

        //  Assert.
        res.Should().Be(expected);
    }
}
