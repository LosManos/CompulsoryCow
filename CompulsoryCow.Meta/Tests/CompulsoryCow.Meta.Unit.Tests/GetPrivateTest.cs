using CompulsoryCow;
using FluentAssertions;
using System;
using Xunit;

namespace MetaTest;

public class GetPrivateTest
{
    #region GetPrivateField tests.

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    [Fact]
    public void GetPrivateField_Should_throw_When_null_parameter()
    {
        {
            var res = Record.Exception(() =>
                Meta.GetPrivateField<object>(null, "")
            );

            res.Should().BeOfType<ArgumentNullException>();
            ((ArgumentNullException)res).ParamName.Should().Be("theObject");
        }
        {
            var res = Record.Exception(() =>
                Meta.GetPrivateField<object>(new object(), null)
            );

            res.Should().BeOfType<ArgumentNullException>();
            ((ArgumentNullException)res).ParamName.Should().Be("name");
        }
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void GetPrivateField_Should_return_field_data()
    {
        var sut = new MyClass();
        var res = Meta.GetPrivateField<MyClass>(sut, "_myField");
        res.Name.Should().Be("_myField");
    }

    #endregion

    #region GetPrivateMethod tests.

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    [Fact]
    public void GetPrivateMethod_Should_throw_When_null_parameter()
    {
        {
            var res = Record.Exception(() =>
                Meta.GetPrivateMethod<object>(null, "")
            );

            res.Should().BeOfType<ArgumentNullException>();
            ((ArgumentNullException)res).ParamName.Should().Be("theObject");
        }
        {
            var res = Record.Exception(() =>
                Meta.GetPrivateMethod<object>(new object(), null)
            );

            res.Should().BeOfType<ArgumentNullException>();
            ((ArgumentNullException)res).ParamName.Should().Be("name");
        }
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void GetPrivateMethod_Should_return_data()
    {
        var sut = new MyClass();
        var res = Meta.GetPrivateMethod<MyClass>(sut, "MyGetMethod");
        res.Name.Should().Be("MyGetMethod");
        res = Meta.GetPrivateMethod<MyClass>(sut, "MySetMethod");
        res.Name.Should().Be("MySetMethod");
    }

    #endregion

    #region GetPrivateProperty tests.

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    [Fact]
    public void GetPrivateProperty_Should_throw_When_null_parameter()
    {
        {
            var res = Record.Exception(() =>
                Meta.GetPrivateProperty<object>(null, "")
            );

            res.Should().BeOfType<ArgumentNullException>();
            ((ArgumentNullException)res).ParamName.Should().Be("theObject");
        }
        {
            var res = Record.Exception(() =>
                Meta.GetPrivateProperty<object>(new object(), null)
            );

            res.Should().BeOfType<ArgumentNullException>();
            ((ArgumentNullException)res).ParamName.Should().Be("name");
        }
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void GetPrivateProperty_Should_return_property_data()
    {
        var sut = new MyClass();
        var res = Meta.GetPrivateProperty<MyClass>(sut, "MyProperty");
        res.Name.Should().Be("MyProperty");
    }

    #endregion

    [Fact]
    public void GetPrivateStaticField_Should_return_field_data()
    {
        var res = Meta.GetPrivateStaticField(typeof(MyStaticClass), "_myField");
        res.Name.Should().Be("_myField");
    }

    [Fact]
    public void GetPrivateStaticMethod_Should_return_data()
    {
        var res = Meta.GetPrivateStaticMethod(typeof(MyStaticClass), "MyGetMethod");
        res.Name.Should().Be("MyGetMethod");
        res = Meta.GetPrivateStaticMethod(typeof(MyStaticClass), "MySetMethod");
        res.Name.Should().Be("MySetMethod");
    }

    [Fact]
    public void GetPrivateStaticProperty_Should_return_property_data()
    {
        var res = Meta.GetPrivateStaticProperty(typeof(MyStaticClass), "MyProperty");
        res.Name.Should().Be("MyProperty");
    }

    private class MyClass
    {
        private int _myMethodField;
        private int _myField;
        private int MyProperty { get; set; }
        private int MyGetMethod()
        {
            return _myMethodField;
        }
        private void MySetMethod(int value)
        {
            _myMethodField = value;
        }
    }

    private static class MyStaticClass
    {
        private static int _myMethodField;
        private static int _myField;
        private static int MyProperty { get; set; }
        private static int MyGetMethod()
        {
            return _myMethodField;
        }
        private static void MySetMethod(int value)
        {
            _myMethodField = value;
        }
    }

}
