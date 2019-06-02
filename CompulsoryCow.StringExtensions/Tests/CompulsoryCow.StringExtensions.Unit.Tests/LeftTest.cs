using System;
using CompulsoryCow.StringExtensions;
using FluentAssertions;
using Xunit;

namespace StringExtensionTest
{
	public class LeftTest
	{
		[Fact]
		public void Left_given_Null_should_ThrowException()
		{
			//	#	Act and Assert.
            Assert.Throws<ArgumentNullException>(() => {
                ((string)null).Left(0);
            });
		}

		[Fact]
		public void Left_given_ZeroLength_should_ReturnEmptyString()
		{
            //	#	Act and Assert.
            "".Left(0).Should().BeEmpty();
            "a".Left(0).Should().BeEmpty();
		}

		[Fact]
		public void Left_given_ShorterOrEqualLength_should_ReturnProperString()
		{
			//	#	Act and Assert.
			"a".Left(1).Should().Be("a");
			"ab".Left(1).Should().Be("a");
			"ab".Left(2).Should().Be("ab");
		}

		[Fact]
		public void Left_given_LongerLength_should_ReturnFullString()
		{
			//	#	Act and Assert.
			"a".Left(2).Should().Be("a");
			"ab".Left(4).Should().Be("ab");
		}
	}
}
