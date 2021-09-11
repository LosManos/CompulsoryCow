using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using ReachInTestDotnetFramework;
using System;
using VacheTacheLibrary;
using Xunit;

namespace CompulsoryCow.ReachIn.Tests
{
    [Collection(Common.SequentialDueToStatic)]
    public class ReachInStaticTest
    {
        [Fact]
        public void ObjAndSutUseTheSameInstance()
        {
            //  # Arrange.
            var pr = new PseudoRandom(nameof(ObjAndSutUseTheSameInstance));
            dynamic sut1 = new ReachIn(typeof(MyPublicStaticClass));
            dynamic sut2 = new ReachIn(typeof(MyPublicStaticClass));
            var value = pr.Int();
            value.Should().NotBe(default(int), "Sanity check we haven't randomised the default 0 value since all tests then would be moot.");

            //  #   Act.
            sut1.MyStaticPublicProperty = value;
            MyPublicStaticClass.MyStaticPublicProperty = value;

            //  #   Assert.
            MyPublicStaticClass.MyStaticPublicProperty.Should().Be(value);
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut1.MyStaticPublicProperty.Should().Be(value);
            //sut2.MyStaticPublicProperty.Should().Be(value);
            Assert.Equal(value, sut1.MyStaticPublicProperty);
            Assert.Equal(value, sut2.MyStaticPublicProperty);
        }

        [Fact]
        public void ReachAllStaticFieldsAndProperties()
        {
            //  #   Arrange.
            var pr = new PseudoRandom(nameof(ReachAllStaticFieldsAndProperties));
            dynamic sut = new ReachIn(typeof(MyBaseClass));
            int value, res;

            //  #   Act and Assert.

            //  ##  Fields.
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
            dynamic sut = new ReachIn(typeof(MyStaticBaseClassWithTypes));

            //  #   Act and Assert.
            var anyIntValue = pr.Int();
            sut._myPrivateStaticIntField = anyIntValue;
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut._myPrivateStaticIntField.Should().be(anyIntValue);
            Assert.Equal(anyIntValue, sut._myPrivateStaticIntField);

            var anyStringValue = pr.String();
            sut._myPrivateStaticStringField = anyStringValue;
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut._myPrivateStaticStringField.Should().Be(anyStringValue);
            Assert.Equal(anyStringValue, sut._myPrivateStaticStringField);

            var anyLongValue = pr.PositiveLong();
            sut._myPrivateStaticLongField = anyLongValue;
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut._myPrivateStaticLongField.Should().be(anyLongValue);
            Assert.Equal(anyLongValue, sut._myPrivateStaticLongField);

            var anyObject =
                new
                {
                    FieldOne = pr.Int(),
                };
            sut._myPrivateStaticObjectField = anyObject;
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut._myPrivateStaticObjectField.FieldOne.Should().Be(anyObject.FieldOne);
            Assert.Equal(anyObject.FieldOne, sut._myPrivateStaticObjectField.FieldOne);

            // If there is any other type to test, this is the place to add.
        }

        [Fact]
        public void ReachAllStaticMethods()
        {
            //  # Arrange.
            var pr = new PseudoRandom(nameof(ReachAllStaticMethods));
            dynamic sut = new ReachIn(typeof(MyBaseClass));
            var val = pr.Int();

            //  #   Act and Assert.
            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //sut.MyStaticPrivateMethod(val).Should().Be(val + 1);
            //sut.MyStaticInternalMethod(val).Should().Be(val+1);
            //sut.MyStaticProtectedMethod(val).Should().Be(val+1);
            //sut.MyStaticPublicMethod(val).Should().Be(val+1);
            Assert.Equal(val + 1, sut.MyStaticPrivateMethod(val));
            Assert.Equal(val + 1, sut.MyStaticInternalMethod(val));
            Assert.Equal(val + 1, sut.MyStaticProtectedMethod(val));
            Assert.Equal(val + 1, sut.MyStaticPublicMethod(val));
        }

        [Fact]
        public void ThrowExceptionIfStaticFieldOrPropetyNotFound()
        {
            //  #   Arrange.
            var pr = new PseudoRandom(nameof(ThrowExceptionIfStaticFieldOrPropetyNotFound));
            dynamic sut = new ReachIn(typeof(MyBaseClass));

            //  #   Act and Assert.
            //  A setter does not exist.
            Assert.Throws<Exception>(
                () => { sut.ThisPropertyOrFieldIsNotFound = pr.Int(); });

            //  A getter does not exist.
            Assert.Throws<Exception>(
                () => { var res = sut.ThisPropertyOrFieldIsNotFound; });
        }

        [Fact]
        public void ThrowExceptionIfStaticMethodNotFound()
        {
            //  #   Arrange.
            var pr = new PseudoRandom(nameof(ThrowExceptionIfStaticMethodNotFound));
            dynamic sut = new ReachIn(typeof(MyBaseClass));

            //  #   Act and Assert.
            //  The method does not exist.
            Assert.Throws<Exception>(
                () => { sut.ThisMethodIsNotFound(pr.Int()); });

            //  There is a property by the same name.
            //  Trying to call it fails.
            Assert.Throws<RuntimeBinderException>(
                () => { sut.MyStaticPrivateProperty(pr.Int()); });
        }
    }
}
