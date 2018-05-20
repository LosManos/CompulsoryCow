using CompulsoryCow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ReachInTest
{
    [TestClass]
    [TestCategory("ReachIn")]
    public partial class ReachInGetMemberOrThrowTest
    {
        [TestMethod]
        //  Fields.
        [DataRow("_myPrivateField")]
        [DataRow("_myInternalField")]
        [DataRow("_myProtectedField")]
        [DataRow("_myPublicField")]
        //  Static fields.
        [DataRow("_myStaticPrivateField")]
        [DataRow("_myStaticInternalField")]
        [DataRow("_myStaticProtectedField")]
        [DataRow("_myStaticPublicField")]
        //  Properties.
        [DataRow("MyPrivateProperty")]
        [DataRow("MyInternalProperty")]
        [DataRow("MyProtectedProperty")]
        [DataRow("MyPublicProperty")]
        //  Static properties.
        [DataRow("MyStaticPrivateProperty")]
        [DataRow("MyStaticInternalProperty")]
        [DataRow("MyStaticProtectedProperty")]
        [DataRow("MyStaticPublicProperty")]
        //  Methods.
        [DataRow("MyPrivateMethod")]
        [DataRow("MyInternalMethod")]
        [DataRow("MyProtectedMethod")]
        [DataRow("MyPublicMethod")]
        //  Static methods.
        [DataRow("MyStaticPrivateMethod")]
        [DataRow("MyStaticInternalMethod")]
        [DataRow("MyStaticProtectedMethod")]
        [DataRow("MyStaticPublicMethod")]
        public void GetMemberOrThrow_ValidName_ReturnMember(string memberName)
        {
            dynamic sut = new ReachIn(typeof(ReachIn));

            Assert_CanFind(sut, typeof(MyBaseClass), memberName);
        }

        [TestMethod]
        // As per the time of writing we cannot find private fields in the parent class.
        //  We also cannot find any static fields in the parent class.
        //  Fields.
        // It can be implemented, but how?
        // [DataRow("_myPrivateField")]
        [DataRow("_myInternalField")]
        [DataRow("_myProtectedField")]
        [DataRow("_myPublicField")]
        //  Static fields.
        //[DataRow("_myStaticPrivateField")]
        //[DataRow("_myStaticInternalField")]
        //[DataRow("_myStaticProtectedField")]
        //[DataRow("_myStaticPublicField")]
        //  Properties.
        //[DataRow("MyPrivateProperty")]
        [DataRow("MyInternalProperty")]
        [DataRow("MyProtectedProperty")]
        [DataRow("MyPublicProperty")]
        //  Static properties.
        //[DataRow("MyStaticPrivateProperty")]
        //[DataRow("MyStaticInternalProperty")]
        //[DataRow("MyStaticProtectedProperty")]
        //[DataRow("MyStaticPublicProperty")]
        //  Methods.
        //[DataRow("MyPrivateMethod")]
        [DataRow("MyInternalMethod")]
        [DataRow("MyProtectedMethod")]
        [DataRow("MyPublicMethod")]
        //  Static methods.
        //[DataRow("MyStaticPrivateMethod")]
        //[DataRow("MyStaticInternalMethod")]
        //[DataRow("MyStaticProtectedMethod")]
        //[DataRow("MyStaticPublicMethod")]
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
            Assert.AreEqual(res.Name, memberName, $"The name {memberName} was not found.");
        }
    }
}
