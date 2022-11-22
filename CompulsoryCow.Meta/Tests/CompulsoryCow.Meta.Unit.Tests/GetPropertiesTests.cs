using CompulsoryCow;
using FluentAssertions;
using System;
using Xunit;

namespace MetaTest;

public class GetPropertiesTests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    [Fact]
    public void GetPublicProperties_Should_throw_When_null_parameter()
    {
        var res = Record.Exception(() =>
            Meta.GetPublicProperties<object>(null)
        );

        res.Should().BeOfType<ArgumentNullException>();
        ((ArgumentNullException)res).ParamName.Should().Be("theClass");
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void GetPublicProperties_OnlyPublicProperteis()
    {
        //	#	Arrange;
        var o = new ClassWithAllScopes();

        //	#	Act.
        var res = Meta.GetPublicProperties(o);

        //	#	Assert.
        res.Length.Should().Be(1);
        res[0].Name.Should().Be("myPublicProperty");
    }

    internal class ClassWithAllScopes
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private int myPrivateField;
        internal int myInternalField;
        protected int myProtectedField;
#pragma warning restore IDE0044 // Add readonly modifier
        public int myPublicField;

        private int myPrivateProperty { get; set; }
        internal int myInternalProperty { get; set; }
        protected int myProtectedProperty { get; set; }
        public int myPublicProperty { get; set; }

        private void myPrivateMethod() { }
        internal void myInternalMethod() { }
        protected void myProtectedMethod() { }
        public void myPublicMethod() { }
    }
}
