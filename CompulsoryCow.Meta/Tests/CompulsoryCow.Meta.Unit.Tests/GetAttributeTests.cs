using CompulsoryCow;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace MetaTest;

public class GetAttributeTests
{
    [Fact]
    public void GetClassesWithAttribute_Should_return_classes_with_a_certain_attribute()
    {
        var res = Meta.GetClassesWithAttribute<MyAttribute>(AppDomain.CurrentDomain);

        res.Single().FullName.Should().Be(typeof(MyClass).FullName);
    }

    public class MyAttribute : Attribute
    {
    }

    [MyAttribute]
    public class MyClass
    {
    }
}
