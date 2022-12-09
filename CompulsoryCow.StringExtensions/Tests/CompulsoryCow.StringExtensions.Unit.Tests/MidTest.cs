using CompulsoryCow.StringExtensions;
using FluentAssertions;
using System;
using Xunit;

namespace StringExtensionTest;

public class MidTest
{
    [Fact]
    public void Mid_given_Null_should_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            ((string)null).Mid(0, 0);
        });
    }

    [Fact]
    public void Mid_given_NegativeStartIndex_should_ThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            "".Mid(-1, 0);
        });
    }

    [Fact]
    public void Mid_given_ZeroStart_should_ReturnStringFromBeginning()
    {
        "".Mid(0, 0).Should().BeEmpty();
        "a".Mid(0, 1).Should().Be("a");
        "ab".Mid(0, 1).Should().Be("a");
        "a".Mid(0, 2).Should().Be("a");
        "ab".Mid(0, 3).Should().Be("ab");
    }

    [Fact]
    public void Mid_given_StartInsideString_should_ReturnStringFromThere()
    {
        "".Mid(1, 0).Should().BeEmpty();
        "a".Mid(1, 1).Should().BeEmpty();
        "ab".Mid(1, 1).Should().Be("b");
        "a".Mid(1, 2).Should(). BeEmpty() ;
        "abc".Mid(1, 2).Should().Be("bc");
        "abc".Mid(1, 3).Should().Be("bc");
    }

    [Fact]
    public void Mid_given_StartAfterString_should_ReturnEmpty()
    {
        "".Mid(1, 0).Should().BeEmpty();;
        "".Mid(1, 1).Should().BeEmpty();;
        "".Mid(2, 2).Should().BeEmpty();;
        "a".Mid(1, 0).Should().BeEmpty();;
        "a".Mid(1, 1).Should().BeEmpty();;
        "a".Mid(2, 2).Should().BeEmpty();;
        "abc".Mid(3, 42).Should().BeEmpty();;
    }

    [Fact]
    public void Mid_given_NegativeLength_should_ReturnLeftOfStart()
    {
        "".Mid(0, -1).Should().BeEmpty();
        "".Mid(0, -2).Should().BeEmpty();
        "".Mid(1, -1).Should().BeEmpty();
        "".Mid(2, -2).Should().BeEmpty();
        "a".Mid(1, -1).Should().Be("a");
        "abc".Mid(2, -1).Should().Be("b");
        "abc".Mid(2, -4).Should().Be("ab");
        "abc".Mid(3, -4).Should().Be("abc");
    }
}
