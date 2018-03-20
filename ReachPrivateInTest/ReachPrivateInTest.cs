using System;
using CompulsoryCow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReachPrivateInTest
{
    [TestClass]
    public class ReachPrivateInTest
    {
        private dynamic[] _suts;

        [TestInitialize]
        public void Initialise()
        {
            _suts = new dynamic[] {
            new ReachPrivateIn<ReachPrivateInTestClassesDotnetFramework.MyClass>(new ReachPrivateInTestClassesDotnetFramework.MyClass()),
            new ReachPrivateIn<ReachPrivateInTestClassesDotnetStandard.MyClass>(new ReachPrivateInTestClassesDotnetStandard.MyClass())
            };
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallFieldWithAndWithoutReturnValue(int index)
        {
            var sutPrivate = _suts[index];
            sutPrivate._myField = 13;

            var res = sutPrivate._myField;

            Assert.AreEqual(13, res);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallMethodWithAndWithoutReturnValue(int index)
        {
            //var sut = new MyClass();
            //dynamic sutPrivate = new ReachPrivateIn<MyClass>(sut);
            var sutPrivate = _suts[index];

            sutPrivate.SetMethod("my name");

            var res = sutPrivate.GetMethod();

            Assert.AreEqual("my name", res);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallMethodWithAnonymousTupleReturnValue(int index)
        {
            var sutPrivate = _suts[index];

            var res = sutPrivate.GetMethodTuple("b", 2);

            //  Tuples names don't traverse the boundaries it seems
            //  so even if we'd like to test for the names of the items, 
            //  namely First and Second, we cannot; and are forced to use ItemN nomenclature.
            Assert.AreEqual("b", res.Item1);
            Assert.AreEqual(2, res.Item2);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallPropertyWithSetAndGet(int index)
        {
            //dynamic sutPrivate = new ReachPrivateIn<MyClass>(new MyClass());
            var sutPrivate = _suts[index];

            sutPrivate.MyProperty = 12;

            var res = sutPrivate.MyProperty;

            Assert.AreEqual(12, res);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallNonExistingFieldOrProperty(int index)
        {
            var sutPrivate = _suts[index];

            Assert.ThrowsException<ArgumentException>(() =>
                sutPrivate.NonExistingProperty = 12
            );

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingProperty;
            });
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallNonExistingMethod(int index)
        {
            var sutPrivate = _suts[index];

            Assert.ThrowsException<ArgumentException>(() =>
                sutPrivate.NonExistingVoidMethod(12)
            );

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingReturningMethod("abc");
            });
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallStaticFieldWithSetAndGet(int index)
        {
            var sutPrivate = _suts[index];
            sutPrivate._myField = 13;

            var res = sutPrivate._myField;

            Assert.AreEqual(13, res);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallStaticMethodWithAndWithoutReturnValue(int index)
        {
            var sutPrivate = _suts[index];
            sutPrivate.StaticSetMethod(14);

            var res = sutPrivate.StaticGetMethod();

            Assert.AreEqual(14, res);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void CallStaticPropertyWithSetAndGet(int index)
        {
            var sutPrivate = _suts[index];
            sutPrivate.MyStaticProperty = 15;

            var res = sutPrivate.MyStaticProperty;

            Assert.AreEqual(15, res);
        }
    }
}
