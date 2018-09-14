using CompulsoryCow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionUtilitiesTests
{
    [TestClass]
    public class GetPublicTest
    {
        [TestMethod]
        public void GetPublicProperties_ReturnOnlyPublicProperties()
        {
            var res = Meta.GetPublicProperties(new MyClass());

            //  #   Assert.
            Assert.AreEqual(2, res.Length);
            Assert.AreEqual("MyPublicIntProperty", res[0].Name);
            Assert.AreEqual("MyPublicStringProperty", res[1].Name);
        }

        private class MyClass
        {
            private int _myMethodField;
            private int _myField;
            private int MyProperty { get; set; }
            public int MyPublicIntProperty { get; set; }
            public string MyPublicStringProperty { get; set; }
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
