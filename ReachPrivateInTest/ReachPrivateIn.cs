using System;
using CompulsoryCow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReachPrivateInTest
{
    [TestClass]
    public class ReachPrivateInTest
    {
        [TestMethod]
        public void CallFieldWithAndWithoutReturnValue()
        {
            var sut = new MyLibrary();
            dynamic sutPrivate = new ReachPrivateIn<MyLibrary>(sut);

            sutPrivate.myField = 13;

            var res = sutPrivate.myField;

            Assert.AreEqual(13, sutPrivate.myField);
        }

        [TestMethod]
        public void CallMethodWithAndWIthoutReturnValue()
        {
            var sut = new MyLibrary();
            dynamic sutPrivate = new ReachPrivateIn<MyLibrary>(sut);

            sutPrivate.SetMethod("my name");

            var res = sutPrivate.GetMethod();

            Assert.AreEqual("my name", res);
        }

        [TestMethod]
        public void CallPropertyWithSetAndGet()
        {
            var sut = new MyLibrary();
            dynamic sutPrivate = new ReachPrivateIn<MyLibrary>(sut);

            sutPrivate.MyProperty = 12;

            var res = sutPrivate.MyProperty;

            Assert.AreEqual(12, res);
        }

        [TestMethod]
        public void CallNonExistingFieldOrProperty()
        {
            var sut = new MyLibrary();
            dynamic sutPrivate = new ReachPrivateIn<MyLibrary>(sut);

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
            var sut = new MyLibrary();
            dynamic sutPrivate = new ReachPrivateIn<MyLibrary>(sut);

            Assert.ThrowsException<ArgumentException>(() =>
                sutPrivate.NonExistingVoidMethod(12)
            );

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingReturningMethod("abc");
            });
        }

        private class MyLibrary
        {
            private string myName;

            private int MyProperty { get; set; }

            private int myField;

            private string GetMethod()
            {
                return myName;
            }

            private void SetMethod(string value)
            {
                myName = value;
            }
        }

    }
}
