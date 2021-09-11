using CompulsoryCow;
using FluentAssertions;
using System;
using Xunit;

namespace CompulsoryCow.ReachIn.Tests
{
    [Collection(Common.SequentialDueToStatic)]
    public partial class ReachInGetMemberOrThrowTest
    {
        [Theory]
        //  Fields.
        [InlineData("_myPrivateField")]
        [InlineData("_myInternalField")]
        [InlineData("_myProtectedField")]
        [InlineData("_myPublicField")]
        //  Static fields.
        [InlineData("_myStaticPrivateField")]
        [InlineData("_myStaticInternalField")]
        [InlineData("_myStaticProtectedField")]
        [InlineData("_myStaticPublicField")]
        //  Properties.
        [InlineData("MyPrivateProperty")]
        [InlineData("MyInternalProperty")]
        [InlineData("MyProtectedProperty")]
        [InlineData("MyPublicProperty")]
        //  Static properties.
        [InlineData("MyStaticPrivateProperty")]
        [InlineData("MyStaticInternalProperty")]
        [InlineData("MyStaticProtectedProperty")]
        [InlineData("MyStaticPublicProperty")]
        //  Methods.
        [InlineData("MyPrivateMethod")]
        [InlineData("MyInternalMethod")]
        [InlineData("MyProtectedMethod")]
        [InlineData("MyPublicMethod")]
        //  Static methods.
        [InlineData("MyStaticPrivateMethod")]
        [InlineData("MyStaticInternalMethod")]
        [InlineData("MyStaticProtectedMethod")]
        [InlineData("MyStaticPublicMethod")]
        public void GetMemberOrThrow_ValidName_ReturnMember(string memberName)
        {
            dynamic sut = new ReachIn(typeof(ReachIn));

            Assert_CanFind(sut, typeof(MyBaseClass), memberName);
        }

        [Theory]
        // As per the time of writing we cannot find private fields in the parent class.
        //  We also cannot find any static fields in the parent class.
        //  Fields.
        // It can be implemented, but how?
        // [InlineData("_myPrivateField")]
        [InlineData("_myInternalField")]
        [InlineData("_myProtectedField")]
        [InlineData("_myPublicField")]
        //  Static fields.
        //[InlineData("_myStaticPrivateField")]
        //[InlineData("_myStaticInternalField")]
        //[InlineData("_myStaticProtectedField")]
        //[InlineData("_myStaticPublicField")]
        //  Properties.
        //[InlineData("MyPrivateProperty")]
        [InlineData("MyInternalProperty")]
        [InlineData("MyProtectedProperty")]
        [InlineData("MyPublicProperty")]
        //  Static properties.
        //[InlineData("MyStaticPrivateProperty")]
        //[InlineData("MyStaticInternalProperty")]
        //[InlineData("MyStaticProtectedProperty")]
        //[InlineData("MyStaticPublicProperty")]
        //  Methods.
        //[InlineData("MyPrivateMethod")]
        [InlineData("MyInternalMethod")]
        [InlineData("MyProtectedMethod")]
        [InlineData("MyPublicMethod")]
        //  Static methods.
        //[InlineData("MyStaticPrivateMethod")]
        //[InlineData("MyStaticInternalMethod")]
        //[InlineData("MyStaticProtectedMethod")]
        //[InlineData("MyStaticPublicMethod")]
        public void GetMemberOrThrow_ValidNameInParent_ReturnMember(string memberName)
        {
            var sut = new ReachIn(typeof(ReachIn));

            Assert_CanFind(sut, typeof(MyChildClass), memberName);
        }

        private static void Assert_CanFind(dynamic sut, Type classType, string memberName)
        {
            //  Act.
            var res = sut.GetMemberOrThrow(classType, memberName);

            //  Probably superfluous to test anything more here since the Act call should either return a valid value or throw an exception.
            //  But say we rearrange the code so it soes not throw an exception but instead return a null (or anything else similarly forced) then we want to catch that too.

            // We have a problem here with FluentAssertions where it, runtime, throws an exception even though the parameters are equal.
            //res.Name.Should().Be(memberName, $"The name {memberName} was not found.");
            Assert.True(memberName == res.Name, $"The name {memberName} was not found.");
        }
    }
}
