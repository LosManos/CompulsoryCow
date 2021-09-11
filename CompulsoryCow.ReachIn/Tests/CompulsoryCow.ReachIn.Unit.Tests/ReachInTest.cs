using CompulsoryCow;
using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using ReachInTestDotnetFramework;
using System;
using VacheTacheLibrary;
using Xunit;

namespace CompulsoryCow.ReachIn.Tests
{
    [Collection(Common.SequentialDueToStatic)]
    public class ReachInTest
    {
        [Fact]
        public void ObjAndSutUseTheSameInstance()
        {
            //  # Arrange.
            var pr = new PseudoRandom(nameof(ObjAndSutUseTheSameInstance));
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);
            dynamic sut2 = new ReachIn(obj);
            var value = pr.Int();
            value.Should().NotBe(default(int), "Sanity check we haven't randomised the default 0 value since all tests then would be moot.");

            //  #   Act.
            sut.MyPublicProperty = value;
            sut2.MyPublicProperty = value;

            //  #   Assert.
            value.Should().Be(obj.MyPublicProperty);
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut2.MyPublicProperty.Should().Be(sut.MyPublicProperty);
            Assert.Equal(sut.MyPublicProperty, sut2.MyPublicProperty);
        }

        [Fact]
        public void ReachAllFieldsAndProperties()
        {
            //  #   Arrange.
            var pr = new PseudoRandom(nameof(ReachAllFieldsAndProperties));
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);
            int value, res;

            //  #   Act and Assert.

            //  ##  Fields.
            value = pr.Int();
            sut._myPrivateField = value;
            res = sut._myPrivateField;
            res.Should().Be(value);
            value = pr.Int();
            sut._myInternalField = value;
            res = sut._myInternalField;
            res.Should().Be(value);
            value = pr.Int();
            sut._myProtectedField = value;
            res = sut._myProtectedField;
            res.Should().Be(value);
            value = pr.Int();
            sut._myPublicField = value;
            res = sut._myPublicField;
            res.Should().Be(value);

            //  ##  Static fields.
            value = pr.Int();
            sut._myStaticPrivateField = value;
            res = sut._myStaticPrivateField;
            res.Should().Be(value);
            value = pr.Int();
            sut._myStaticInternalField = value;
            res = sut._myStaticInternalField;
            res.Should().Be(value);
            value = pr.Int();
            sut._myStaticProtectedField = value;
            res = sut._myStaticProtectedField;
            res.Should().Be(value);
            value = pr.Int();
            sut._myStaticPublicField = value;
            res = sut._myStaticPublicField;
            res.Should().Be(value);

            //  ##   Properties.
            value = pr.Int();
            sut.MyPrivateProperty = value;
            res = sut.MyPrivateProperty;
            res.Should().Be(value);
            value = pr.Int();
            sut.MyInternalProperty = value;
            res = sut.MyInternalProperty;
            res.Should().Be(value);
            value = pr.Int();
            sut.MyProtectedProperty = value;
            res = sut.MyProtectedProperty;
            res.Should().Be(value);
            value = pr.Int();
            sut.MyPublicProperty = value;
            res = sut.MyPublicProperty;
            res.Should().Be(value);

            //  ##   Static properties.
            value = pr.Int();
            sut.MyStaticPrivateProperty = value;
            res = sut.MyStaticPrivateProperty;
            res.Should().Be(value);
            value = pr.Int();
            sut.MyStaticInternalProperty = value;
            res = sut.MyStaticInternalProperty;
            res.Should().Be(value);
            value = pr.Int();
            sut.MyStaticProtectedProperty = value;
            res = sut.MyStaticProtectedProperty;
            res.Should().Be(value);
            value = pr.Int();
            sut.MyStaticPublicProperty = value;
            res = sut.MyStaticPublicProperty;
            res.Should().Be(value);
        }

        [Fact]
        public void ReachAllFieldsOfAllTypes()
        {
            //  # Arrange.
            var pr = new PseudoRandom(nameof(ReachAllFieldsOfAllTypes));
            dynamic sut = new ReachIn(new MyBaseClassWithTypes());

            //  #   Act and Assert.
            var anyIntValue = pr.Int();
            sut._myPrivateIntField = anyIntValue;
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut._myPrivateIntField.Should().Be(anyIntValue);
            Assert.Equal(anyIntValue, sut._myPrivateIntField);

            var anyStringValue = pr.String();
            sut._myPrivateStringField = anyStringValue;
            var anyLongValue = pr.PositiveLong();
            sut._myPrivateLongField = anyLongValue;
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut._myPrivateLongField.Should().Be(anyLongValue);
            Assert.Equal(anyLongValue, sut._myPrivateLongField);

            var anyObject = 
                new
                {
                    FieldOne = pr.Int(),
                };
            sut._myPrivateObjectField = anyObject;
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut._myPrivateObjectField.FieldOne.Should().Be(anyObject.FieldOne);
            Assert.Equal(anyObject.FieldOne, sut._myPrivateObjectField.FieldOne);

            // If there is any other type to test, this is the place to add.
        }

        [Fact]
        public void ReachAllInnerClasses()
        {
            //  #   Arrange.
            var pr = new PseudoRandom(nameof(ReachAllInnerClasses));
            var obj = new MyPublicClass();
            dynamic sut = new ReachIn(obj);
            int res;
            int val;

            //  #   Act and Assert.
            val = pr.Int();

            //  We don't support finding privates in inherited classes
            //  so here we look for a field overloaded in the child class
            //  just as a sanity check.
            sut._myInnerPrivateClass._myPrivateField = val;
            res = sut._myInnerPrivateClass._myPrivateField;
            res.Should().Be(val);

            //  Keep looking for a visible (e.g. internal) field that comes
            //  from the base class.
            sut._myInnerPrivateClass._myInternalField = val;
            res = sut._myInnerPrivateClass._myInternalField;
            res.Should().Be(val);
            sut._myInnerInternalClass._myInternalField = val;
            res = sut._myInnerInternalClass._myInternalField;
            res.Should().Be(val);
            sut._myInnerProtectedClass._myInternalField = val;
            res = sut._myInnerProtectedClass._myInternalField;
            res.Should().Be(val);
            sut._myInnerPublicClass._myInternalField = val;
            res = sut._myInnerPublicClass._myInternalField;
            res.Should().Be(val);
        }

        [Fact]
        public void ReachAllMethods()
        {
            //  # Arrange.
            var pr = new PseudoRandom(nameof(ReachAllMethods));
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);
            var val = pr.Int();

            //  #   Act and Assert.
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut.MyPrivateMethod(val).Should().Be(val + 1);
            //sut.MyInternalMethod(val).Should().Be(val + 1);
            //sut.MyProtectedMethod(val).Should().Be(val + 1);
            //sut.MyPublicMethod(val).Shoul().Be(val + 1);
            Assert.Equal(val + 1, sut.MyPrivateMethod(val));
            Assert.Equal(val + 1, sut.MyInternalMethod(val));
            Assert.Equal(val + 1, sut.MyProtectedMethod(val));
            Assert.Equal(val + 1, sut.MyPublicMethod(val));
        }

        [Fact]
        public void ThrowExceptionIfFieldOrPropetyNotFound()
        {
            //  #   Arrange.
            var pr = new PseudoRandom(nameof(ThrowExceptionIfFieldOrPropetyNotFound));
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);

            //  #   Act and Assert.
            //  A setter does not exist.
            Assert.Throws<Exception>(
                () => { sut.ThisPropertyOrFieldIsNotFound = pr.Int(); });

            //  A getter does not exist.
            Assert.Throws<Exception>(
                () => { var res = sut.ThisPropertyOrFieldIsNotFound; });
        }

        [Fact]
        public void ThrowExceptionIfMethodNotFound()
        {
            //  #   Arrange.
            var pr = new PseudoRandom(nameof(ThrowExceptionIfMethodNotFound));
            var obj = new MyBaseClass();
            dynamic sut = new ReachIn(obj);

            //  #   Act and Assert.
            //  The method does not exist.
            Assert.Throws<Exception>(
                () => { sut.ThisMethodIsNotFound(pr.Int()); });

            //  There is a property by the same name.
            Assert.Throws<RuntimeBinderException>(
                () => { sut.MyPrivateProperty(pr.Int()); });
        }

        [Fact]
        public void ThrowExceptionOverloadedMember()
        {
            //  #   Arrange.
            dynamic sut = new ReachIn(new MyOverloadedMethodClass());

            //  #   Act and Assert.
            Assert.Throws<Exception>(
                () => sut.MyMethod);
        }

        private class MyOverloadedMethodClass
        {
            private void MyMethod(int n) { }
            private void MyMethod(string s) { }
        }

    }
}
