using System;
using CompulsoryCow.StringExtensions;
using FluentAssertions;
using Xunit;

namespace StringExtensionTest
{
	public class RightTest
	{
        [Fact]
        public void Right_given_Null_should_ThrowException()
        {
            //	#	Act and Assert.
            Assert.Throws<ArgumentNullException>(() =>
            {
                ((string)null).Right(0);
            });
		}

		[Fact]
		public void Right_given_ZeroLength_should_ReturnEmptyString()
		{
            //	#	Act and Assert.
            "".Right(0).Should().BeEmpty();
            "a".Right(0).Should().BeEmpty();
		}

		[Fact]
		public void Right_given_ShorterOrEqualLength_should_ReturnProperString()
		{
            //	#	Act and Assert.
            "a".Right(1).Should().Be("a");
            "ab".Right(1).Should().Be("b");
            "abc".Right(2).Should().Be("bc");
            "ab".Right(2).Should().Be("ab");
		}

		[Fact]
		public void Right_given_LongerLength_should_ReturnFullString()
		{
            //	#	Act and Assert.
            "a".Right(2).Should().Be("a");
            "ab".Right(4).Should().Be("ab");
		}
	}
}
