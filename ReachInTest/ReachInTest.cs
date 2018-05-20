using CompulsoryCow;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReachInTestDotnetFramework;
using System;
using VacheTacheLibrary;

namespace ReachInTest
{
    [TestClass]
    [TestCategory("ReachIn")]
    public class ReachInTest
    {
        private PseudoRandom _pr;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Initialise()
        {
            _pr = new PseudoRandom(TestContext.TestName);
        }

        [TestMethod]
        public void ObjAndSutUseTheSameInstance()
        {
            //  # Arrange.
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);
            dynamic sut2 = new ReachIn(obj);
            var value = _pr.Int();
            Assert.AreNotEqual(default(int), value, "Sanity check we haven't randomised the default 0 value since all tests then would be moot.");

            //  #   Act.
            sut.MyPublicProperty = value;
            sut2.MyPublicProperty = value;

            //  #   Assert.
            Assert.AreEqual(obj.MyPublicProperty, value);
            Assert.AreEqual(sut.MyPublicProperty, sut2.MyPublicProperty);
        }

        [TestMethod]
        public void ReachAllFieldsAndProperties()
        {
            //  #   Arrange.
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);
            int value, res;

            //  #   Act and Assert.

            //  ##  Fields.
            value = _pr.Int();
            sut._myPrivateField = value;
            res = sut._myPrivateField;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut._myInternalField = value;
            res = sut._myInternalField;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut._myProtectedField = value;
            res = sut._myProtectedField;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut._myPublicField = value;
            res = sut._myPublicField;
            Assert.AreEqual(value, res);

            //  ##  Static fields.
            value = _pr.Int();
            sut._myStaticPrivateField = value;
            res = sut._myStaticPrivateField;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut._myStaticInternalField = value;
            res = sut._myStaticInternalField;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut._myStaticProtectedField = value;
            res = sut._myStaticProtectedField;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut._myStaticPublicField = value;
            res = sut._myStaticPublicField;
            Assert.AreEqual(value, res);

            //  ##   Properties.
            value = _pr.Int();
            sut.MyPrivateProperty = value;
            res = sut.MyPrivateProperty;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut.MyInternalProperty = value;
            res = sut.MyInternalProperty;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut.MyProtectedProperty = value;
            res = sut.MyProtectedProperty;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut.MyPublicProperty = value;
            res = sut.MyPublicProperty;
            Assert.AreEqual(value, res);

            //  ##   Static properties.
            value = _pr.Int();
            sut.MyStaticPrivateProperty = value;
            res = sut.MyStaticPrivateProperty;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut.MyStaticInternalProperty = value;
            res = sut.MyStaticInternalProperty;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut.MyStaticProtectedProperty = value;
            res = sut.MyStaticProtectedProperty;
            Assert.AreEqual(value, res);
            value = _pr.Int();
            sut.MyStaticPublicProperty = value;
            res = sut.MyStaticPublicProperty;
            Assert.AreEqual(value, res);
        }

        [TestMethod]
        public void ReachAllFieldsOfAllTypes()
        {
            //  # Arrange.
            dynamic sut = new ReachIn(new MyBaseClassWithTypes());

            //  #   Act and Assert.
            var anyIntValue = _pr.Int();
            sut._myPrivateIntField = anyIntValue;
            Assert.AreEqual(anyIntValue, sut._myPrivateIntField);

            var anyStringValue = _pr.String();
            sut._myPrivateStringField = anyStringValue;
            Assert.AreEqual(anyStringValue, sut._myPrivateStringField);

            var anyLongValue = _pr.PositiveLong();
            sut._myPrivateLongField = anyLongValue;
            Assert.AreEqual(anyLongValue, sut._myPrivateLongField);

            var anyObject = 
                new
                {
                    FieldOne = _pr.Int(),
                };
            sut._myPrivateObjectField = anyObject;
            Assert.AreEqual(
                anyObject.FieldOne,
                sut._myPrivateObjectField.FieldOne);

            // If there is any other type to test, this is the place to add.
        }

        [TestMethod]
        public void ReachAllInnerClasses()
        {
            //  #   Arrange.
            var obj = new MyPublicClass();
            dynamic sut = new ReachIn(obj);
            int res;
            int val;

            //  #   Act and Assert.
            val = _pr.Int();

            //  We don't support finding privates in inherited classes
            //  so here we look for a field overloaded in the child class
            //  just as a sanity check.
            sut._myInnerPrivateClass._myPrivateField = val;
            res = sut._myInnerPrivateClass._myPrivateField;
            Assert.AreEqual(val, res);

            //  Keep looking for a visible (e.g. internal) field that comes
            //  from the base class.
            sut._myInnerPrivateClass._myInternalField = val;
            res = sut._myInnerPrivateClass._myInternalField;
            Assert.AreEqual(val, res);
            sut._myInnerInternalClass._myInternalField = val;
            res = sut._myInnerInternalClass._myInternalField;
            Assert.AreEqual(val, res);
            sut._myInnerProtectedClass._myInternalField = val;
            res = sut._myInnerProtectedClass._myInternalField;
            Assert.AreEqual(val, res);
            sut._myInnerPublicClass._myInternalField = val;
            res = sut._myInnerPublicClass._myInternalField;
            Assert.AreEqual(val, res);
        }

        [TestMethod]
        public void ReachAllMethods()
        {
            //  # Arrange.
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);
            var val = _pr.Int();

            //  #   Act and Assert.
            Assert.AreEqual(val + 1, sut.MyPrivateMethod(val));
            Assert.AreEqual(val + 1, sut.MyInternalMethod(val));
            Assert.AreEqual(val + 1, sut.MyProtectedMethod(val));
            Assert.AreEqual(val + 1, sut.MyPublicMethod(val));
        }

        [TestMethod]
        public void ThrowExceptionIfFieldOrPropetyNotFound()
        {
            //  #   Arrange.
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);

            //  #   Act and Assert.
            //  A setter does not exist.
            Assert.ThrowsException<Exception>(
                () => { sut.ThisPropertyOrFieldIsNotFound = _pr.Int(); });

            //  A getter does not exist.
            Assert.ThrowsException<Exception>(
                () => { var res = sut.ThisPropertyOrFieldIsNotFound; });
        }

        [TestMethod]
        public void ThrowExceptionIfMethodNotFound()
        {
            //  #   Arrange.
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);

            //  #   Act and Assert.
            //  The method does not exist.
            Assert.ThrowsException<Exception>(
                () => { sut.ThisMethodIsNotFound(_pr.Int()); });

            //  There is a property by the same name.
            Assert.ThrowsException<RuntimeBinderException>(
                () => { sut.MyPrivateProperty(_pr.Int()); });
        }

        [TestMethod]
        public void ThrowExceptionOverloadedMember()
        {
            //  #   Arrange.
            dynamic sut = new ReachIn(new MyOverloadedMethodClass());

            //  #   Act and Assert.
            Assert.ThrowsException<Exception>(
                () => sut.MyMethod);
        }

        private class MyOverloadedMethodClass
        {
            private void MyMethod(int n) { }
            private void MyMethod(string s) { }
        }

    }
}
