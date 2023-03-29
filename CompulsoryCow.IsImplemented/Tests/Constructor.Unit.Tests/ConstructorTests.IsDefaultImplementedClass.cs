using FluentAssertions;

namespace CompulsoryCow.Constructor.Unit.Tests;

/// <summary>There is no way to test for a false, as the compiler will fail for such a call.
/// Well... we could have a c# string and compile it and assert the compiler complains. But let's save that for a rainy day.
/// </summary>
public class ConstructorTestsIsDefaultImplementedClass
{
    [Fact]
    public void IsDefaultImplementedClass_Should_return_true_for_a_class_that_has_an_implicit_default_constructor()
    {
        var sut = new IsImplemented.Constructor();

        //  Act.
        var res = sut.IsDefaultImplemented<MyImplicitClass>();

        //  Assert.
        res.Should().BeTrue();
    }

    [Fact]
    public void IsDefaultImplementedClass_Should_return_true_for_a_class_that_has_an_explicit_default_constructor()
    {
        var sut = new IsImplemented.Constructor();

        //  Act.
        var res = sut.IsDefaultImplemented<MyExplicitClass>();

        //  Assert.
        res.Should().BeTrue();
    }
}
