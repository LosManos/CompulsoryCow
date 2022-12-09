using System;
using CompulsoryCow.StringExtensions;
using FluentAssertions;
using Xunit;

namespace StringExtensionTest;

public class SafeFormatExtensionsTest
{
    [Fact]
    public void NormalSucceed()
    {
        var res = "a{0}c".SFormat("b");
        res.Should().Be("abc");
    }

    [Fact]
    public void TooFewArgumentsNoArgument()
    {
        var res = "a{0}c".SFormat();
        res.Should().Be("a{0}c[Failed formatting. Parameter(s) missing.]");
		}

		[Fact]
		public void TooFewArguments()
		{
			var res = "a{0}c{1}e".SFormat("b");
        res.Should().Be("a{0}c{1}e[Failed formatting. Parameter(s) missing. Parameter(s) is/are:{System.String:'b'}.]");
		}

    [Fact]
    public void NoNothing()
    {
        var res = ((string)null).SFormat();
        res.Should().BeEmpty( "It should always returns a string, empty is so.");
    }

    [Fact]
    public void OneTooManyArguments()
    {
        var res = "a{0}c".SFormat("b", "d");
        res.Should().Be("abc[Failed formatting. Too many parameters. Parameter(s) was/were:{System.String:'b',System.String:'d'}.]");
    }

    [Fact]
    public void TwoTooManyArguments()
    {
        var res = "a{0}c".SFormat("b", "d", "e");
        res.Should().Be("abc[Failed formatting. Too many parameters. Parameter(s) was/were:{System.String:'b',System.String:'d',System.String:'e'}.]");
    }

    [Fact]
    public void NullFormatNoParameter()
    {
        var res = ((string)null).SFormat();
        res.Should().BeEmpty( "SafeFormat should alwas return a string.");

			res = ((string)null).SFormat(null);
			res.Should().BeEmpty( "SafeFormat should alwas return a string.");
		}

		[Fact]
		public void NullFormatHasParameters()
		{
        var res = ((string)null).SFormat("a");
        res.Should().Be("[Failed formatting. Format string was empty. Parameter(s) was/were:{System.String:'a'}.]");
        
        res = ((string)null).SFormat("a", "b");
        res.Should().Be("[Failed formatting. Format string was empty. Parameter(s) was/were:{System.String:'a',System.String:'b'}.]");
    }

    /// <summary>This method just makes sure there is a static method.
    /// </summary>
    [Fact]
    public void StaticMethod()
    {
        var res = SafeFormatExtensions.SafeFormat("a{0}c", "b");
        res.Should().Be("abc");
    }

		private class MyClass
		{
			public override string ToString()
			{
				throw new Exception("Exception created for unit testing use.");
			}
		}

		[Fact]
		public void ForceOuterExcpetion()
		{
			var res = "a{0}c".SFormat(new MyClass());
        res.Should().Be("Exception created for unit testing use.");
		}

		[Fact]
		public void ForceOuterExcpetionStatic()
		{
			var res = SafeFormatExtensions.SafeFormat( "a{0}c", new MyClass());
        res.Should().Be("Exception created for unit testing use.");
		}

		[Fact]
		public void ExceptionThrown()
		{
			Tuple<int> myObject = null;
        Assert.Throws<NullReferenceException>(() =>
       {
           "a{0}c".SFormat(myObject.Item1);
       });
		}

		[Fact]
		public void ExceptionThrownStatic()
		{
			Tuple<int> myObject = null;
        Assert.Throws<NullReferenceException>(() =>
       {
           SafeFormatExtensions.SafeFormat("a{0}c", myObject.Item1);
       });
		}

		[Fact]
		public void FormatFormatstringAndParametersFail()
		{
			var res = "{82CE0089-A9F1-489F-81B9-8271D0EFE26E}".SFormat();
        res.Should().Be("Failed formatting. Format string '{82CE0089-A9F1-489F-81B9-8271D0EFE26E}' and its parameter(s){} was not formattable.");
		}
	}
