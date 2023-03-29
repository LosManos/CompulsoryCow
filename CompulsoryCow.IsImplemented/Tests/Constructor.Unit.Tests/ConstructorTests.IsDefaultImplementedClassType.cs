using FluentAssertions;

namespace CompulsoryCow.Constructor.Unit.Tests;

public class ConstructorTestsIsDefaultImplementedClassType
{
    [Theory]
    [InlineData(typeof(MyImplicitClass), true)]
    [InlineData(typeof(MyExplicitClass), true)]
    [InlineData(typeof(MyNoDefaultClass), false)]
    public void IsDefaultImplementedClassType_Should_return_whether_a_class_has_an_implicit_default_constructor(Type type, bool expected)
    {
        var sut = new IsImplemented.Constructor();

        //  Act.
        var res = sut.IsDefaultImplemented(type);

        //  Assert.
        res.Should().Be(expected);
    }
}
