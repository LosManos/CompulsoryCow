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
            var res = Meta.GetPrivateField<MyClass>(sut, "myField");
            Assert.AreEqual("myField", res.Name);
        }

        [TestMethod]
        public void GetPrivateMethod_ReturnFieldData()
        {
            var sut = new MyClass();
            var res = Meta.GetPrivateMethod<MyClass>(sut, "MyGetMethod");
            Assert.AreEqual("MyGetMethod", res.Name);
            res = Meta.GetPrivateMethod<MyClass>(sut, "MySetMethod");
            Assert.AreEqual("MySetMethod", res.Name);
        }

        [TestMethod]
        public void GetPrivateProperty_ReturnFieldData()
        {
            var sut = new MyClass();
            var res = Meta.GetPrivateProperty<MyClass>(sut, "MyProperty");
            Assert.AreEqual("MyProperty", res.Name);
        }

        private class MyClass
        {
            private int _myMethodField;
            private int myField;
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

    }
}
