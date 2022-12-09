using System;
using CompulsoryCow.StringExtensions;
using FluentAssertions;
using Xunit;

namespace StringExtensionTest;

public class SplitAtStringExtensionsTest
{
    [Fact]
    public void SplitAtIndexNormalSucceed()
    {
        var res = "".SplitAt("");
        res.Should().Be(new Tuple<string, string>("", ""));

        res = "abc".SplitAt("a");
        res.Should().Be(new Tuple<string, string>("", "bc"));

        res = "abc".SplitAt("ab");
        res.Should().Be(new Tuple<string, string>("", "c"));

        res = "abc".SplitAt("abc");
        res.Should().Be(new Tuple<string, string>("", ""));

        res = "abc".SplitAt("b");
        res.Should().Be(new Tuple<string, string>("a", "c"));

        res = "abc".SplitAt("bc");
        res.Should().Be(new Tuple<string, string>("a", ""));

        res = "abc".SplitAt("c");
        res.Should().Be(new Tuple<string, string>("ab", ""));

        res = "abcd".SplitAt("ab");
        res.Should().Be(new Tuple<string, string>("", "cd"));

        res = "abcd".SplitAt("bc");
        res.Should().Be(new Tuple<string, string>("a", "d"));
        
        res = "abcd".SplitAt("cd");
        res.Should().Be(new Tuple<string, string>("ab", ""));
    }

    [Fact] 
    public void WrongSplitString(){
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            "abc".SplitAt("d");
        });
    }

}
