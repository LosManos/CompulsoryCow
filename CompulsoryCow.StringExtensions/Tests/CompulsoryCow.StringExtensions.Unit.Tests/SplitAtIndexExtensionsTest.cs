using System;
using CompulsoryCow.StringExtensions;
using FluentAssertions;
using Xunit;

namespace StringExtensionTest
{
    public class SplitAtIndexExtensionsTest
    {
        [Fact]
        public void SplitAtIndexNormalSucceed()
        {
            var res = "".SplitAt(0);
            res.Should().Be(new Tuple<string, string>("", ""));

            res = "abc".SplitAt(0);
            res.Should().Be(new Tuple<string, string>("", "abc"));

            res = "abc".SplitAt(1);
            res.Should().Be(new Tuple<string, string>("a", "bc"));

            res = "abc".SplitAt(2);
            res.Should().Be(new Tuple<string, string>("ab", "c"));

            res = "abc".SplitAt(3);
            res.Should().Be(new Tuple<string, string>("abc", ""));
        }

        [Fact]
        public void IndexTooSmall(){
            Assert.Throws<ArgumentOutOfRangeException>(() =>
           {
               "abc".SplitAt(-1);
           });
        }

        [Fact]
        public void IndexTooBig(){
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                "abc".SplitAt(4);
            });
        }
    }
}
