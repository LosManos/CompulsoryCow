using CompulsoryCow;
using FluentAssertions;
using Xunit;

namespace MetaTest;

public class GetDefaultConstructorGenericTests
{
    [Fact]
    public void GetDefaultConstructor_SHOULD_return_constructor_information_WHEN_there_is_a_default_constructor()
    {
        var res = Meta.GetDefaultConstructor<ClassWithImplicitDefaultConstructor>()!;
        res.Name.Should().Be(".ctor");
        res.GetParameters().Should().BeEmpty();

        res = Meta.GetDefaultConstructor<ClassWithExplicitDefaultConstructor>()!;
        res.Name.Should().Be(".ctor");
        res.GetParameters().Should().BeEmpty();

        res = Meta.GetDefaultConstructor<ClassWithExplicitDefaultConstructorAmongstOther>()!;
        res.Name.Should().Be(".ctor");
        res.GetParameters().Should().BeEmpty();
    }

    [Fact]
    public void GetDefaultConstructor_SHOULD_return_null_WHEN_there_is_no_default_construtor()
    {
        var res = Meta.GetDefaultConstructor<ClassWithoutDefaultConstructor>();

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
