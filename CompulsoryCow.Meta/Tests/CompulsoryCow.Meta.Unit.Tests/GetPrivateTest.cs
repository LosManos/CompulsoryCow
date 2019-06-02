using CompulsoryCow;
using FluentAssertions;
using Xunit;

namespace MetaTest
{
    public class GetPrivateTest
    {
        [Fact]
        public void GetPrivateField_ReturnFieldData()
        {
            var sut = new MyClass();
            var res = Meta.GetPrivateField<MyClass>(sut, "_myField");
            res.Name.Should().Be("_myField");
        }

        [Fact]
        public void GetPrivateMethod_ReturnData()
        {
            var sut = new MyClass();
            var res = Meta.GetPrivateMethod<MyClass>(sut, "MyGetMethod");
            res.Name.Should().Be("MyGetMethod");
            res = Meta.GetPrivateMethod<MyClass>(sut, "MySetMethod");
            res.Name.Should().Be("MySetMethod");
        }

        [Fact]
        public void GetPrivateProperty_ReturnPropertyData()
        {
            var sut = new MyClass();
            var res = Meta.GetPrivateProperty<MyClass>(sut, "MyProperty");
            res.Name.Should().Be("MyProperty");
        }

        [Fact]
        public void GetPrivateStaticField_ReturnFieldData()
        {
            var res = Meta.GetPrivateStaticField(typeof(MyStaticClass), "_myField");
            res.Name.Should().Be("_myField");
        }

        [Fact]
        public void GetPrivateStaticMethod_ReturnData()
        {
            var res = Meta.GetPrivateStaticMethod(typeof(MyStaticClass), "MyGetMethod");
            res.Name.Should().Be("MyGetMethod");
            res = Meta.GetPrivateStaticMethod(typeof(MyStaticClass), "MySetMethod");
            res.Name.Should().Be("MySetMethod");
        }

        [Fact]
        public void GetPrivateStaticProperty_ReturnPropertyData()
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
}
