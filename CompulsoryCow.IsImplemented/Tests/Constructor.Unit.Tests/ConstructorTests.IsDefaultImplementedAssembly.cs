using FluentAssertions;

namespace CompulsoryCow.Constructor.Unit.Tests;

public class ConstructorTestsIsDefaultImplementedAssembly
{
    [Fact]
    public void IsDefaultImplementedClass_Should_return_true_for_a_class_that_has_an_implicit_default_constructor()
    {
        var sut = new IsImplemented.Constructor();
        var appDomain = AppDomain.CurrentDomain;

        //  Act.
        var res = sut.IsDefaultImplemented<ImplicitDefaultConstructorAttribute>(appDomain);

        //  Assert.
        res.Should().BeTrue();
    }

    [Fact]
    public void IsDefaultImplementedClass_Should_return_true_for_a_class_that_has_an_explicit_default_constructor()
    {
        var sut = new IsImplemented.Constructor();
        var appDomain = AppDomain.CurrentDomain;

        //  Act.
        var res = sut.IsDefaultImplemented<ExplicitDefaultConstructorAttribute>(appDomain);

        //  Assert.
        res.Should().BeTrue();
    }

    [Fact]
    public void IsDefaultImplementedClass_Should_return_false_for_a_class_that_has_no_default_constructor()
    {
        var sut = new IsImplemented.Constructor();
        var appDomain = AppDomain.CurrentDomain;

        //  Act.
        var res = sut.IsDefaultImplemented<NoDefaultConstructorAttribute>(appDomain);

        //  Assert.
        res.Should().BeFalse();
    }
    
    [Fact]
    public void IsDefaultImplementedClass_Should_return_false_for_a_attribute_that_has_no_implementation()
    {
        var sut = new IsImplemented.Constructor();
        var appDomain = AppDomain.CurrentDomain;

        //  Act.
        var res = sut.IsDefaultImplemented<AttributeNoOneHasImplemented>(appDomain);

        //  Assert.
        res.Should().BeFalse();
    }
}
