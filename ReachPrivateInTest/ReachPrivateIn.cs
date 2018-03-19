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
            var sut = new MyClass();
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(sut);

            sutPrivate._myField = 13;

            var res = sutPrivate._myField;

            Assert.AreEqual(13, res);
        }

        [TestMethod]
        public void CallMethodWithAndWithoutReturnValue()
        {
            var sut = new MyClass();
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(sut);

            sutPrivate.SetMethod("my name");

            var res = sutPrivate.GetMethod();

            Assert.AreEqual("my name", res);
        }

        [TestMethod]
        public void CallMethodWithAnonymousTupleReturnValue()
        {
            var sut = new MyClass();
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(sut);

            var res = sutPrivate.GetMethodTuple("b", 2);

            //  Tuples names don't traverse the boundaries it seems
            //  so even if we'd like to test for the names of the items, 
            //  namely First and Second, we cannot; and are forced to use ItemN nomenclature.
            Assert.AreEqual("b", res.Item1);
            Assert.AreEqual(2, res.Item2);
        }

        [TestMethod]
        public void CallPropertyWithSetAndGet()
        {
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(new MyClass());

            sutPrivate.MyProperty = 12;

            var res = sutPrivate.MyProperty;

            Assert.AreEqual(12, res);
        }

        [TestMethod]
        public void CallNonExistingFieldOrProperty()
        {
            var sut = new MyClass();
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(sut);

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
            var sut = new MyClass();
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(sut);

            Assert.ThrowsException<ArgumentException>(() =>
                sutPrivate.NonExistingVoidMethod(12)
            );

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingReturningMethod("abc");
            });
        }

        [TestMethod]
        public void CallStaticFieldWithSetAndGet()
        {
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(new MyClass());

            sutPrivate._myField = 13;

            var res = sutPrivate._myField;

            Assert.AreEqual(13, res);
        }

        [TestMethod]
        public void CallStaticMethodWithAndWithoutReturnValue()
        {
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(new MyClass());

            sutPrivate.StaticSetMethod(14);

            var res = sutPrivate.StaticGetMethod();

            Assert.AreEqual(14, res);
        }

        [TestMethod]
        public void CallStaticPropertyWithSetAndGet()
        {
            dynamic sutPrivate = new ReachPrivateIn<MyClass>(new MyClass());

            sutPrivate.MyStaticProperty = 15;

            var res = sutPrivate.MyStaticProperty;

            Assert.AreEqual(15, res);
        }

        private class MyClass
        {
            private string myName;

            private int MyProperty { get; set; }

            private static int MyStaticProperty { get; set; }

            private int _myField;

            private static int _myStaticField;

            private string GetMethod()
            {
                return myName;
            }

            private (string First, int Second) GetMethodTuple(string a, int n)
            {
                return (First: a, Second: n);
            }

            private void SetMethod(string value)
            {
                myName = value;
            }

            private int StaticGetMethod()
            {
                return _myStaticField;
            }

            private void StaticSetMethod(int value)
            {
                _myStaticField = value;
            }
        }
    }
}
