using CompulsoryCow;
using FluentAssertions;
using Xunit;

namespace MetaTest;

public class GetDefaultConstructorTypeTests
{
    [Fact]
    public void GetDefaultConstructor_SHOULD_return_constructor_information_WHEN_there_is_a_default_constructor()
    {
        var res = Meta.GetDefaultConstructor(typeof(ClassWithImplicitDefaultConstructor))!;
        res.Name.Should().Be(".ctor");
        res.GetParameters().Should().BeEmpty();

        res = Meta.GetDefaultConstructor(typeof(ClassWithExplicitDefaultConstructor))!;
        res.Name.Should().Be(".ctor");
        res.GetParameters().Should().BeEmpty();

        res = Meta.GetDefaultConstructor(typeof(ClassWithExplicitDefaultConstructorAmongstOther))!;
        res.Name.Should().Be(".ctor");
        res.GetParameters().Should().BeEmpty();
    }

    [Fact]
    public void GetDefaultConstructor_SHOULD_return_null_WHEN_there_is_no_default_construtor()
    {
        var res = Meta.GetDefaultConstructor(typeof(ClassWithoutDefaultConstructor));

        res.Should().BeNull();
    }

    public class ClassWithImplicitDefaultConstructor
    { }

    public class ClassWithExplicitDefaultConstructor
    {
        public ClassWithExplicitDefaultConstructor()
        { }
    }

    public class ClassWithExplicitDefaultConstructorAmongstOther
    {
        public ClassWithExplicitDefaultConstructorAmongstOther()
        { }
        public ClassWithExplicitDefaultConstructorAmongstOther(int _)
        { }
    }

    public class ClassWithoutDefaultConstructor
    {
        public ClassWithoutDefaultConstructor(int _)
        {
        }
    }
}
