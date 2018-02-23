using System;
using CompulsoryCow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReachPrivateInTest
{
    [TestClass]
    public class ReachPrivateInStaticTest
    {
        [TestMethod]
        public void CallFieldWithAndWithoutReturnValue()
        {
            dynamic sutPrivate = new ReachPrivateIn(typeof(MyClass));

            sutPrivate._myField = 13;

            var res = sutPrivate._myField;

            Assert.AreEqual(13, res);
        }

        [TestMethod]
        public void CallMethodWithAndWithoutReturnValue()
        {
            dynamic sutPrivate = new ReachPrivateIn(typeof(MyClass));

            sutPrivate.SetMethod("my name");

            var res = sutPrivate.GetMethod();

            Assert.AreEqual("my name", res);
        }

        [TestMethod]
        public void CallPropertyWithSetAndGet()
        {
            dynamic sutPrivate = new ReachPrivateIn(typeof(MyClass));

            sutPrivate.MyProperty = 12;

            var res = sutPrivate.MyProperty;

            Assert.AreEqual(12, res);
        }

        [TestMethod]
        public void CallNonExistingFieldOrProperty()
        {
            dynamic sutPrivate = new ReachPrivateIn(typeof(MyClass));

            Assert.ThrowsException<ArgumentException>(() =>
                sutPrivate.NonExistingProperty = 12
            );

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingProperty;
            });
        }

        [TestMethod]
        public void CallNonExistingMethod()
        {
            dynamic sutPrivate = new ReachPrivateIn(typeof(MyClass));

            Assert.ThrowsException<ArgumentException>(() =>
                sutPrivate.NonExistingVoidMethod(12)
            );

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingReturningMethod("abc");
            });
        }

        private static class MyClass
        {
            private static string _myName;

            private static int MyProperty { get; set; }

            private static int _myField;

            private static string GetMethod()
            {
                return _myName;
            }

            private static void SetMethod(string value)
            {
                _myName = value;
            }
        }
    }
}
