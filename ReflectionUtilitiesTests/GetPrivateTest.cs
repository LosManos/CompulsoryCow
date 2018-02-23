using CompulsoryCow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionUtilitiesTests
{
    [TestClass]
    public class GetPrivateTest
    {
        [TestMethod]
        public void GetPrivateField_ReturnFieldData()
        {
            var sut = new MyClass();
            var res = Meta.GetPrivateField<MyClass>(sut, "_myField");
            Assert.AreEqual("_myField", res.Name);
        }

        [TestMethod]
        public void GetPrivateMethod_ReturnData()
        {
            var sut = new MyClass();
            var res = Meta.GetPrivateMethod<MyClass>(sut, "MyGetMethod");
            Assert.AreEqual("MyGetMethod", res.Name);
            res = Meta.GetPrivateMethod<MyClass>(sut, "MySetMethod");
            Assert.AreEqual("MySetMethod", res.Name);
        }

        [TestMethod]
        public void GetPrivateProperty_ReturnPropertyData()
        {
            var sut = new MyClass();
            var res = Meta.GetPrivateProperty<MyClass>(sut, "MyProperty");
            Assert.AreEqual("MyProperty", res.Name);
        }

        [TestMethod]
        public void GetPrivateStaticField_ReturnFieldData()
        {
            var res = Meta.GetPrivateStaticField(typeof(MyStaticClass), "_myField");
            Assert.AreEqual("_myField", res.Name);
        }

        [TestMethod]
        public void GetPrivateStaticMethod_ReturnData()
        {
            var res = Meta.GetPrivateStaticMethod(typeof(MyStaticClass), "MyGetMethod");
            Assert.AreEqual("MyGetMethod", res.Name);
            res = Meta.GetPrivateStaticMethod(typeof(MyStaticClass), "MySetMethod");
            Assert.AreEqual("MySetMethod", res.Name);
        }

        [TestMethod]
        public void GetPrivateStaticProperty_ReturnPropertyData()
        {
            var res = Meta.GetPrivateStaticProperty(typeof(MyStaticClass), "MyProperty");
            Assert.AreEqual("MyProperty", res.Name);
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
