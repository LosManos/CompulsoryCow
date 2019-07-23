using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public class TimeSpanTests : TestsBase
    {
        public TimeSpanTests(ITestOutputHelper output)
            : base(output)
        { }

        [Fact]
        public void Constructor_Ticks_Kind_ShouldCreate()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();
            var systemTimeSpan = new System.TimeSpan(anyTicks);

            //  #   Act.
            var sut = new Abstractions.TimeSpan(anyTicks);

            //  #   Assert.
            AssertEquals(systemTimeSpan, sut);
        }

        /// <summary>This method only tests for the Ticks property.
        /// Rewrite it to test for all properties like DateTime.
        /// </summary>
        [Fact]
        public void GetTicks()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();

            //  #   Act.
            var sut = new Abstractions.TimeSpan(anyTicks);

            //  #   Assert.
            sut.Ticks.Should().Be(anyTicks);
        }

        private static void AssertEquals(
            System.TimeSpan expected,
            Abstractions.TimeSpan actual,
            string because = "")
        {
            // TODO:OF:Check for all properties.
            actual.Ticks.Should().Be(expected.Ticks, because);
        }
    }
}
