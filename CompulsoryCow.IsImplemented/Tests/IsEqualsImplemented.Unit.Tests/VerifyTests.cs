using FluentAssertions;
using CompulsoryCow.IsImplemented;
using System.Reflection;

namespace VerifyTest;

public partial class VerifyTests
{
    [Fact]
    public void IsEqualsImpelementedCorrectlyShouldReturnTrueAndNoInformationForProperlyImplementedClass()
    {
        //  #   Arrange.
        var sut = new Verify();

        //  #   Act.
        var res = sut.IsEqualsImplementedCorrectly<ProperlyImplementedClass>();

        //  #   Assert.
        res.Should().BeTrue();
        sut.ResultMessage.Should().BeEmpty();
        sut.ResultProperty.Should().BeNull();
    }

    [Fact]
    public void AreAllEqualImplementedCorrectlyShouldThrowIfNoAssembly()
    {
        //  #   Arrange.
        var sut = new Verify();

        //  #   Act.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Action comparison = () => { sut.AreAllEqualsImplementedCorrectly(null); };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        //  #   Assert.
        comparison.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void IsEqualsImplementedCorrectlyShouldReturnFalseAndInformationForClassLackingFieldInEqualsComparison()
    {
        //  #   Arrange.
        var sut = new Verify();

        //  #   Act.
        var res = sut.IsEqualsImplementedCorrectly<LackingAFieldInEqualsComparisonClass>();

        //  #   Assert.
        res.Should().BeFalse();
        sut.ResultMessage.Should()
            .Be(
                $"It seems property {nameof(LackingAFieldInEqualsComparisonClass.MyString)} is not used in the comparison.");
    }

    [Fact]
    public void ShouldThrowExeptionWithInformativeMessageIfUnknownTypeIsEncountered()
    {
        //  #   Arrange.
        var sut = new Verify();

        //  #   Act.
        Action comparison = () => { sut.IsEqualsImplementedCorrectly<ClassWithCustomType>(); };

        //  #   Assert.
        comparison.Should()
            .Throw<TypeNotRecognisedException>()
            .WithMessage($"*{nameof(ClassWithCustomType.InnerClass)}*",
                "The name of the type of the missing compared property should be returned in the exception message.")
            .WithMessage($"*{nameof(Verify.SetComparisonValues)}*",
                "The message should hint the user about how to fix the problem.");
    }

    [Fact]
    public void ShouldUseUpdatedValues()
    {
        //  #   Arrange.
        var sut = new Verify();
        sut.SetComparisonValues(
            new ClassWithCustomType.InnerClass { MyChar = 'a' },
            new ClassWithCustomType.InnerClass { MyChar = 'b' });

        //  #   Act.
        var res = sut.IsEqualsImplementedCorrectly<ClassWithCustomType>();

        res.Should().BeTrue();
    }

    [Fact]
    public void FindIfAClassHasDeclaredEqualsManually()
    {
        //  #   Arrange.
        var sut = new Verify();

        //  #   Act.
        var resHasBeenDeclared = sut.HasEqualsBeenDeclared<ClassWithEqualsDeclaration>();
        var resHasNotBeenDeclared = sut.HasEqualsBeenDeclared<ClassWithoutEqualsDeclaration>();
        var resHasBeenDeclaredWithWrongParameters =
            sut.HasEqualsBeenDeclared<ClassWithEqualsDeclarationWithWrongParameters>();
        var resHasBeenDeclaredAsStatic = sut.HasEqualsBeenDeclared<ClassWithStaticEqualsDeclaration>();
        var resHasBeenDeclaredAsInternal = sut.HasEqualsBeenDeclared<ClassWithInternalEqualsDefinition>();

        //  #   Assert.
        resHasBeenDeclared.Should().BeTrue();
        resHasNotBeenDeclared.Should().BeFalse();
        resHasBeenDeclaredWithWrongParameters.Should().BeFalse();
        resHasBeenDeclaredAsStatic.Should().BeFalse();
        resHasBeenDeclaredAsInternal.Should().BeFalse();
    }

    /// <summary>
    /// Note: To load <see cref="IsEqualsImplementedAssemblyNotOk"/> in ncrunch
    /// the "Framework utilisation type for MSTest" 
    /// has to be set to "UseDynamicAnalysis"
    /// in NCrunch configuration.
    /// A clue for this is in the error test output.
    /// More info can be found here: <see cref="https://forum.ncrunch.net/yaf_postst2543_Array-as-datarow-attribute-parameter.aspx"/>.
    /// </summary>
    [Theory]
    [InlineData(nameof(IsEqualsImplementedAssemblyOk),
        true,
        null,
        "")]
    [InlineData(nameof(IsEqualsImplementedAssemblyNotOk),
        false,
        typeof(IsEqualsImplementedAssemblyNotOk.AClassWithEqualsNotCorrectlyImplemented),
        "It seems class " + nameof(IsEqualsImplementedAssemblyNotOk.AClassWithEqualsNotCorrectlyImplemented) +
        " does not implement Equals correctly."
    )]
    [InlineData(nameof(IsEqualsImplementedAssemblyNoDefinitionAtAll),
        true,
        null,
        "No class in the assembly " + nameof(IsEqualsImplementedAssemblyNoDefinitionAtAll) +
        " seems to implement Equals.")]
    public void AreAllEqualsImplementedCorrectlyTests(string assemblyName, bool expectedResult,
        Type expectedResultClass, string expectedResultMessage)
    {
        var sut = new Verify();

        // This is not an integration test but it relies on files on the hard drive.
        var assembly = Assembly.LoadFrom(getAssemblyLocation(assemblyName));

        //  #   Act.
        var resAllOk = sut.AreAllEqualsImplementedCorrectly(assembly);

        //  #   Assert.
        resAllOk.Should().Be(expectedResult);
        sut.ResultClass.Should().Be(expectedResultClass);
        sut.ResultMessage.Should().Be(expectedResultMessage);

        static string getAssemblyLocation(string assName)
        {
            var ass = Assembly.Load(assName);
            return ass.Location;
        }
    }

    [Fact]
    public void CanUseExplicitlyCreatedObject()
    {
        var sut = new Verify();
        sut.AddInstantiator<LackingDefaultConstructor>(() => new LackingDefaultConstructor(default, string.Empty));

        //  #   Act.
        var resAllOk = sut.IsEqualsImplementedCorrectly<LackingDefaultConstructor>();

        //  #   Assert.
        resAllOk.Should().BeTrue();
    }

    [Fact]
    public void CanIgnoreClasses()
    {
        var sut = new Verify();

        var assembly = Assembly.Load(nameof(IsEqualsImplementedAssemblyNotOk));
        var res = sut.AreAllEqualsImplementedCorrectly(assembly);
        res.Should().BeFalse("Sanity check the test would fail without ignoration.");

        //  #   Act.
        sut.AddIgnoredClass<IsEqualsImplementedAssemblyNotOk.AClassWithEqualsNotCorrectlyImplemented>();

        //  #   Assert.
        res = sut.AreAllEqualsImplementedCorrectly(assembly);
        res.Should().BeTrue();
    }
}
