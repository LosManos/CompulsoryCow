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
    public class ReachInStaticTest
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
            dynamic sut1 = new ReachIn(typeof(MyPublicStaticClass));
            dynamic sut2 = new ReachIn(typeof(MyPublicStaticClass));
            var value = _pr.Int();
            Assert.AreNotEqual(default(int), value, "Sanity check we haven't randomised the default 0 value since all tests then would be moot.");

            //  #   Act.
            sut1.MyStaticPublicProperty = value;
            MyPublicStaticClass.MyStaticPublicProperty = value;

            //  #   Assert.
            Assert.AreEqual(value, MyPublicStaticClass.MyStaticPublicProperty);
            Assert.AreEqual(value, sut1.MyStaticPublicProperty);
            Assert.AreEqual(value, sut2.MyStaticPublicProperty);
        }

        [TestMethod]
        public void ReachAllStaticFieldsAndProperties()
        {
            //  #   Arrange.
            dynamic sut = new ReachIn(typeof(MyBaseClass));
            int value, res;

            //  #   Act and Assert.

            //  ##  Fields.
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
            dynamic sut = new ReachIn(typeof(MyStaticBaseClassWithTypes));

            //  #   Act and Assert.
            var anyIntValue = _pr.Int();
            sut._myPrivateStaticIntField = anyIntValue;
            Assert.AreEqual(anyIntValue, sut._myPrivateStaticIntField);

            var anyStringValue = _pr.String();
            sut._myPrivateStaticStringField = anyStringValue;
            Assert.AreEqual(anyStringValue, sut._myPrivateStaticStringField);

            var anyLongValue = _pr.PositiveLong();
            sut._myPrivateStaticLongField = anyLongValue;
            Assert.AreEqual(anyLongValue, sut._myPrivateStaticLongField);

            var anyObject =
                new
                {
                    FieldOne = _pr.Int(),
                };
            sut._myPrivateStaticObjectField = anyObject;
            Assert.AreEqual(
                anyObject.FieldOne,
                sut._myPrivateStaticObjectField.FieldOne);

            // If there is any other type to test, this is the place to add.
        }

        [TestMethod]
        public void ReachAllStaticMethods()
        {
            //  # Arrange.
            dynamic sut = new ReachIn(typeof(MyBaseClass));
            var val = _pr.Int();

            //  #   Act and Assert.
            Assert.AreEqual(val + 1, sut.MyStaticPrivateMethod(val));
            Assert.AreEqual(val + 1, sut.MyStaticInternalMethod(val));
            Assert.AreEqual(val + 1, sut.MyStaticProtectedMethod(val));
            Assert.AreEqual(val + 1, sut.MyStaticPublicMethod(val));
        }

        [TestMethod]
        public void ThrowExceptionIfStaticFieldOrPropetyNotFound()
        {
            //  #   Arrange.
            dynamic sut = new ReachIn(typeof(MyBaseClass));

            //  #   Act and Assert.
            //  A setter does not exist.
            Assert.ThrowsException<Exception>(
                () => { sut.ThisPropertyOrFieldIsNotFound = _pr.Int(); });

            //  A getter does not exist.
            Assert.ThrowsException<Exception>(
                () => { var res = sut.ThisPropertyOrFieldIsNotFound; });
        }

        [TestMethod]
        public void ThrowExceptionIfStaticMethodNotFound()
        {
            //  #   Arrange.
            dynamic sut = new ReachIn(typeof(MyBaseClass));

            //  #   Act and Assert.
            //  The method does not exist.
            Assert.ThrowsException<Exception>(
                () => { sut.ThisMethodIsNotFound(_pr.Int()); });

            //  There is a property by the same name.
            //  Trying to call it fails.
            Assert.ThrowsException<RuntimeBinderException>(
                () => { sut.MyStaticPrivateProperty(_pr.Int()); });
        }
    }
}
