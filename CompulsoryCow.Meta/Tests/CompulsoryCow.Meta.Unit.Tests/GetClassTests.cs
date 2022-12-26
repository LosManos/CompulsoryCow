using CompulsoryCow;
using FluentAssertions;
using MetaTestClassesDotnetFramework;
using System;
using System.Linq;
using Xunit;

namespace MetaTest;

public class GetClassTests
{
    #region GetClass( className:string ) extension

    [Theory]
    [InlineData("MyInnerPublicClass")]
    [InlineData("MyInnerInternalClass")]
    [InlineData("MyInnerPrivateClass")]
    [InlineData("MyInnerStaticPublicClass")]
    [InlineData("MyInnerStaticInternalClass")]
    [InlineData("MyInnerStaticPrivateClass")]
    public void GetClass_KnownClass_ReturnClassesType(string className)
    {
            var res = new MyPublicClass().GetClass(className);

        res.Should().NotBeNull();
        res.Name.Should().Be(className);
    }

    [Fact]
    public void GetClass_Should_throw_exception_When_unknow_class()
    {
        //  #   Act.
        Assert.Throws<ArgumentException>(() =>
        {
            new MyPublicClass().GetClass("doesnotexist");
        });
    }

    #endregion  //  GetClass( className:string ) extension

    #region GetClassOrNull( className:string ) extension

    [Theory]
    [InlineData("MyInnerPublicClass")]
    [InlineData("MyInnerInternalClass")]
    [InlineData("MyInnerPrivateClass")]
    [InlineData("MyInnerStaticPublicClass")]
    [InlineData("MyInnerStaticInternalClass")]
    [InlineData("MyInnerStaticPrivateClass")]
    public void GetClassOrNull_Should_return_classes_type_When_known_class(string className)
    {
        var res = Meta.GetClassOrNull(typeof(MyPublicClass), className);
        res.Should().NotBeNull();
        res.Name.Should().Be(className);
    }

    [Fact]
    public void GetClassOrNull_Should_throw_exception_When_unknow_class()
    {
        //  #   Act.
        var res = Meta.GetClassOrNull(typeof(MyPublicClass), "doesnotexist");

        //  #   Assert.
        res.Should().BeNull();
    }

    #endregion  //  GetClassOrNull( className:string ) extension

    #region GetStaticClass( className:string )

    [Theory]
    [InlineData("MyInnerStaticPublicClass")]
    [InlineData("MyInnerStaticInternalClass")]
    [InlineData("MyInnerStaticPrivateClass")]
    public void GetStaticClass_Should_return_classes_type_When_known_class(string className)
    {
        //  #   Act.
        var res = Meta.GetClass<MyPublicStaticClass>(className);

        //  #   Assert.
        res.Should().NotBeNull();
        res.Name.Should().Be(className);
    }

    [Fact]
    public void GetStaticClass_Should_return_null_When_unknown_class()
    {
        //  #   Act.
        Assert.Throws<ArgumentException>(() =>
            Meta.GetClass<MyPublicStaticClass>("doesnotexst")
        );
    }

    #endregion  // GetStaticClass( className:string )

    #region GetClass( assemblyName:string, namespace:string, className:string)

    [Theory]
    [InlineData("MetaTestClassesDotnetFramework", "MyPublicStaticClass")]
    [InlineData("MetaTestClassesDotnetFramework", "MyInternalStaticClass")]
    [InlineData("MetaTestClassesDotnetFramework", "MyPublicStaticClass+MyInnerStaticPublicClass")]
    [InlineData("MetaTestClassesDotnetFramework", "MyPublicStaticClass+MyInnerStaticInternalClass")]
    [InlineData("MetaTestClassesDotnetFramework", "MyPublicStaticClass+MyInnerStaticPrivateClass")]
    [InlineData("MetaTestClassesDotnetFramework", "MyInternalStaticClass+MyInnerStaticPublicClass")]
    [InlineData("MetaTestClassesDotnetFramework", "MyInternalStaticClass+MyInnerStaticInternalClass")]
    [InlineData("MetaTestClassesDotnetFramework", "MyInternalStaticClass+MyInnerStaticPrivateClass")]
    public void GetInternalClass_Should_return_type_When_known_namespace_and_known_class(string @namespace, string className)
    {
        //  #   Arrange.
        Console.WriteLine($"Indata:{{Namespace={@namespace},ClassName{className}}}");
        const string AssemblyName = "CompulsoryCow.Meta.Meta.Test.TestClassesDotnetFramework";
        // Just reference the assembly by loading the assembly so we don't have to loade it explicitly through AssemblyLoadFrom.
        // This testing code might not work in Release compile.
        new MetaTestClassesDotnetFramework.MyPublicClass();
        var assembly =
            AppDomain.CurrentDomain.GetAssemblies()
            .SingleOrDefault(a => a.FullName?.StartsWith(AssemblyName)?? false);
        assembly.Should().NotBeNull("Intermediary check we have managed to load the assembly(/class).");
        var @class = assembly?.GetType($"{@namespace}.{className}");
        @class.Should().NotBeNull("Intermediary check we have managed to load the (assembly/)class.");

        //  #   Act.
        var res = Meta.GetClass(AssemblyName, @namespace, className);

        //  #   Assert.
        res.Should().NotBeNull();
        res.FullName.Should().Be($"{@namespace}.{className}");
    }

    [Fact]
    public void GetInternalClass_Should_throw_argumentexception_When_known_assembly_and_namespace_and_unknown_class()
    {
        //  #   Arrange.
        const string AssemblyName = "MetaTestClassesDotnetFramework";
        const string Namespace = "MetaTestClassesDotnetFramework";
        // Just reference the assembly by loading the assembly so we don't have to loade it explicitly through AssemblyLoadFrom.
        // This testing code might not work in Release compile.
        new MetaTestClassesDotnetFramework.MyPublicClass();

        //  #   Act.
        Assert.Throws<ArgumentException>(() =>
        {
            Meta.GetClass(AssemblyName, Namespace, "ThisClassDoesNotExist");
        });
    }

    [Fact]
    public void GetInternalClass_Should_throw_argumentexception_When_known_assembly_and_unknown_namespace()
    {
        //  #   Arrange.
        const string AssemblyName = "MetaTestClassesDotnetFramework";
        // Just reference the assembly by loading the assembly so we don't have to loade it explicitly through AssemblyLoadFrom.
        // This testing code might not work in Release compile.
        new MetaTestClassesDotnetFramework.MyPublicClass();

        //  #   Act.
        Assert.Throws<ArgumentException>(() =>
        {
            Meta.GetClass(AssemblyName, "ThisNamespaceDoesnotExist", "ThisClassDoesNotExist");
        });
    }

    [Fact]
    public void GetInternalClass_Should_throw_argumentexception_When_unknown_assembly()
    {
        //  #   Arrange.
        const string AssemblyName = "MetaTestClassesDotnetFramework";
        // Just reference the assembly by loading the assembly so we don't have to loade it explicitly through AssemblyLoadFrom.
        // This testing code might not work in Release compile.
        new MetaTestClassesDotnetFramework.MyPublicClass();

        //  #   Act.
        Assert.Throws<ArgumentException>(() =>
        {
            Meta.GetClass(AssemblyName, "ThisNamespaceDoesnotExist", "ThisClassDoesNotExist");
        });
    }
    #endregion  //  GetClass( assemblyName:string, namespace:string, className:string)
}
