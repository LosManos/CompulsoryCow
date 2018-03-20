using System;
using CompulsoryCow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReachPrivateInTest
{
    [TestClass]
    public partial class ReachPrivateInStaticTest
    {
        [TestMethod]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
        public void CallFieldWithAndWithoutReturnValue(Type @class)
        {
            dynamic sutPrivate = new ReachPrivateIn(@class);

            sutPrivate._myField = 13;

            var res = sutPrivate._myField;

            Assert.AreEqual(13, res);
        }

        [TestMethod]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
        public void CallMethodWithAndWithoutReturnValue(Type @class)
        {
            dynamic sutPrivate = new ReachPrivateIn(@class);

            sutPrivate.SetMethod("my name");

            var res = sutPrivate.GetMethod();

            Assert.AreEqual("my name", res);
        }

        [TestMethod]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
        public void CallPropertyWithSetAndGet(Type @class)
        {
            dynamic sutPrivate = new ReachPrivateIn(@class);

            sutPrivate.MyProperty = 12;

            var res = sutPrivate.MyProperty;

            Assert.AreEqual(12, res);
        }

        [TestMethod]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
        public void CallNonExistingFieldOrProperty(Type @class)
        {
            dynamic sutPrivate = new ReachPrivateIn(@class);

            Assert.ThrowsException<ArgumentException>(() =>
                sutPrivate.NonExistingProperty = 12
            );

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingProperty;
            });
        }

        [TestMethod]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
        [DataRow(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
        public void CallNonExistingMethod(Type @class)
        {
            dynamic sutPrivate = new ReachPrivateIn(@class);

            Assert.ThrowsException<ArgumentException>(() =>
                sutPrivate.NonExistingVoidMethod(12)
            );

            Assert.ThrowsException<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingReturningMethod("abc");
            });
        }
    }
}
