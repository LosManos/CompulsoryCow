using System;
using CompulsoryCow.ReachIn;
using Xunit;

namespace ReachPrivateInTest
{
    public class ReachPrivateInTest
    {
        private dynamic[] _suts;

        public ReachPrivateInTest()
        {
            _suts = new dynamic[] {
            new ReachPrivateIn<ReachPrivateInTestClassesDotnetFramework.MyClass>(new ReachPrivateInTestClassesDotnetFramework.MyClass()),
            new ReachPrivateIn<ReachPrivateInTestClassesDotnetStandard.MyClass>(new ReachPrivateInTestClassesDotnetStandard.MyClass())
            };
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallFieldWithAndWithoutReturnValue(int index)
        {
            var sutPrivate = _suts[index];
            sutPrivate._myField = 13;

            var res = sutPrivate._myField;

            Assert.Equal(13, res);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallMethodWithAndWithoutReturnValue(int index)
        {
            //var sut = new MyClass();
            //dynamic sutPrivate = new ReachPrivateIn<MyClass>(sut);
            var sutPrivate = _suts[index];

            sutPrivate.SetMethod("my name");

            var res = sutPrivate.GetMethod();

            Assert.Equal("my name", res);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallMethodWithAnonymousTupleReturnValue(int index)
        {
            var sutPrivate = _suts[index];

            var res = sutPrivate.GetMethodTuple("b", 2);

            //  Tuples names don't traverse the boundaries it seems
            //  so even if we'd like to test for the names of the items, 
            //  namely First and Second, we cannot; and are forced to use ItemN nomenclature.
            Assert.Equal("b", res.Item1);
            Assert.Equal(2, res.Item2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallPropertyWithSetAndGet(int index)
        {
            //dynamic sutPrivate = new ReachPrivateIn<MyClass>(new MyClass());
            var sutPrivate = _suts[index];

            sutPrivate.MyProperty = 12;

            var res = sutPrivate.MyProperty;

            Assert.Equal(12, res);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallNonExistingFieldOrProperty(int index)
        {
            var sutPrivate = _suts[index];

            Assert.Throws<ArgumentException>(() =>
                sutPrivate.NonExistingProperty = 12
            );

            Assert.Throws<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingProperty;
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallNonExistingMethod(int index)
        {
            var sutPrivate = _suts[index];

            Assert.Throws<ArgumentException>(() =>
                sutPrivate.NonExistingVoidMethod(12)
            );

            Assert.Throws<ArgumentException>(() =>
            {
                var x = sutPrivate.NonExistingReturningMethod("abc");
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallStaticFieldWithSetAndGet(int index)
        {
            var sutPrivate = _suts[index];
            sutPrivate._myField = 13;

            var res = sutPrivate._myField;

            Assert.Equal(13, res);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallStaticMethodWithAndWithoutReturnValue(int index)
        {
            var sutPrivate = _suts[index];
            sutPrivate.StaticSetMethod(14);

            var res = sutPrivate.StaticGetMethod();

            Assert.Equal(14, res);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CallStaticPropertyWithSetAndGet(int index)
        {
            var sutPrivate = _suts[index];
            sutPrivate.MyStaticProperty = 15;

            var res = sutPrivate.MyStaticProperty;

            Assert.Equal(15, res);
        }
    }
}
