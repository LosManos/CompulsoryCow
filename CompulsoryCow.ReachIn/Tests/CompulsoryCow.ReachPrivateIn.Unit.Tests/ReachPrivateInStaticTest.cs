using System;
using CompulsoryCow.ReachIn;
using Xunit;

namespace ReachPrivateInTest;

public partial class ReachPrivateInStaticTest
{
    [Theory]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
    public void CallFieldWithAndWithoutReturnValue(Type @class)
    {
        dynamic sutPrivate = new ReachPrivateIn(@class);

        sutPrivate._myField = 13;

        var res = sutPrivate._myField;

        Assert.Equal(13, res);
    }

    [Theory]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
    public void CallMethodWithAndWithoutReturnValue(Type @class)
    {
        dynamic sutPrivate = new ReachPrivateIn(@class);

        sutPrivate.SetMethod("my name");

        var res = sutPrivate.GetMethod();

        Assert.Equal("my name", res);
    }

    [Theory]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
    public void CallPropertyWithSetAndGet(Type @class)
    {
        dynamic sutPrivate = new ReachPrivateIn(@class);

        sutPrivate.MyProperty = 12;

        var res = sutPrivate.MyProperty;

        Assert.Equal(12, res);
    }

    [Theory]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
    public void CallNonExistingFieldOrProperty(Type @class)
    {
        dynamic sutPrivate = new ReachPrivateIn(@class);

        Assert.Throws<ArgumentException>(() =>
            sutPrivate.NonExistingProperty = 12
        );

        Assert.Throws<ArgumentException>(() =>
        {
            var x = sutPrivate.NonExistingProperty;
        });
    }

    [Theory]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetFramework.MyStaticClass))]
    [InlineData(typeof(ReachPrivateInTestClassesDotnetStandard.MyStaticClass))]
    public void CallNonExistingMethod(Type @class)
    {
        dynamic sutPrivate = new ReachPrivateIn(@class);

        Assert.Throws<ArgumentException>(() =>
            sutPrivate.NonExistingVoidMethod(12)
        );

        Assert.Throws<ArgumentException>(() =>
        {
            var x = sutPrivate.NonExistingReturningMethod("abc");
        });
    }
}
